using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace MyPlugin
{
    public interface IMyplugin
    {
        string HelloWorld();
        string Manifest();
    }
    [Export(typeof(IMyplugin))]
    public class MyPluginImpl : IMyplugin
    {
        public string HelloWorld()
        {
            return "hello world!";
        }

        public string Manifest()
        {
            string tmp = "hello, I am Plugin test";
            Console.WriteLine(tmp);
            return tmp;
        }
    }
}
