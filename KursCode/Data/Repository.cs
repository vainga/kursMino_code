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

        public void Add(string tableName, string[] columnNames, object[] values)
        {
            if (columnNames.Length != values.Length)
            {
                throw new ArgumentException("Number of column names does not match number of values.");
            }

            using (var command = _databaseHelper.CreateCommand())
            {
                StringBuilder columnsBuilder = new StringBuilder();
                StringBuilder parametersBuilder = new StringBuilder();

                for (int i = 0; i < columnNames.Length; i++)
                {
                    var paramName = $"@{columnNames[i]}";
                    if (i > 0)
                    {
                        columnsBuilder.Append(", ");
                        parametersBuilder.Append(", ");
                    }
                    columnsBuilder.Append(columnNames[i]);
                    parametersBuilder.Append(paramName);

                    var parameter = command.CreateParameter();
                    parameter.ParameterName = paramName;
                    parameter.Value = values[i];
                    command.Parameters.Add(parameter);
                }

                string columns = columnsBuilder.ToString();
                string parameters = parametersBuilder.ToString();

                command.CommandText = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";

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

                var parameter = command.CreateParameter();
                parameter.ParameterName = "@Id";
                parameter.Value = id;
                command.Parameters.Add(parameter);

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

                var parameter = command.CreateParameter();
                parameter.ParameterName = "@Id";
                parameter.Value = id;
                command.Parameters.Add(parameter);

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

                                var value = reader[columnName];
                                if (value != DBNull.Value)
                                {
                                    property.SetValue(entity, value);
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

                var newValueParameter = command.CreateParameter();
                newValueParameter.ParameterName = "@NewValue";
                newValueParameter.Value = newValue;
                command.Parameters.Add(newValueParameter);

                var idParameter = command.CreateParameter();
                idParameter.ParameterName = "@Id";
                idParameter.Value = id;
                command.Parameters.Add(idParameter);

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

        public int GetLastId(string tableName)
        {
            int lastId = 0;

            bool tableExists = CheckIfTableExists(tableName);

            if (tableExists)
            {
                using (var command = _databaseHelper.CreateCommand())
                {
                    command.CommandText = $"SELECT last_insert_rowid() FROM {tableName}";

                    try
                    {
                        _databaseHelper.OpenConnection();

                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            lastId = Convert.ToInt32(result);
                        }

                        _databaseHelper.CloseConnection();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }

            return lastId;
        }


        private bool CheckIfTableExists(string tableName)
        {
            using (var command = _databaseHelper.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name=@TableName";

                var parameter = command.CreateParameter();
                parameter.ParameterName = "@TableName";
                parameter.Value = tableName;
                command.Parameters.Add(parameter);

                try
                {
                    _databaseHelper.OpenConnection();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    _databaseHelper.CloseConnection();
                    return count > 0;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }

}
