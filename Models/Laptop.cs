namespace apbd_cw2_s33333.Models;

public class Laptop : Equipment
{
    public int Ram { get; }
    public string Cpu { get; }

    public Laptop(string name, int ram, string cpu) : base(name)
    {
        Ram = ram;
        Cpu = cpu;
    }
}