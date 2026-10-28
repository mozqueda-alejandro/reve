using System.Collections.ObjectModel;
using System.ComponentModel;
using Reve.Core;

namespace Reve.UI;

public class ConduitListViewModel : INotifyPropertyChanged
{
    public ConduitListViewModel(IEnumerable<ConduitInfo> conduitInfos)
    {
        Conduits = new ObservableCollection<ConduitInfo>(conduitInfos);
        Conduits.CollectionChanged += (_, _) => OnPropertyChanged(nameof(TotalLengthInFeet));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<ConduitInfo> Conduits { get; }

    public double TotalLengthInFeet => Conduits.Sum(conduitInfo => conduitInfo.LengthInFeet);

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
