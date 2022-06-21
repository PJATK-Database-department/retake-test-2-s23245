using test2_retake.DTO;

namespace test2_retake.Services;

public class DbService : IDbService
{
    private APBDContext _context;

    public DbService(APBDContext context)
    {
        _context = context;
    }
    
    public FireTruckDTO GetFireTruck(int IdFireTruck)
    {

        FireTruckDTO result = new FireTruckDTO();
        var firetrucks = _context.FireTrucks
            .Select(x => x).First(x => x.IdFireTruck == IdFireTruck);

        /*var actions = from ft in _context.FireTrucks
            join fta in _context.FireTruckActions on
                ft.IdFireTruck equals fta.FireTruckIdFireTruck into act
            from a in act.DefaultIfEmpty();*/
        return result;
    }

    public void UpdateActionEndDate(int idAction,DateTime endTime)
    {
        var action =_context.Actions
            .Select(x => x).First(x => x.IdAction == idAction);

        action.EndTime = endTime;

        _context.SaveChanges();
    }

    public bool CheckIdAction(int idAction)
    {
        return _context.Actions.Any(x => x.IdAction == idAction);
    }

    public bool CheckProperOfEndtime(int idAction,DateTime endTime)
    {
        var selection = _context.Actions
            .Select(x => x).First(x => x.IdAction == idAction);

        if (selection.StartTime < endTime)
            return true;

        return false;
    }

    public bool CheckPresentsOfEndTime(int idAction, DateTime endTime)
    {
        var selection = _context.Actions
            .Select(x => x).First(x => x.IdAction == idAction);

        if (selection.EndTime != null)
            return true;

        return false;
    }
}