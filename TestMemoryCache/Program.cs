using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;
using TestMemoryCache;

var services = new ServiceCollection();
services.AddMemoryCache();

var serviceProvider = services.BuildServiceProvider();
var memoryCache = serviceProvider.GetService<IMemoryCache>();
if (memoryCache is null) return;

// value 1
foreach (var key in new List<string> { "key1", "key1", "key2" })
{
    if (!memoryCache.TryGetValue(key, out string? content))
    {
        content = FakeData.Get(key);
        memoryCache.Set(key, content, TimeSpan.FromMinutes(2));
        Console.WriteLine($"{content} form db");
    }
    else
    {
        Console.WriteLine($"{content} form cache");
    }
}