namespace OpenFamilyTime.Core.Models;
public record MediaDetails(string Id, string Title, string? Plot, string? PosterUrl, MediaType Type, List<Episode> Episodes);