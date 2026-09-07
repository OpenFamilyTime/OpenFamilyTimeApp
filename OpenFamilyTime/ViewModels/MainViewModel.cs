using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OpenFamilyTime.Core.Models;

namespace OpenFamilyTime.ViewModels;

public partial class MainViewModel : ViewModelBase
{
     public HomeViewModel Home { get; } = new();
     public DetailsViewModel Details { get; } = new();
     public PlayerViewModel Player { get; } = new();
     public LibraryViewModel  Library { get; } = new();
     public SettingsViewModel Settings { get; } = new();
     [ObservableProperty] public partial object CurrentPage { get; set; }
     public MainViewModel()
     {
          CurrentPage = Home;
          Home.PropertyChanged += (s, e) =>
          {
               if (e.PropertyName == nameof(Home.Selected) && Home.Selected != null)
               {
                    _ = Details.LoadAsync(Home.Selected.Id);
                    CurrentPage = Details;
               }
          };
          Details.PropertyChanged += (s, e) =>
          {
               if (e.PropertyName == nameof(Details.SelectedSource) && Details.SelectedSource != null)
               {
                    Player.Current = Details.SelectedSource;
                    CurrentPage = Player;
               }
          };
     }
     [RelayCommand] void GoHome() => CurrentPage = Home;
     [RelayCommand] void GoLibrary() => CurrentPage = Library;
     [RelayCommand] void GoPlayer() => CurrentPage = Player;
     [RelayCommand] void GoSettings() => CurrentPage = Settings;
}
