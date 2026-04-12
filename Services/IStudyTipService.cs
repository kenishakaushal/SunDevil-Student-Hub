using System.ServiceModel;

namespace SunDevilStudentHub.Services
{
    [ServiceContract]
    public interface IStudyTipService
    {
        [OperationContract]
        string GetStudyTip(string subject);
    }
}
