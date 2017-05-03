using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using InTheHand.Net;
using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;

namespace DroneManager.BluetoothModule
{
    class BluetoothClientThread
    {
        private static readonly int BUFFER_SIZE = 1024;
        private readonly object streamLocker;
        private readonly Stream stream;
        private Thread clientThread;

        private MainForm mainForm;
        private BluetoothServer server;
        private int id;

        public BluetoothClientThread(int index, MainForm mainForm, BluetoothServer server, Stream stream)
        {
            this.mainForm = mainForm;
            this.server = server;
            this.id = index;

            this.stream = stream;
            streamLocker = new object();
            clientThread = new Thread(new ThreadStart(PacketReader));
            clientThread.Start();
        }

        // Thread Function
        private async void PacketReader()
        {
            byte[] buffer = new byte[BUFFER_SIZE];

            while (true)
            {
                int readNum = await stream.ReadAsync(buffer, 0, buffer.Length);

                byte[] buffer2 = new byte[readNum];
                Array.Copy(buffer, buffer2, readNum);
                server.ReceiveData(this.id, buffer2);
                if (buffer2.Length == 0)
                    break;
            }
        }

        public void PacketWrite(byte[] data)
        {
            stream.Write(data, 0, data.Length);
        }

        public void ClientClose()
        {
            if(this.clientThread.IsAlive)
                this.clientThread.Abort();
        }

        public object GetStreamLocker()
        {
            return streamLocker;
        }
        public Stream GetStream()
        {
            return stream;
        }
        public int GetId()
        {
            return id;
        }
    }
}
