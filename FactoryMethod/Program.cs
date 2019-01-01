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
            //İhtiyaca göre kullanılacak factory değiştirilebilir. Bu değişiklik kodda hiçbir yeri etkilemez.
            //CustomerManager manager = new CustomerManager(new LoggerFactory2());
            CustomerManager manager = new CustomerManager(new LoggerFactory());
            manager.Save();
            Console.ReadLine();
        }
    }

    //Class oluştururken bir soyut class veya interface mutlaka yazılmalı. Yeni bir factory oluşturmak istediğimizde bağımlılıklardan dolayı sorun yaşayabiliriz.
    public class LoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Duruma göre farklı log'lama işlemleri yapılabilir.
            return new DemoLogger();
        }
    }
    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Duruma göre farklı log'lama işlemleri yapılabilir.
            return new DemoLogger2();
        }
    }

    public interface ILoggerFactory
    {
        //Bütün factory'lerde implemente edilmek zorunda.
        ILogger CreateLogger();
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

    public class DemoLogger2: ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with DemoLogger2!");
        }
    }

    public class CustomerManager
    {
        //Herhangi bir factory'e bağımlı kalmadan, injection işlemi yapılabilir.
        ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save()
        {
            Console.WriteLine("Saved!");
            //ILogger logger = new DemoLogger(); //DemoLogger class'ına bağımlı olduk. Yanlış kullanım. Bunun yerine factory metodu ile üretilebilir.
            ILogger logger = _loggerFactory.CreateLogger(); //Factory tasarım kalıbına uygun ideal kullanım.
            logger.Log();
        }
    }
}
