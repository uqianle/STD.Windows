//using System;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Autodesk.Revit.Attributes;
//using Autodesk.Revit.DB;
//using Autodesk.Revit.UI;

//namespace STD.Windows.Service
//{
//    [Transaction(TransactionMode.Manual)]
//    class Command1 : IExternalCommand
//    {
//        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
//        {
//            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
//            Document doc = uiDoc.Document;
//            //结构柱过滤器
//            FilteredElementCollector elementCollector = new FilteredElementCollector(doc);
//            ElementCategoryFilter categoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_AdaptivePoints_HiddenLines);
//            ElementClassFilter classFilter = new ElementClassFilter(typeof(FamilyInstance));
//            elementCollector.WherePasses(categoryFilter).WherePasses(classFilter);

//            //将过滤得到的图元转换为elementId
//            IList<ElementId> list = new List<ElementId>();
//            foreach (var ele in elementCollector)
//            {
//                list.Add(ele.Id);
//            }
//            uiDoc.Selection.SetElementIds(list);
//            return Result.Succeeded;
//        }
//    }
//}
