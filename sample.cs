using System;
using System.Collections.Generic;
using System.IO;

namespace ComputerLaboratoryInventory{
//sample lang sample
public class computerUnit
{
    private string pc_ID;
    private string pc_Specs;
    private string pc_status;

    public string PcID { get { return pc_ID; } }
    public string Specs { get { return pc_Specs; } }
    public string Status { get { return pc_status; } }

    public computerUnit(string pc_ID, string pc_Specs, string pc_status)
        {
            this.pc_ID = pc_ID.ToUpper();
            this.pc_Specs = pc_Specs;
            this.pc_status = pc_status;
        }

    public Computer Clone()
        {
            return new Computer(this.pc_ID, this.pc_Specs, this.pc_status);
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
        public Computer Data;
        public Node Next;

        public Node(Computer data)
        {
            Data = data;
            Next = null;
        }
    }


public class InventoryManager
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
            Console.WriteLine("No existing save file found. Starting with an empty inventory.");
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

class Program
{
    static void Main(string[] args)
    {
       
        List<computerUnit> inventory = InventoryManager.LoadInventory();

        
        if (inventory.Count == 0)
        {
            inventory.Add(new computerUnit("PC-01", "Intel i7, 16GB RAM", "Available"));
            inventory.Add(new computerUnit("PC-02", "Intel i5, 8GB RAM", "In Use"));
        }

       
        foreach (var unit in inventory)
        {
            unit.displayInfo();
        }

        InventoryManager.saveInventory(inventory);
    }
}

}


/*
using System;
using System.Collections.Generic;
using System.IO; // | StreamWrite | StreamReader | File.ReadAllLines() | File.Exists()     | StreamWriter(path, true) |
                //  |    Write    |    Read      |  Read entire file   | Check file exists |        Append            |

//SAMPLE PALANG

namespace ComputerLaboratoryInventory{

public class computerUnit
{
    private string pc_ID;
    private string pc_Specs;
    private string pc_status;

    public string PcID { get { return pc_ID; } }
    public string Specs { get { return pc_Specs; } }
    public string Status { get { return pc_status; } }

    public computerUnit(string pc_ID, string pc_Specs, string pc_status)
        {
            this.pc_ID = pc_ID.ToUpper();
            this.pc_Specs = pc_Specs;
            this.pc_status = pc_status;
        }

    public Computer clone()
        {
            return new Computer(this.pc_ID, this.pc_Specs, this.pc_status);
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
            public Computer Data;
            public Node Next;

            public Node(Computer data)
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
    }


}


*/