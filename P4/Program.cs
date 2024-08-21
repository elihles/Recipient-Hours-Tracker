using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System;
using System.Collections;

namespace Task_2
{
    internal class Program
    {
        const int size = 10;
        static void Main(string[] args)
        {
            int choice = 0;
            int nrel = 0;
            Recipient[] recipients = new Recipient[size];

            ReadData(recipients, ref nrel);


            while (choice != 6)
            {
                DisplayOptions(ref choice);

                switch (choice)
                {
                    case 1:
                        AddRecipient(recipients, ref nrel);
                        break;
                    case 2:
                        AllocateHours(recipients, ref nrel);
                        break;
                    case 3:
                        RecordHours(recipients, ref nrel);
                        break;
                    case 4:
                        SortList(recipients, nrel);
                        break;
                    case 5:
                        DisplayList(recipients, nrel);
                        break;
                    case 6:
                        Console.WriteLine("Goodbye");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.ReadLine(); // Wait for the user to press Enter
            

            // Now write the data to file before exiting
            WriteData(recipients, ref nrel);
        }
    

    }
    private static void DisplayOptions(ref int choice)
            {
                Console.WriteLine("Indicate your choice from the following options,6 to quit");
                Console.WriteLine("1. Add a recipient.");
                Console.WriteLine("2. Allocate hours for a specific recipient.");
                Console.WriteLine("3. Record the hours worked and update hours for  a specific recipient");
               Console.WriteLine("4.Sort the list of recipient");
                Console.WriteLine("5. Display the list of recipients");
                Console.WriteLine("6. Quit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }
        public static void AddRecipient(Recipient[] recipients, ref int nrel)
        {
            if (nrel >= size)
            {
                Console.WriteLine("List is full. Cannot add more sales representatives.");
            }
            else
            {
                Console.Write("Enter the name of the recipient: ");
                string name = Console.ReadLine();

                recipients[nrel] = new Recipient(name);
                nrel++;

                Console.WriteLine("Name added successfully.");
            }
        }
        static int FindRecipient(Recipient[] recipients, int nrel, String wanted)
        {
            for (int i = 0; i < recipients.Length; i++)
            {
                if (wanted == recipients[i].Getname())
                { 
                    return i;
                }


            }

            return -1;
        }
        public static void AllocateHours(Recipient[] recipients, ref int nrel)
        {
            Console.Write("Enter the name of the recipient to allocate hours to:");
            string name= Console.ReadLine();
            int pos=FindRecipient(recipients, nrel, name);
            if(pos == -1)
            {
                Console.WriteLine("Recipient not found");
            }
            else
            {
                Console.Write("Enter the number of hours to allocate:");
                int hours=int.Parse(Console.ReadLine());
                recipients[pos].SetHours(hours);
            }
        }
        public static void RecordHours(Recipient[] recipients, ref int nrel)
        {
            Console.Write("Enter the name of the recipient to allocate hours to:");
            string name = Console.ReadLine();
            int pos = FindRecipient(recipients, nrel, name);
            if (pos == -1)
            {
                Console.WriteLine("Recipient not found");
            }
            else
            {
                Console.Write("Enter the number of hours to allocate:");
                int hours = int.Parse(Console.ReadLine());
                recipients[pos].DecreaseHours(hours);

            }
        }
            public static void SortList(Recipient[]recipients, int nrel)
            {
                if (nrel == 0)
                {
                    Console.WriteLine("List is empty.");
                }
                else
                {
                    // Sort the array based on the CompareTo method
                    Array.Sort(recipients, 0, nrel); // Sort only the filled portion of the array

                    // Display the sorted list
                    Console.WriteLine("Sorted list :");
                    for (int i = 0; i < nrel; i++)
                    {
                        if (recipients[i] != null)
                        {
                            recipients[i].DisplayRecipient();
                            Console.WriteLine(); // Add a blank line between entries for readability
                        }
                    }
                }

            }
        public static void DisplayList(Recipient[] recipients,int nrel)
        {
            if (nrel == 0)
            {
                Console.WriteLine("The list is empty.");
            }
            else
            {
                for (int i = 0; i < recipients.Length; i++)
                {

                    if (recipients[i] != null)
                    {
                        recipients[i].DisplayRecipient();
                        Console.WriteLine(); // Add a blank line between entries for readability
                    }
                }
            }
        }
        static void ReadData(Recipient[] recipients, ref int nrel)
        {
            string line;
            StreamReader sr = new StreamReader("RecipientData.txt");
            while ((line = sr.ReadLine()) != null)
            {
                // Assuming the format of the text file is "Name, Hours" per line
                string[] data = line.Split(',');
                string name = data[0].Trim();
                int hrs = int.Parse(data[1].Trim());

                recipients[nrel] = new Recipient(name, hrs);
                nrel++;
            }
            sr.Close();
        }


        static void WriteData(Recipient[] recipients, ref int nrel)
        {
            StreamWriter wr = new StreamWriter("OutputData.txt");
            for(int i = 0; i < nrel; i++)
            {
                wr.WriteLine("{0}, {1}", recipients[i].Getname(), recipients[i].Gethours());

            }
            wr.Close();
        }
       
        


    }
    }

