namespace Day1
{
    public static class Utils
    {
        public static async Task<string> ReadInputFileAsync()
        {
            try
            {
                using StreamReader reader = new("../../../input.txt");
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
}