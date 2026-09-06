using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using OpenFamilyTime.Core.Models;
using OpenFamilyTime.Core.Providers;

namespace OpenFamilyTime.ViewModels;
public partial class DetailsViewModel : ViewModelBase
{
    private readonly IMediaProvider _provider = new MockProvider();
    [ObservableProperty] public partial MediaDetails? Details { get; set; }
    [ObservableProperty] public partial ObservableCollection<VideoSource> Sources { get; set; } = [];

    [RelayCommand]
    public async Task LoadAsync(string id)
    {
        Details = await _provider.LoadDetailsAsync(id);
        var s = await _provider.LoadSourcesAsync(id);
        Sources = new(new(s));
    }
}

