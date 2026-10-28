using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace Reve.Addin;

[Transaction(TransactionMode.Manual)] 
public class Class1 : IExternalCommand 
{ 
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements) 
    { 
        //Get application and document objects 
        var uiapp = commandData.Application; 
        var doc = uiapp.ActiveUIDocument.Document; 
 
        //Define a reference Object to accept the pick result 
        Reference pickedref; 
 
        //Pick a group 
        var sel = uiapp.ActiveUIDocument.Selection; 
        pickedref = sel.PickObject(ObjectType.Element, "Please select a group"); 
 
        var elem = doc.GetElement(pickedref); 
        var group = elem as Group; 
 
        //Pick point 
        var point = sel.PickPoint("Please pick a point to place group"); 
 
        //Place the group 
        var trans = new Transaction(doc); 
        trans.Start("Lab"); 
        doc.Create.PlaceGroup(point, group?.GroupType); 
        trans.Commit(); 
 
        return Result.Succeeded; 
    } 
}