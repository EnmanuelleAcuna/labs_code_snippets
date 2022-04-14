//using Logic.Contract;
//using Logic.Implementation;
//using System;
//using System.ServiceModel;
//using System.ServiceModel.Description;

//namespace WCF.Service {
//    class Program {
//        static void Main(string[] args) {
//            Uri baseAddress = new Uri("http://localhost:8000/SGM/");

//            ServiceHost selfHost = new ServiceHost(typeof(LoanService), baseAddress);

//            try {
//                selfHost.AddServiceEndpoint(typeof(ILoanService), new WSHttpBinding(), "LoanService");

//                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
//                smb.HttpGetEnabled = true;
//                selfHost.Description.Behaviors.Add(smb);

//                selfHost.Open();

//                Console.WriteLine("Host is running");
//                Console.ReadLine();
//            }
//            catch (CommunicationException ce) {
//                Console.WriteLine("An exception occurred: {0}", ce.Message);
//                selfHost.Abort();
//            }
//        }
//    }
//}
