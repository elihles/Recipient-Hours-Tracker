using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
     class Recipient :IComparable
    {
        private string name;
        private int hrs;

        public Recipient(string name)
        {
            this.name = name;
            this.hrs = 90;
        }

        public Recipient(string name, int hrs)
        {
            this.name = name;
            this.hrs = hrs;
        }

        public string Getname()
        {
            return name;
        }
        public int Gethours()
        {
            return hrs;
        }

        public void SetHours(int H) {
            hrs = H;
        }
        public void DecreaseHours(int H)
        {
            if (H > hrs)
            {
                Console.WriteLine("Error: Worked hours exceed the available hours.");
            }
            else
            {
                hrs -= H;
                Console.WriteLine("Hours decreased successfully. Remaining hours: " + hrs);
            }
        }


        public void DisplayRecipient()
        {
            //Console.WriteLine("Recipient details :");
            Console.WriteLine();
            Console.WriteLine("Name : {0} , Hours left :{1}", name, hrs);
        }
        public int CompareTo(object obj)
        {
            int returnValue;
            Recipient temp = (Recipient)obj;

            if (string.Compare(this.name, temp.name) > 0)
                returnValue = 1;
            else if (string.Compare(this.name, temp.name) < 0)
                returnValue = -1;
            else
                returnValue = 0;

            return returnValue;
        }

    }
}
