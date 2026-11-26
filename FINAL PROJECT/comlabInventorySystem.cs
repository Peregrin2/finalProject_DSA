using System;
using System.Collections.Generic;
using System.IO;

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

    public class inventoryManager
    {
        private const string FilePath = "inventory.txt";

        //SAVEFILE
        public static void saveInventory(List<computerUnit> units)
        {
            List<string> lines = new List<string>();

            foreach(var unit in units)
            {
                lines.Add(unit.ToFileString());
            }

            File.WriteAllLines(FilePath, lines);
            Console.WriteLine("Inventory successfully saved to " + FilePath);
        }

        //LOADFILE
        public static List<computerUnit> LoadInventory()
        {
            List<computerUnit> units = new List<computerUnit>();

            
            if (!File.Exists(FilePath))
            {
                Console.WriteLine("No existing save file found.");
                return units;
            }

            string[] lines = File.ReadAllLines(FilePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue; 

                computerUnit unit = computerUnit.FromFileString(line);
                if (unit != null)
                {
                    units.Add(unit);
                }
            }

            Console.WriteLine("Inventory successfully loaded from " + FilePath);
            return units;
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
        public List<computerUnit> getAllUnits()
        {
            List<computerUnit> units = new List<computerUnit>();

            Node current = head;

            while (current != null)
            {
                units.Add(current.Data);
                current = current.Next;
            }

            return units;
        }

        public void loadUnits(List<computerUnit> units)
        {
            head = null;

            foreach (computerUnit unit in units)
            {
                addUnit(unit);
            }
        }
        

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
            return false;
        }

          public void displayComlab1Layout()
        {  
            Console.WriteLine("=====================================================================");
            Console.WriteLine("======================= COMPUTER LABORATORY 1 ======================="); 
            Console.WriteLine("=====================================================================\n");
            
            Console.WriteLine("PC-09 | PC-08 | PC-07 | PC-06 | PC-05 | PC-04 | PC-03 | PC-02 | PC-01\n");
            Console.WriteLine("PC-18 | PC-17 | PC-16 | PC-15 | PC-14 | PC-13 | PC-12 | PC-11 | PC-10\n");
            Console.WriteLine("PC-25 | PC-24 | PC-23 | PC-22 | PC-21 | PC-20 | PC-19\n");
            Console.WriteLine("PC-34 | PC-33 | PC-32 | PC-31 | PC-30 | PC-29 | PC-28 | PC-27 | PC-26 \n");
            
        }
    }



    //UNDO NEXT

    class program
    {
        static void Main(string[] args)
        {
            computerLinkedList inventory = new computerLinkedList();
            
            inventory.addUnit(new computerUnit("PC-01", "Intel i9, 32GB RAM", "Not Working"));
            inventory.addUnit(new computerUnit("PC-02", "Intel i9, 32GB RAM", "Working"));
            inventory.addUnit(new computerUnit("PC-03", "Intel i9, 32GB RAM", "Working"));
            inventory.addUnit(new computerUnit("PC-04", "Intel i9, 32GB RAM", "Working"));
            inventory.addUnit(new computerUnit("PC-05", "Intel i9, 32GB RAM", "Working"));
            inventory.addUnit(new computerUnit("PC-06", "Intel i9, 32GB RAM", "Working"));
            inventory.addUnit(new computerUnit("PC-07", "Intel i9, 32GB RAM", "Not Working"));
            inventory.addUnit(new computerUnit("PC-08", "Intel i9, 32GB RAM", "Not Working"));
            inventory.addUnit(new computerUnit("PC-09", "Intel i9, 32GB RAM", "Working"));
            inventory.addUnit(new computerUnit("PC-10", "Intel i9, 32GB RAM", "Working"));
            inventory.addUnit(new computerUnit("PC-11", "Intel i9, 32GB RAM", "Working"));
            inventory.addUnit(new computerUnit("PC-12", "Intel i9, 32GB RAM", "Not Working"));
            inventory.addUnit(new computerUnit("PC-13", "Intel i9, 32GB RAM", "Working"));
            inventory.addUnit(new computerUnit("PC-14", "Intel i9, 32GB RAM", "Working"));
            inventory.addUnit(new computerUnit("PC-15", "Intel i9, 32GB RAM", "Not Working"));
            inventory.addUnit(new computerUnit("PC-16", "Intel i9, 32GB RAM", "Working"));
            inventory.addUnit(new computerUnit("PC-17", "Intel i9, 32GB RAM", "Not Working"));
            inventory.addUnit(new computerUnit("PC-18", "Intel i9, 32GB RAM", "Working"));
            inventory.addUnit(new computerUnit("PC-19", "Intel i9, 32GB RAM", "Working"));
            inventory.addUnit(new computerUnit("PC-20", "Intel i9, 32GB RAM", "Working"));
            inventory.addUnit(new computerUnit("PC-21", "Intel i9, 32GB RAM", "Working"));
            inventory.addUnit(new computerUnit("PC-22", "Intel i9, 32GB RAM", "Working"));
            inventory.addUnit(new computerUnit("PC-23", "Intel i9, 32GB RAM", "Working"));
            inventory.addUnit(new computerUnit("PC-24", "Intel i9, 32GB RAM", "Not Working"));
            inventory.addUnit(new computerUnit("PC-25", "Intel i9, 32GB RAM", "Not Working"));
            inventory.addUnit(new computerUnit("PC-27", "Intel i9, 32GB RAM", "Working"));
            inventory.addUnit(new computerUnit("PC-28", "Intel i9, 32GB RAM", "Working"));



            bool exit = false;
            while (!exit)
            {

                try
                {
                    Console.Clear();
                }   
                catch (Exception)
                {
                    Console.WriteLine();
                }
                
                Console.WriteLine("=== COMPUTER LABORATORY INVENTORY SYSTEM ===");
                Console.WriteLine("[1] View Comlab 1 Layout UI");//wala pa
                Console.WriteLine("[2] Add New Computer Unit"); 
                Console.WriteLine("[3] Search Computer Unit"); 
                Console.WriteLine("[4] Update Computer Unit");
                Console.WriteLine("[5] Delete Computer Unit");
                Console.WriteLine("[6] Undo Last Action");//wala pa(using stack)
                Console.WriteLine("[7] Exit & Save");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        inventory.displayComlab1Layout();
                        Console.WriteLine("\nPress any key to return to the menu...");
                        Console.ReadLine();
                    break;
                    case 2:
                        Console.WriteLine("");

                    break;
                    case 3:
                        Console.WriteLine("What Computer you want to search?: ");
                        string searchID = Console.ReadLine();

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

