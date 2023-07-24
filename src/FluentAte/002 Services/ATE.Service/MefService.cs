using ATE.Common.Contracts;
using ATE.Common.Test;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Service
{
    public class MefService : IAppService
    {

        // service
        public string Id => "Core.MefService";

        public string ServiceName => "插件服务";

        public bool IsRunning { get; private set; } = false;

        public string StateString { get; private set; } = "default";

        // mef
        public CompositionContainer container;
        private AggregateCatalog catalog;

        public string ErrorString { get; set; } = "";

        public MefService()
        {
            catalog = new AggregateCatalog();
            Load();
        }

        public bool Load()
        {
            try
            {
                var c1 = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());
                var c2 = new DirectoryCatalog($"{Directory.GetCurrentDirectory()}\\packages", "ATE.Package*.dll");
                catalog = new AggregateCatalog(c1, c2);
                container = new CompositionContainer(catalog);
                var a = container.GetExports<IDevice, IDictionary<string, object>>();
                var c = container.GetExports<IDeviceGroup, IDictionary<string, object>>();
                foreach(var e in a)
                {
                    var b = e.Metadata;
                    Console.WriteLine(e.ToString());
                }
            }
            catch (Exception ex)
            {
                ErrorString = "Mef加载失败" + ex.Message;
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }
   
        public List<Lazy<T>> GetExports<T>(T t) {
            return container.GetExports<T>().ToList();
        }
    
    }
}
