using Newtonsoft.Json;

namespace SimplePictureViewer.Helpers
{
    internal class FileHelper<T> where T : new()
    {
        private readonly string _filePath;

        public FileHelper(string filePath)
        {
            _filePath = filePath;
        }

        public void SerializeToJson(T data)
        {
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(data));
        }

        public T DeserializeFromJson()
        {
            if(File.Exists(_filePath))
            {
                return JsonConvert.DeserializeObject<T>(File.ReadAllText(_filePath));
            }
            else
            {
                return new T();
            }
        }
    }
}
