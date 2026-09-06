using System.Collections.ObjectModel;
using OpenFamilyTime.Core.Providers;

namespace OpenFamilyTime.ViewModels;

public partial class SettingsViewModel : ViewModelBase
{
    public ObservableCollection<IMediaProvider> Providers { get; } = new([new MockProvider()]);
}