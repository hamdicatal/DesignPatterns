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
