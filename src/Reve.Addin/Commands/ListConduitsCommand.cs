using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Reve.RevitServices;
using Reve.UI;

namespace Reve.Addin.Commands;

[Transaction(TransactionMode.Manual)]
public class ListConduitsCommand : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        var document = commandData.Application.ActiveUIDocument.Document;

        var conduitInfos = new ConduitCollectorService(document)
            .GetAllConduitsInDocument()
            .Select(ConduitToConduitInfoMapper.MapToConduitInfo)
            .ToList();

        var conduitListWindow = new ConduitListWindow
        {
            DataContext = new ConduitListViewModel(conduitInfos)
        };
        conduitListWindow.ShowDialog();

        return Result.Succeeded;
    }
}
