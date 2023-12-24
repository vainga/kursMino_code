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
    public class JsonArray
    {
        private readonly List<JsonElement> elements;

        public JsonArray(List<JsonElement> elements)
        {
            this.elements = elements;
        }

        public override string ToString()
        {
            var jsonArray = new JsonArray(elements);

            using (var stream = new MemoryStream())
            {
                using (var writer = new Utf8JsonWriter(stream, new JsonWriterOptions { Indented = true }))
                {
                    jsonArray.WriteTo(writer);
                }

                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        public void WriteTo(Utf8JsonWriter writer)
        {
            writer.WriteStartArray();

            foreach (var element in elements)
            {
                element.WriteTo(writer);
            }

            writer.WriteEndArray();
        }
    }


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

        public void CreateJsonFile(string path, string filename, string[] keys)
        {
            try
            {
                var data = new { Keys = keys };

                string jsonContent = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

                string fullPath = Path.Combine(path, filename);

                File.WriteAllText(fullPath, jsonContent);

                Console.WriteLine($"JSON файл успешно создан по пути: {fullPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании JSON файла: {ex.Message}");
            }
        }

        public void InsertJsonStringToFile(string fileName, string jsonStringToInsert)
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    Console.WriteLine($"Файл {fileName} не существует.");
                    return;
                }

                string existingJson = File.ReadAllText(fileName);

                var jsonDocument = JsonDocument.Parse(existingJson).RootElement;

                var newJsonObject = JsonDocument.Parse(jsonStringToInsert).RootElement;

                var jsonArray = jsonDocument.EnumerateArray().ToList();

                jsonArray.Add(newJsonObject);

                var updatedJsonArray = new JsonArray(jsonArray);

                string updatedJsonString = updatedJsonArray.ToString();

                File.WriteAllText(fileName, updatedJsonString);

                Console.WriteLine("Строка успешно вставлена в JSON файл.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        public bool IsValueUniqueForKey(string fileName, string keyToCheck, string valueToCheck)
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    Console.WriteLine($"Файл {fileName} не существует.");
                    return false;
                }

                string existingJson = File.ReadAllText(fileName);

                var jsonDocument = JsonDocument.Parse(existingJson).RootElement;

                if (!jsonDocument.EnumerateObject().Any(prop => prop.Name == keyToCheck))
                {
                    Console.WriteLine($"Ключ {keyToCheck} не существует в JSON файле.");
                    return false;
                }

                var valuesForKey = jsonDocument.EnumerateObject()
                    .Where(prop => prop.Name == keyToCheck)
                    .SelectMany(prop => prop.Value.EnumerateArray())
                    .Select(value => value.GetString()); // Используем GetString() для строк

                if (valuesForKey.Contains(valueToCheck))
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
                return false;
            }
        }



    }
}
