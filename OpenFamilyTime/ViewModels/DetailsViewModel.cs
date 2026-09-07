using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using OpenFamilyTime.Core.Models;
using OpenFamilyTime.Core.Providers;
using OpenFamilyTime.Core.Services;

namespace OpenFamilyTime.ViewModels;
public partial class DetailsViewModel : ViewModelBase
{
    private readonly IMediaProvider _provider = new MockProvider();
    [ObservableProperty] public partial MediaDetails? Details { get; set; }
    [ObservableProperty] public partial ObservableCollection<VideoSource> Sources { get; set; } = [];
    [ObservableProperty] public partial VideoSource? SelectedSource { get; set; }
    [ObservableProperty] public partial string BookmarkStatus { get; set; } = "";

    [RelayCommand]
    public async Task LoadAsync(string id)
    {
        Details = await _provider.LoadDetailsAsync(id);
        var s = await _provider.LoadSourcesAsync(id);
        Sources = new(new(s));
    }

    [RelayCommand]
    void BookMark()
    {
        if (Details == null)
        {
            BookmarkStatus = "Nothing to save";
            return;
        }

        var item = new SearchItem(Details.Id, Details.Title, Details.PosterUrl, Details.Type, "mock");
        LibraryService.Instance.Add(item);
        BookmarkStatus = $"Saved {Details.Title}";
    }
}

