using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dependency injection containerların kullanılması daha uygun olur.
            //ProductManager productManager = new ProductManager(new Factory1());
            ProductManager productManager = new ProductManager(new Factory2());
            productManager.GetAll();
            Console.ReadLine();
        }
    }

    //Logging ve Caching olmak üzere ihtiyaçlarımıza uygun iki temel soyut nesne oluşturduk. Bu iki nesneyi inherit eden, sayısız nesne oluşturabiliriz.

    //Duruma göre Logging ve Caching teknikleri arasında seçim yapacak factory'e ihtiyacımız var. Bu da bizim "Abstract Factory" nesnemiz olacak.

    //Yeni bir loglama yöntemi eklediğimizde sistem bozulmayacak. 
    public abstract class Logging
    {
        public abstract void Log();
    }

    public class DemoLogger : Logging
    {
        public override void Log()
        {
            Console.WriteLine("Logged with DemoLogger!");
        }
    }

    public class OtherLogger : Logging
    {
        public override void Log()
        {
            Console.WriteLine("Logged with OtherLogger!");
        }
    }

    //Yeni bir caching yöntemi eklediğimizde sistem bozulmayacak. 
    public abstract class Caching
    {
        public abstract void Cache();
    }

    public class DemoCache : Caching
    {
        public override void Cache()
        {
            Console.WriteLine("Cached with DemoCache!");
        }
    }

    public class OtherCache : Caching
    {
        public override void Cache()
        {
            Console.WriteLine("Cached with OtherCache!");
        }
    }

    //Abstract Factory. Ayrıca bu soyut class'dan yeni factory'ler üretilebilir.
    public abstract class CrossCuttingConcernsFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }

    public class Factory1 : CrossCuttingConcernsFactory //inheritance
    {
        public override Caching CreateCaching()
        {
            return new DemoCache();
        }

        public override Logging CreateLogger()
        {
            return new DemoLogger();
        }
    }

    //İş süreçlerine ve ihtiyaçlara göre yeni factory'ler üretilebilir. 
    public class Factory2 : CrossCuttingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new OtherCache();
        }

        public override Logging CreateLogger()
        {
            return new OtherLogger();
        }
    }

    //Bu factory'leri kullanan bir client veya iş katmanı gerekir.
    public class ProductManager
    {
        //Dependency injection işlemi;
        private CrossCuttingConcernsFactory _crossCuttingConcernsFactory;
        private Logging _logging;
        private Caching _caching;

        public ProductManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
        {
            _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
            _logging = crossCuttingConcernsFactory.CreateLogger();
            _caching = crossCuttingConcernsFactory.CreateCaching();
        }

        public void GetAll()
        {
            _logging.Log();
            _caching.Cache();
            Console.WriteLine("Products listed!");
        }
    }
}
