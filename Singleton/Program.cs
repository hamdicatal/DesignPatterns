using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateSingleton();
            customerManager.Save();
        }

        class CustomerManager
        {
            private static CustomerManager _customerManager;

            private CustomerManager()
            {

            }

            // CustomerManager nesnesinin örneğinden sadece bir kez static olarak üretilmesini sağlayan metodumuz.
            public static CustomerManager CreateSingleton()
            {
                // CustomerManager daha önce oluşturulmamışsa ilk ve son örneği oluşturur.
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }

                return _customerManager;
            }

            public void Save()
            {
                Console.WriteLine("Saved!");
                Console.ReadLine();
            }
        }
    }
}
