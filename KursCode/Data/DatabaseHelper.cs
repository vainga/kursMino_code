using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.IO;

namespace KursCode.Data
{
    public class DatabaseHelper
    {
        private bool disposed = false;

        private readonly string dbPath;

        public DatabaseHelper(string dbPath)
        {
            this.dbPath = dbPath;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }

                disposed = true;
            }
        }

        public void CreateDatabase(string dbPath, string tableName, string columns)
        {
            try
            {
                using (FileStream fileStream = File.Create(dbPath))
                {
                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        writer.WriteLine(columns);
                    }
                }
            }
            catch (IOException ioex)
            {
            }
            catch (Exception ex)
            {
            }
        }


        public bool IsValueUnique(string tableName, string columnName, string value)
        {
            bool isUnique = false;

            try
            {
                string[] allLines = File.ReadAllLines(dbPath);

                int columnIndex = Array.IndexOf(allLines[0].Split(','), columnName);

                isUnique = allLines.Skip(1).All(line => line.Split(',')[columnIndex] != value);
            }
            catch (IOException ioex)
            {
            }
            catch (Exception ex)
            {
            }

            return isUnique;
        }

        public class CustomFileManager
        {
            private readonly string dbPath;

            public CustomFileManager(string dbPath)
            {
                this.dbPath = dbPath;
            }

            public int InsertData(string tableName, string[] columns, object[] values)
            {
                int insertedId = 0;

                try
                {
                    using (StreamWriter writer = File.AppendText(dbPath))
                    {
                        string dataLine = string.Join(",", values);
                        writer.WriteLine(dataLine);

                        insertedId = (int)writer.BaseStream.Length;
                    }
                }
                catch (IOException ioex)
                {

                }
                catch (Exception ex)
                {

                }
                return insertedId;
            }
        }

        public List<Dictionary<string, object>> SearchData(string tableName, string[] columns, Func<string[], bool> condition)
        {
            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();

            try
            {
                string[] allLines = File.ReadAllLines(dbPath);

                int[] columnIndices = columns.Select(col => Array.IndexOf(allLines[0].Split(','), col)).ToArray();

                foreach (string line in allLines.Skip(1))
                {
                    string[] values = line.Split(',');

                    if (condition(values))
                    {
                        Dictionary<string, object> row = new Dictionary<string, object>();

                        for (int i = 0; i < columns.Length; i++)
                        {
                            row[columns[i]] = values[columnIndices[i]];
                        }

                        results.Add(row);
                    }
                }
            }
            catch (IOException ioex)
            {
            }
            catch (Exception ex)
            {
            }

            return results;
        }

        public void RemoveData(int itemIdToDelete)
        {
            try
            {
                string[] allLines = File.ReadAllLines(dbPath).ToArray();

                int idColumnIndex = Array.IndexOf(allLines[0].Split(','), "Id");

                IEnumerable<string> remainingLines = allLines
                    .Where(line => line.Split(',')[idColumnIndex] != itemIdToDelete.ToString());

                File.WriteAllLines(dbPath, remainingLines);
            }
            catch (IOException ioex)
            {

            }
            catch (Exception ex)
            {

            }
        }


    }
}
