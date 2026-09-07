using System.Collections.ObjectModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OpenFamilyTime.Core.Models;
using OpenFamilyTime.Core.Services;

namespace OpenFamilyTime.ViewModels;

public partial class LibraryViewModel : ViewModelBase
{
    [ObservableProperty] public partial ObservableCollection<SearchItem> Bookmarks { get; set; } = [];

    public LibraryViewModel()
    {
        LibraryService.Instance.Load();
        Refresh();
    }

    [RelayCommand]
    void Refresh()
    {
        Bookmarks = new ObservableCollection<SearchItem>(LibraryService.Instance.Bookmarks);
    }

    [RelayCommand]
    void Remove(SearchItem item)
    {
        Refresh();
    }
}