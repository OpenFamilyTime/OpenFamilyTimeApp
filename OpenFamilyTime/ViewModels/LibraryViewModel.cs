using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using OpenFamilyTime.Core.Models;

namespace OpenFamilyTime.ViewModels;

public partial class LibraryViewModel : ViewModelBase
{
    [ObservableProperty] public partial ObservableCollection<SearchItem> Bookmarks { get; set; } = [];
}