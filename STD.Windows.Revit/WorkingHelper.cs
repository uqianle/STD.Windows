using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD.Windows.Revit
{
    public class WorkingHelper
    {
        /// <summary>
        /// 向工作集中新增元素
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="eles"></param>
        public static void AddElementsToWorkSet(Document doc, List<Element> eles)
        {
            //if (doc.IsWorkshared)
            if (true)
            {
                var workSet = GetWorkSet(doc);
                if (null != workSet)
                {
                    var workSetId = workSet.Id.IntegerValue;
                    using (Transaction tran = new Transaction(doc, "[ToolSet] Add Elemens To WorkSet"))
                    {
                        tran.Start();
                        foreach (var ele in eles)
                        {
                            Parameter pms = ele.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM);
                            if (null != pms)
                            {
                                pms.Set(workSetId);
                            }
                        }
                        tran.Commit();
                    }
                }
            }
        }

        private static Workset GetWorkSet(Document doc)
        {
            Workset workSet = null;
            if (doc.IsWorkshared)
            {
                string workSetName = "WorkSetName";
                if (WorksetTable.IsWorksetNameUnique(doc, workSetName))
                {
                    using (Transaction tran = new Transaction(doc, "[ToolSet] Create Work Set For ToolSet"))
                    {
                        tran.Start();
                        workSet = Workset.Create(doc, workSetName);
                        tran.Commit();
                    }
                }
                else
                {
                    IList<Workset> list = new FilteredWorksetCollector(doc).OfKind(WorksetKind.UserWorkset).ToWorksets();
                    foreach (var item in list)
                    {
                        if (item.Name.Contains(workSetName))
                        {
                            return item;
                        }
                    }
                }
            }
            return workSet;
        }
        /// <summary>
        /// 创建工作集
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public Workset CreateWorkset(Document doc)
        {
            Workset workset = null;
            if (doc.IsWorkshared)
            {
                string worksetName = "New Workset";
                if (WorksetTable.IsWorksetNameUnique(doc, worksetName))
                {
                    using (Transaction worksetTransaction = new Transaction(doc, "Set preview view id"))
                    {
                        worksetTransaction.Start();
                        workset = Workset.Create(doc, worksetName);
                        worksetTransaction.Commit();
                    }

                }
            }
            return workset;
        }
    }
}
