using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;

namespace Reve.RevitServices;

public class ConduitCollectorService(Document document)
{
    public IReadOnlyList<Conduit> GetAllConduitsInDocument()
    {
        return new FilteredElementCollector(document)
            .OfClass(typeof(Conduit))
            .Cast<Conduit>()
            .ToList();
    }
}
