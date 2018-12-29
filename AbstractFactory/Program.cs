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

        }
    }

    //Logging ve Caching olmak üzere ihtiyaçlarımıza uygun iki temel soyut nesne oluşturduk. Bu iki nesneyi inherit eden, sayısız nesne oluşturabiliriz.

    //Yeni bir loglama yöntemi eklediğimizde sistem bozulmayacak. 
    public abstract class Logging
    {
        public abstract void Log(string message);
    }

    public class DemoLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with DemoLogger!");
        }
    }

    public class OtherLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with OtherLogger!");
        }
    }

    //Yeni bir caching yöntemi eklediğimizde sistem bozulmayacak. 
    public abstract class Caching
    {
        public abstract void Cache(string data);
    }

    public class DemoCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with DemoCache!");
        }
    }

    public class OtherCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with OtherCache!");
        }
    }

}
