using Entities;
using System.ServiceModel;

namespace Logic.Contract {
    [ServiceContract]
    public interface ILoanService {
        [OperationContract]
        string Request(string data);
    }
}
