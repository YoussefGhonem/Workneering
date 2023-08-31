namespace Workneering.Base.Application.Common.RedisCache.models;
public class RedisCachingOptions
{
    public bool Enabled { get; set; }
    public string? ConnectionString { get; set; }
}
