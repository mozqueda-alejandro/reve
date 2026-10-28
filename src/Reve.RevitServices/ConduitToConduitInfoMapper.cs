using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Reve.Core;

namespace Reve.RevitServices;

public static class ConduitToConduitInfoMapper
{
    private const double InchesPerFoot = 12.0;

    public static ConduitInfo MapToConduitInfo(Conduit conduit)
    {
        var conduitType = conduit.Document.GetElement(conduit.GetTypeId());
        var diameterInFeet = conduit.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM)?.AsDouble() ?? 0.0;
        var lengthInFeet = conduit.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH)?.AsDouble() ?? 0.0;

        return new ConduitInfo(
            conduit.Id.Value,
            conduitType?.Name ?? string.Empty,
            diameterInFeet * InchesPerFoot,
            lengthInFeet);
    }
}
