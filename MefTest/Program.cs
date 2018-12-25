using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace MefTest
{

    //public interface IMyplugin
    //{
    //    string HelloWorld();
    //    string Manifest();
    //}
    class Program
    {

        private CompositionContainer _container;
        //
        //MyPlugin namespace 
        //
        [Import(typeof(MyPlugin.IMyplugin))]
        private MyPlugin.IMyplugin myplugin;


        private Program()
        {
            TestPlugin();
        }
        private void TestPlugin()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            catalog.Catalogs.Add(new DirectoryCatalog(@"plugins"));

            _container = new CompositionContainer(catalog);

            //Fill the imports of this object
            try
            {
                this._container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
            myplugin.Manifest();

        }
        static void Main(string[] args)
        {
            Program p = new Program();

            p.myplugin.Manifest();

            //myplugin.Manifest();

            Console.WriteLine("Plugin Test Over");
            Console.Write("请按任意键继续...");
            Console.ReadKey();
        }
    }
}
