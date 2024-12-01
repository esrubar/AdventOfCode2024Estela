namespace Utils;

public static class Utils
{
    public static async Task<string> ReadInputFileAsync(string path)
    {
        try
        {
            using StreamReader reader = new(path);
            return await reader.ReadToEndAsync();
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
            throw new IOException();
        }
    }
}