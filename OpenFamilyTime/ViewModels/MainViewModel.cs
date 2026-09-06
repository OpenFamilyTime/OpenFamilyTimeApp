using CommunityToolkit.Mvvm.ComponentModel;
using OpenFamilyTime.Core.Models;

namespace OpenFamilyTime.ViewModels;

public partial class MainViewModel : ViewModelBase
{
     public HomeViewModel Home { get; } = new();
     public DetailsViewModel Details { get; } = new();
     public PlayerViewModel Player { get; } = new();

     public MainViewModel()
     {
          Home.PropertyChanged += (s, e) =>
          {
               if (e.PropertyName == nameof(Home.Selected) && Home.Selected != null)
                    _ = Details.LoadAsync(Home.Selected.Id);
          };
          Details.PropertyChanged += (s, e) =>
          {
               if (e.PropertyName == nameof(Details.SelectedSource))
               {
                    Player.Current = Details.SelectedSource;
               }
          };
     }
}
