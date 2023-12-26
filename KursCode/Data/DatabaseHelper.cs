using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.IO;
using System.Xml;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace KursCode.Data
{
    public class DatabaseHelper : IDisposable
    {
        private bool disposed = false;

        private static string connectionString;

        public DatabaseHelper(string filePath)
        {
            connectionString = filePath;
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

        public List<T> GetAllEntities<T>(string filePath)
        {
            List<T> existingEntities = new List<T>();

            if (File.Exists(filePath))
            {
                string existingJsonData = File.ReadAllText(filePath);
                existingEntities = JsonSerializer.Deserialize<List<T>>(existingJsonData);
            }

            return existingEntities;
        }

        public bool IsValueUnique<T>(Func<T, bool> predicate, List<T> existingEntities)
        {
            return !existingEntities.Any(predicate);
        }

        public int GetNextEntityId<T>(Func<T, int> idSelector, List<T> existingEntities)
        {
            return existingEntities.Count > 0 ? existingEntities.Max(idSelector) + 1 : 1;
        }

        public void SaveEntityToFile<T>(T entity, List<T> existingEntities)
        {

            existingEntities.Add(entity);
            string directoryPath = Path.GetDirectoryName(connectionString);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string updatedJsonData = JsonSerializer.Serialize(existingEntities);
            File.WriteAllText(connectionString, updatedJsonData);
        }

        public void RemoveEntity<T>(Func<T, bool> predicate, List<T> existingEntities)
        {
            T entityToRemove = existingEntities.FirstOrDefault(predicate);

            if (entityToRemove != null)
            {
                existingEntities.Remove(entityToRemove);
                string updatedJsonData = JsonSerializer.Serialize(existingEntities);
                File.WriteAllText(connectionString, updatedJsonData);
            }
        }
    }
}
