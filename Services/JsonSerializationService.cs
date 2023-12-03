using System.IO;
using System.Text.Json;


namespace PublicTransportRoutes.Services
{
    public static class JsonSerializationService
    {
        public static void Serialize<T>(T data, string path, string fileName)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

            path = Directory.GetCurrentDirectory() + path;

            CreatePathIfNotExist(path);

            File.WriteAllText(path + fileName, json.ToString());
        }

        public static T? Deserialize<T>(string path, string fileName)
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + path) || !File.Exists(Directory.GetCurrentDirectory() + path + fileName))
                return default;

            using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + path + fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length == 0)
                    return default;

                return JsonSerializer.Deserialize<T>(fs);
            }
        }

        private static void CreatePathIfNotExist(string path)
        {
            bool exists = Directory.Exists(path);

            if (exists)
                return;

            Directory.CreateDirectory(path);
        }
    }
}
