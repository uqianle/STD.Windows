using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD.Windows.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var getiis = Test.GetIISWebVirtualDirs();

        }
    }
    public class Test
    {
        public static Dictionary<string, string> GetIISWebVirtualDirs()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            try
            {
                int num = 1;
                //logger.Info("------------------------获取IIS下的web站点信息：开始------------------------");
                foreach (DirectoryEntry entry in new DirectoryEntry("IIS://localhost/w3svc").Children)
                {
                    if (entry.SchemaClassName.Equals("IIsWebServer", StringComparison.OrdinalIgnoreCase))
                    {
                        //logger.Info("Name:" + entry.Name);
                        //logger.Info("Path:" + GetROOTWebsitePhysicalPath(entry));
                        //logger.Info("ServerBindings:" + entry.Properties["ServerBindings"].Value);
                        //logger.Info("");
                        foreach (DirectoryEntry entry2 in new DirectoryEntry(entry.Path + "/ROOT").Children)
                        {
                            if (entry2.SchemaClassName.Equals("IIsWebVirtualDir", StringComparison.OrdinalIgnoreCase))
                            {
                                string name = entry2.Name;
                                string str2 = (string)entry2.Properties["Path"].Value;
                                if (!dictionary.ContainsKey(name))
                                {
                                    dictionary.Add(name, str2);
                                }
                                //logger.Info("SchemaClassName:" + entry2.SchemaClassName);
                                //logger.Info("Name:" + name);
                                //logger.Info("Path:" + str2);
                                //logger.Info("");
                            }
                        }
                        int num2 = Convert.ToInt32(entry.Name);
                        if (num2 >= num)
                        {
                            num = num2 + 1;
                        }
                    }
                }
                //logger.Info("------------------------获取IIS下的web站点信息：结束------------------------");
            }
            catch (Exception exception)
            {
                //logger.Error("发生异常：", exception);
            }
            return dictionary;
        }
    }
}
