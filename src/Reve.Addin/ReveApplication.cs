using System.Reflection;
using Autodesk.Revit.UI;
using Reve.Addin.Commands;

namespace Reve.Addin;

public class ReveApplication : IExternalApplication
{
    private const string RibbonTabName = "Reve";
    private const string RibbonPanelName = "Conduit";

    public Result OnStartup(UIControlledApplication application)
    {
        application.CreateRibbonTab(RibbonTabName);
        var ribbonPanel = application.CreateRibbonPanel(RibbonTabName, RibbonPanelName);

        var listConduitsButtonData = new PushButtonData(
            "ListConduits",
            "List Conduits",
            Assembly.GetExecutingAssembly().Location,
            typeof(ListConduitsCommand).FullName);

        ribbonPanel.AddItem(listConduitsButtonData);

        return Result.Succeeded;
    }

    public Result OnShutdown(UIControlledApplication application)
    {
        return Result.Succeeded;
    }
}
