using test2_retake.DTO;

namespace test2_retake.Services;

public interface IDbService
{
    FireTruckDTO GetFireTruck(int IdFireTruck);
    void UpdateActionEndDate(int idAction,DateTime endTime);
    bool CheckIdAction(int idAction);
    bool CheckProperOfEndtime(int idAction,DateTime endTime);
    bool CheckPresentsOfEndTime(int idAction, DateTime endTime);
}