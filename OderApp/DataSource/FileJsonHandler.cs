using System.Text.Json;

namespace OderApp.DataSource
{
    public interface FileJsonHandler
    {
        Task wirteFile<TValue>(string filePath, TValue data);
        Task<TValue> readFile<TValue>(string filePath);
    }
    public class FileJsonHandlerImpl : FileJsonHandler
    {
        public async Task<TValue> readFile<TValue>(string filePath)
        {

            using FileStream openStream = File.OpenRead(filePath);
            TValue? value = await JsonSerializer.DeserializeAsync<TValue>(openStream);
            await openStream.DisposeAsync();
            return value;
        }

        public async Task wirteFile<TValue>(string filePath, TValue data)
        {
            using FileStream createStream = File.Create(filePath);
            await JsonSerializer.SerializeAsync(createStream, data);
            await createStream.DisposeAsync();
            Console.WriteLine(File.ReadAllText(filePath));
        }
    }
}
