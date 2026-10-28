using Reve.Core;
using Reve.UI;

namespace Reve.Tests;

public class ConduitListViewModelTests
{
    [Test]
    public async Task TotalLengthInFeet_SumsLengthOfAllConduits()
    {
        var conduitInfos = new[]
        {
            new ConduitInfo(1, "EMT", 0.75, 10.0),
            new ConduitInfo(2, "EMT", 1.0, 5.5),
            new ConduitInfo(3, "Rigid", 2.0, 4.5)
        };

        var conduitListViewModel = new ConduitListViewModel(conduitInfos);

        await Assert.That(conduitListViewModel.TotalLengthInFeet).IsEqualTo(20.0);
    }
}
