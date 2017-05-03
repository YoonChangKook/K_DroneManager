using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Odbc;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DroneManager.UWB.Calibration
{
    public abstract class CSVManager
    {
        public static void CSVWrite(string fileName, string[] keys, List<string[]> rows)
        {
            StreamWriter csv = new StreamWriter(fileName, false, Encoding.UTF8);

            foreach (string key in keys)
                csv.Write(key + ",");
            csv.WriteLine();

            foreach (string[] row in rows)
                foreach(string col in row)
                    csv.Write(col + ",");
            csv.WriteLine();
        }

        public static DataTable CSVRead(string fileName)
        {
            StreamReader csv;
            try
            {
                csv = new StreamReader(fileName, Encoding.UTF8);
            }
            catch (FileNotFoundException ex)
            {
                return null;
            }

            DataTable table = new DataTable();
            DataRow row = null;
            string line;
            string[] keys;
            string[] values;

            keys = csv.ReadLine().Split(',');
            foreach (string key in keys)
            {
                if (key.Equals(""))
                    continue;

                table.Columns.Add(new DataColumn(key, typeof(string)));
            }

            while ((line = csv.ReadLine()) != null)
            {
                values = line.Split(',');

                row = table.NewRow();
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i].Equals(""))
                        continue;

                    row[keys[i]] = values[i];
                }
                table.Rows.Add(row);
            }
            csv.Close();

            return table;
        }
    }
}
