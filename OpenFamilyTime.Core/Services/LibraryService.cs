using System.Text.Json;
using OpenFamilyTime.Core.Models;

namespace OpenFamilyTime.Core.Services;

public class LibraryService
{
    public static LibraryService Instance { get; } = new LibraryService();
    readonly string _path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OpenFamilyTime", "library.json");
    public List<SearchItem> Bookmarks { get; private set; } = [];

    public void Load()
    {
        if (File.Exists(_path)) Bookmarks = JsonSerializer.Deserialize<List<SearchItem>>(File.ReadAllText(_path)) ?? [];
    }

    public void Add(SearchItem i)
    {
        if (!Bookmarks.Any(b => b.Id == i.Id))
        {
            Bookmarks.Add(i);
            Save();
        }
    }

    void Save()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(_path)!);
        File.WriteAllText(_path, JsonSerializer.Serialize(Bookmarks));
    }
}