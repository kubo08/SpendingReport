using System.Collections.Generic;
using System.ServiceModel;

namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDriveService" in both code and config file together.
    [ServiceContract]
    public interface IDriveService
    {
        [OperationContract]
        void AddNewCar(int userId, SpendingReport.Models.Cars.Car car);

        [OperationContract]
        IList<SpendingReport.Models.Cars.Car> GetCarsByUserId(int userId);

        [OperationContract]
        SpendingReport.Models.Cars.Car GetCarById(int Id);
    }
}
