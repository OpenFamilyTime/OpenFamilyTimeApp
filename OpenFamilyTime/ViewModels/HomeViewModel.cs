using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using OpenFamilyTime.Core.Models;
using OpenFamilyTime.Core.Providers;

namespace OpenFamilyTime.ViewModels;

public partial class HomeViewModel : ViewModelBase
{
    private readonly IMediaProvider _provider = new MockProvider();
    [ObservableProperty] public partial ObservableCollection<SearchItem> Items { get; set; } = [];
    [ObservableProperty] public partial string Query { get; set; } = "Avengers";
    [ObservableProperty] public partial SearchItem? Selected { get; set; }

    [RelayCommand]
    public async Task LoadAsync()
    {
        var res = await _provider.SearchAsync(Query);
        Items = new ObservableCollection<SearchItem>(res);
    }
}