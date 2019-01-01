using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Nesne üretimi maliyetini minimize etmeyi amaçlar. Elimizde bir temel nesne varsa, bu nesneden bir prototip oluştururuz ve yeni nesne klonlama işlemini prototip üzerinden yaparız.

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer
            {
                FirstName = "Ali",
                LastName = "Can",
                City = "Ankara",
                Id = 1
            };
            Console.WriteLine("Customer1: " + customer.FirstName);

            //İlk oluşturduğumuz customer nesnesinden klonladık.
            Customer customer2 = (Customer)customer.Clone();
            Console.WriteLine("Customer2: " + customer2.FirstName);

            customer2.FirstName = "Hasan";
            Console.WriteLine("Customer2: " + customer2.FirstName);
            Console.ReadLine();
        }
    }

    //Prototip nesne oluşturulur.
    public abstract class Person
    {
        //Klonlama metodu prototip içerisinde bulunur.
        public abstract Person Clone();

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }

        public override Person Clone()
        {
            //Klonlama özelliğini yapabileceğimiz bir metod; MemberwiseClone()
            return (Person)MemberwiseClone();
        }
    }

    public class Employee : Person
    {
        public decimal Salary { get; set; }

        public override Person Clone()
        {
            //Klonlama özelliğini yapabileceğimiz bir metod; MemberwiseClone()
            return (Person)MemberwiseClone();
        }
    }
}