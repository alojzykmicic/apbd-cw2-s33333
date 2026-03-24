namespace apbd_cw2_s33333.Models;

public class Camera : Equipment
{
    public int Quality { get; }
    public bool ChangeableLens { get; }

    public Camera(string name, int quality, bool changeableLens) : base(name)
    {
        Quality = quality;
        ChangeableLens = changeableLens;
    }
}