using System;
using System.Collections.Generic;

using System.IO; // | StreamWrite | StreamReader | File.ReadAllLines() | File.Exists()     | StreamWriter(path, true) |
                //  |    Write    |    Read      |  Read entire file   | Check file exists |        Append            |
namespace ComputerLaboratoryInventory{

public class computerUnit
{
    public string pc_ID;
    public string Specs;
    public string Status;

    public computerUnit(string pc_ID, string Specs, string Status)
        {
            pc_ID = pc_ID.ToUpper();
            Specs = Specs;
            Status = Status;
        }

}



}

