using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OpenFamilyTime.Core.Models;

namespace OpenFamilyTime.ViewModels;

public partial class PlayerViewModel : ViewModelBase
{
    [ObservableProperty] public partial VideoSource? Current { get; set; }
    [ObservableProperty] public partial string Status { get; set; } = "No source selected";

    partial void OnCurrentChanged(VideoSource? v) =>
        Status = v == null ? "No source selected" : $"Ready: {v.Quality} - {v.Url}";

    [RelayCommand]
    void OpenExternal()
    {
        if(Current == null) return;
        Process.Start(new ProcessStartInfo(Current.Url){ UseShellExecute = true});
    }
}