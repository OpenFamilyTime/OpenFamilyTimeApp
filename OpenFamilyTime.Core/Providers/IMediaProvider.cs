using OpenFamilyTime.Core.Models;
namespace OpenFamilyTime.Core.Providers;

public interface IMediaProvider
{
    string Id { get;  }  // ex: "vidsrc"
    string Name { get;  }  // ex: "VidSrc"
    Task<List<SearchItem>> SearchAsync(string query, CancellationToken ct = default);
    Task<MediaDetails> LoadDetailsAsync(string id, CancellationToken ct = default);
    Task<List<VideoSource>> LoadSourcesAsync(string id, string? episodeId = null, CancellationToken ct = default);
}

