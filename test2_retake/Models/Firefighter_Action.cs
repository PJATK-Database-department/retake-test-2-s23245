namespace test2_retake.Models;

public class Firefighter_Action
{
    public virtual Action ActionNavigation { get; set; }
    public virtual Firefighter FirefighterNavigation { get; set; }

    public int IdAction { get; set; }
    public int IdFirefighter { get; set; }
}