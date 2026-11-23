using System;
using System.Collections.Generic;
using System.IO; // | StreamWrite | StreamReader | File.ReadAllLines() | File.Exists()     | StreamWriter(path, true) |
                //  |    Write    |    Read      |  Read entire file   | Check file exists |        Append            |

//SAMPLE PALANG
//SPAG CODE TvT

namespace ComputerLaboratoryInventory{

public class computerUnit
{
    private string pc_ID;
    private string pc_Specs;
    private string pc_status;

    public string PcID { get { return pc_ID; } }
    public string Specs { get { return pc_Specs; } set{ pc_Specs = value;} }
    public string Status { get { return pc_status; } set{ pc_status = value;}}

    public computerUnit(string pc_ID, string pc_Specs, string pc_status)
        {
            this.pc_ID = pc_ID.ToUpper();
            this.pc_Specs = pc_Specs;
            this.pc_status = pc_status;
        }

    public computerUnit clone()
        {
            return new computerUnit(this.pc_ID, this.pc_Specs, this.pc_status);
        }

    public void displayInfo()
        {
            Console.WriteLine("==============================");
            Console.WriteLine("Computer ID: " + PcID);
            Console.WriteLine("Computer Specs: " + Specs);
            Console.WriteLine("Computer Status: " + Status);
            Console.WriteLine("==============================");
        }

        public string ToFileString()
        {
            return $"{PcID}|{Specs}|{Status}";
        }

        public static computerUnit FromFileString(string line)
        {
            string[] parts = line.Split('|');
            if (parts.Length != 3) return null;
            return new computerUnit(parts[0], parts[1], parts[2]);
        }
}

    class Node
        {
            public computerUnit Data;
            
            public Node Next;
            

            public Node(computerUnit data)
            {
                Data = data;
                Next = null;
            }
        }

class computerLinkedList
    {
        private Node head;

        public void addUnit(computerUnit unit)
        {
            Node newNode = new Node(unit);
            if(head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while(current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public computerUnit searchUnit(string targetID)
        {
            Node current = head;

            while(current != null)
            {
                if(current.Data.PcID.Equals(targetID, StringComparison.OrdinalIgnoreCase))
                {
                    return current.Data;
                }
                current = current.Next;
            }
            return null;
        }


        public computerUnit updateUnit(string targetID, string newSpecs, string newStatus)
        {
           Node current = head;
           while(current != null)
            {
                if(current.Data.PcID.Equals(targetID, StringComparison.OrdinalIgnoreCase))
                {
                    current.Data.Specs = newSpecs;
                    current.Data.Status = newStatus;
                    return current.Data;
                }
                current = current.Next;
            }
            return null;
        }

        public bool deleteUnit(string targetID)
        {
            if(head == null) return false;

            if(head.Data.PcID.Equals(targetID, StringComparison.OrdinalIgnoreCase))
            {
                head = head.Next;
                return true;
            }

            Node previous = head;
            Node current = head.Next;

            while(current != null)
            {
                if (current.Data.PcID.Equals(targetID, StringComparison.OrdinalIgnoreCase))
                {
                    previous.Next = current.Next; 
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return true;
        }
    }



    //UNDO NEXT

    class program
    {
        static void Main(string[] args)
        {
            computerLinkedList inventory = new computerLinkedList();

            bool exit = false;
            while (!exit)
            {

                try
                {
                    Console.Clear();
                }   
                catch (Exception)
                {
                    Console.WriteLine("\n--------------------------------------------------\n");
                }
                
                
                Console.WriteLine("=== COMPUTER LABORATORY INVENTORY SYSTEM ===");
                Console.WriteLine("[1] View Comlab 1 Layout UI");//wala pa
                Console.WriteLine("[2] Add New Computer Unit (Create)"); 
                Console.WriteLine("[3] Search Computer Unit (Retrieve)"); 
                Console.WriteLine("[4] Update Computer Unit");
                Console.WriteLine("[5] Delete Computer Unit");
                Console.WriteLine("[6] Undo Last Action");//wala pa(using stack)
                Console.WriteLine("[7] Exit & Save");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("ajksdhakjshda");
                    break;
                    case 2:
                        Console.WriteLine("ajksdhakjshda");
                    break;
                    case 3:
                        Console.WriteLine("ajksdhakjshda");
                    break;
                    case 4:
                        Console.WriteLine("ajksdhakjshda");
                    break;
                    case 5:
                        Console.WriteLine("ajksdhakjshda");
                    break;
                    case 6:
                        Console.WriteLine("ajksdhakjshda");
                    break;
                    case 7:
                        Console.WriteLine("Exiting the program....");
                        exit = true;
                    break;
                }
            }
        }
    }


}

