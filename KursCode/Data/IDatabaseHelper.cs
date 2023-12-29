using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Data
{
    interface IDatabaseHelper : IDisposable
    {
        public List<T> GetAllEntities<T>(string filePath);
        public bool IsValueUnique<T>(Func<T, bool> predicate, List<T> existingEntities);
        public int GetNextEntityId<T>(Func<T, int> idSelector, List<T> existingEntities);
        public void SaveEntityToFile<T>(T entity, List<T> existingEntities);
        public void RemoveEntity<T>(Func<T, bool> predicate, List<T> existingEntities);
    }
}
