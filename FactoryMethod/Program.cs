using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager manager = new CustomerManager();
            manager.Save();
            Console.ReadLine();
        }
    }

    public class LoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new DemoLogger();
        }
    }

    public interface ILoggerFactory
    {

    }

    public interface ILogger
    {
        void Log();
    }

    public class DemoLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with DemoLogger!");
        }

    }

    public class CustomerManager
    {
        public void Save()
        {
            Console.WriteLine("Saved!");
            //ILogger logger = new DemoLogger(); //DemoLogger class'ına bağımlı olduk. Yanlış kullanım. new yaparken dikkat edilmeli. Bunun yerine factory ile üretilebilir.
            ILogger logger = new LoggerFactory().CreateLogger(); //Factory tasarım kalıbına uygun ideal kullanım.

        }
    }
}
