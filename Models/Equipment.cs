namespace apbd_cw2_s33333.Models;

public abstract class Equipment
{
    public Guid Id { get; }
    public string Name { get; }
    public EquipmentStatus Status { get; set; } = EquipmentStatus.Available;

    protected Equipment(string name)
    {
        Name = name;
    }
}