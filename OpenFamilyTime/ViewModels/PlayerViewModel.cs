using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LibVLCSharp.Shared;
using OpenFamilyTime.Core.Models;

namespace OpenFamilyTime.ViewModels;

public partial class PlayerViewModel : ViewModelBase
{
    public LibVLC LibVLC { get; } = new();
    [ObservableProperty] public partial MediaPlayer? Player { get; set; }
    [ObservableProperty] public partial VideoSource? Current { get; set; }
    [ObservableProperty] public partial string Status { get; set; } = "No source selected";

    public PlayerViewModel()
    {
        Player = new MediaPlayer(LibVLC);
    }

    partial void OnCurrentChanged(VideoSource? value)
    {
        if (value == null)
        {
            Status = "No Source";
            return;
        }

        Status = $"Playing: {value.Quality}";
        Player?.Play(new Media(LibVLC, value.Url, FromType.FromLocation));
    }
    [RelayCommand]
    void Stop() => Player?.Stop();
    [RelayCommand]
    void Pause() => Player?.Pause();
}