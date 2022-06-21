namespace test2_retake.DTO;

public class FireTruckDTO
{
    public string OperationalNumber { get; set; } = null!;
    public bool SpecialEquipment { get; set; }

    public List<Action> Actions { get; set; }
}

public class Action
{
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public int NumberOfFirefighters { get; set; }
    public DateTime AssignmentDate { get; set; }
}