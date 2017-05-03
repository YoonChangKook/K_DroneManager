using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using InTheHand.Net;
using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;
using InTheHand.Windows.Forms;

namespace DroneManager.BluetoothModule
{
    public class BluetoothServer
    {
        private BluetoothListener bluetoothListener;
        private IAsyncResult acceptResult;
        private readonly object bluetoothLocker;
        private bool serverStarted;
        private int clientIndex;
        private Dictionary<int, BluetoothClient> clientList;
        private Dictionary<int, BluetoothClientThread> clientThreadList;
        private readonly object clientListLocker;

        private MainForm mainForm;

        public BluetoothServer(MainForm mainForm)
        {
            this.mainForm = mainForm;

            bluetoothLocker = new object();
            serverStarted = false;
            clientIndex = 0;
            clientList = new Dictionary<int, BluetoothClient>();
            clientThreadList = new Dictionary<int, BluetoothClientThread>();
            clientListLocker = new object();
        }

        public void ServerStart()
        {
            if (serverStarted)
            {
                lock(bluetoothLocker)
                {
                    bluetoothListener.Stop();
                    bluetoothListener = null;
                }
                //bluetoothListener = null;
                //if (bluetoothServerThread.IsAlive)
                //    bluetoothServerThread.Abort();
                
                lock (clientListLocker)
                {
                    clientIndex = 0;
                    
                    foreach (int id in clientList.Keys)
                    {
                        clientList[id].Close();
                        clientThreadList[id].ClientClose();
                        mainForm.DisconnectDrone(id);
                    }
                    clientList.Clear();
                    clientThreadList.Clear();
                }
                mainForm.UpdateLog("---Server Close---");
                serverStarted = false;
            }
            else
            {
                this.bluetoothListener = new BluetoothListener(BluetoothConsts.ServiceUUID);
                this.bluetoothListener.Start();
                this.acceptResult = this.bluetoothListener.BeginAcceptBluetoothClient(BluetoothAccept, this.bluetoothListener);

                mainForm.UpdateLog("---Server Start---");
                serverStarted = true;
            }
        }
        private void BluetoothAccept(IAsyncResult result)
        {
            lock(bluetoothLocker)
                if (this.bluetoothListener == null)
                    return;

            BluetoothListener listener = (BluetoothListener)result.AsyncState;
            BluetoothClient connectedClient;
            lock(bluetoothLocker)
                connectedClient = listener.EndAcceptBluetoothClient(result);
            this.acceptResult = ((BluetoothListener)result.AsyncState).BeginAcceptBluetoothClient(BluetoothAccept, result.AsyncState);
            //BluetoothClient connectedClient = (BluetoothClient)result;
            int tempClientIndex;

            lock (clientListLocker)
            {
                tempClientIndex = clientIndex++;
                clientList.Add(tempClientIndex, connectedClient);
            }
            CreateClient(connectedClient, tempClientIndex);
            mainForm.ConnectDrone(tempClientIndex);
            mainForm.UpdateLog("Client" + tempClientIndex.ToString() + " Accepted");
        }
        public void CreateClient(BluetoothClient connectedClient, int clientIndex)
        {
            Stream stream = connectedClient.GetStream();

            BluetoothClientThread clientThread = 
                new BluetoothClientThread(clientIndex, mainForm, this, stream);
            lock(clientListLocker)
                clientThreadList.Add(clientIndex, clientThread);
        }
        public void DeleteClient(int clientIndex)
        {
            lock (clientListLocker)
            {
                this.clientList[clientIndex].Close();
                this.clientList.Remove(clientIndex);
                this.clientThreadList[clientIndex].ClientClose();
                this.clientThreadList.Remove(clientIndex);
            }
        }

        public bool GetServerStarted() { return this.serverStarted; }

        public int[] GetClientIds()
        {
            int[] keys = clientList.Keys.ToArray();
            return keys;
        }
        
        public void WriteData(int clientID, byte[] data)
        {
            // Call from main form(button)
            clientThreadList[clientID].PacketWrite(data);
        }
        public void ReceiveData(int clientID, byte[] receivedData)
        {
            // Call from client thread
            if (receivedData.Length == 0)   // disconnect
            {
                mainForm.UpdateLog("Client" + clientID.ToString() + " Disconnected");
                DeleteClient(clientID);
                mainForm.DisconnectDrone(clientID);
            }
            else
            {
                // Send data to main form
                mainForm.ReceiveDroneInfo(clientID, receivedData);
            }
        }
    }
}
