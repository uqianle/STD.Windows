using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using STD.Windows.WPF;

namespace STD.Windows.Revit
{
    [Transaction(TransactionMode.Manual)]
    public class Class1 : IExternalCommand

    {
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit, ref string message, ElementSet elements)
        {
            TaskDialog.Show("std", "stdstd");
            return Result.Succeeded;
        }

    }

}
