//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Policy;
//using System.Text;
//using System.Threading.Tasks;
//using Autodesk.Revit.Attributes;
//using Autodesk.Revit.DB;
//using Autodesk.Revit.UI;

//namespace STD.Windows.Service
//{
//    [Transaction(TransactionMode.Manual)]
//    public class RevitApplication : IExternalApplication
//    {
//        public Result OnShutdown(UIControlledApplication application)
//        {
//            TaskDialog.Show("start", "starts");
//            return Result.Succeeded;
//        }

//        public Result OnStartup(UIControlledApplication application)
//        {
//            RibbonPanel ribbonPanel = application.CreateRibbonPanel("ribbonPanel");
//            PushButton pushButton = ribbonPanel.AddItem(new PushButtonData("RevitApplication", "RevitApplication", @"E:\codes\HC.Revit\HC.Revit\HC.Revit.Service\bin\Debug\HC.Revit.Service.dll", "HC.Revit.Service.RevitApplication")) as PushButton;
//            //BitmapImage largeImage = new BitmapImage(new Uri(@"time.jpg"));
//            //pushButton.LargeImage = largeImage;
//            //TaskDialog.Show("app", "application");
//            TaskDialog.Show("end", "ends");
//            return Result.Succeeded;
//        }
//    }
//}
