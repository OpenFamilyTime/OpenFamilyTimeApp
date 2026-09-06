using OpenFamilyTime.Core.Models;

namespace OpenFamilyTime.Core.Providers;

public class MockProvider : IMediaProvider
{
    public string Id => "mock";
    public string Name => "Mock";

    public Task<List<SearchItem>> SearchAsync(string q, CancellationToken ct = default)
        => Task.FromResult(Enumerable.Range(1, 5)
            .Select(i => new SearchItem($"id{i}", $"{q} Movie {i}", null, MediaType.Movie, "mock"))
            .ToList());

    public Task<MediaDetails> LoadDetailsAsync(string id, CancellationToken ct = default)
        => Task.FromResult(new MediaDetails(id, $"Title {id}", "Plot...", null, MediaType.Movie, []));

    public Task<List<VideoSource>> LoadSourcesAsync(string id, string? episodeId = null, CancellationToken ct = default)
        => Task.FromResult(new List<VideoSource>{ new("https://test.m3u8","1080p",true)});
}
