namespace apbd_cw2_s33333.Models;

public class Projector : Equipment
{
    public int Lumen { get; }
    public string Resolution { get; }

    public Projector(string name, int lumen, string resolution) : base(name)
    {
        Lumen = lumen;
        Resolution = resolution;
    }
}