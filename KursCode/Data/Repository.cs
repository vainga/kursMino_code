using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KursCode.Data
{
    public class Repository : IRepository
    {
        private IDatabaseHelper _databaseHelper;
        public Repository(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public void Add<T>(string tableName, params object[] values)
        {
            if (values.Length == 0 || values.Length % 2 != 0)
            {
                throw new ArgumentException("Invalid number of parameters.");
            }

            var properties = typeof(T).GetProperties();

            using (var command = _databaseHelper.CreateCommand())
            {
                string columns = string.Join(", ", properties.Select(p => p.Name));
                string parameters = string.Join(", ", properties.Select(p => "@" + p.Name));

                command.CommandText = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";

                for (int i = 0; i < properties.Length; i++)
                {
                    command.Parameters.AddWithValue("@" + properties[i].Name, values[i]);
                }

                try
                {
                    _databaseHelper.OpenConnection();

                    command.ExecuteNonQuery();

                    _databaseHelper.CloseConnection();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public void Delete<T>(string tableName, int id)
        {
            using (var command = _databaseHelper.CreateCommand())
            {
                command.CommandText = $"DELETE FROM {tableName} WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    _databaseHelper.OpenConnection();

                    command.ExecuteNonQuery();

                    _databaseHelper.CloseConnection();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public T Search<T>(string tableName, int id)
        {
            T entity = default(T);

            using (var command = _databaseHelper.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM {tableName} WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    _databaseHelper.OpenConnection();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            entity = Activator.CreateInstance<T>();

                            var properties = typeof(T).GetProperties();

                            foreach (var property in properties)
                            {
                                var columnName = property.Name;

                                if (reader[columnName] != DBNull.Value)
                                {
                                    property.SetValue(entity, reader[columnName]);
                                }
                            }
                        }
                    }

                    _databaseHelper.CloseConnection();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return entity;
        }

        public void Change<T>(string tableName, int id, string columnName, object newValue)
        {
            using (var command = _databaseHelper.CreateCommand())
            {
                command.CommandText = $"UPDATE {tableName} SET {columnName} = @NewValue WHERE Id = @Id";
                command.Parameters.AddWithValue("@NewValue", newValue);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    _databaseHelper.OpenConnection();

                    command.ExecuteNonQuery();

                    _databaseHelper.CloseConnection();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }

}
