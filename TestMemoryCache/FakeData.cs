namespace TestMemoryCache
{
    public static class FakeData
    {
        public static string Get(string key)
        {
            return $"content of {key}";
        }
    }
}
