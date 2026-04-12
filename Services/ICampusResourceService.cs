using System.ServiceModel;

namespace SunDevilStudentHub.Services
{
    [ServiceContract]
    public interface ICampusResourceService
    {
        [OperationContract]
        string GetCampusResource(string category);
    }
}
