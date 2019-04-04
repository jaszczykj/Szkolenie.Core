using System;

namespace SoftHard.Papirus.Models
{
    public class Vip : Customer
    {
        public new void Print()
        {
            base.Print();
        }
    }

    public class Customer : Base
    {

        public int Id { get; set; }
        
        public string Name { get; set; }
        public bool IsRemoved { get; set; }


        public override void Print()
        {
            base.Print();
        }
    }

    public abstract class Base
    {
        protected Base()
        {

        }

        public Base(int x)
        {

        }

        public virtual void Print()
        {
            Console.WriteLine("Print");
        }
    }
}
