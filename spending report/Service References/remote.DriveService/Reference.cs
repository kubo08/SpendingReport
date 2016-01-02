﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpendingReport.remote.DriveService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="remote.DriveService.IDriveService")]
    public interface IDriveService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDriveService/AddNewCar", ReplyAction="http://tempuri.org/IDriveService/AddNewCarResponse")]
        void AddNewCar(int userId, SpendingReport.Models.Cars.Car car);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDriveService/AddNewCar", ReplyAction="http://tempuri.org/IDriveService/AddNewCarResponse")]
        System.Threading.Tasks.Task AddNewCarAsync(int userId, SpendingReport.Models.Cars.Car car);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDriveService/GetCarsByUserId", ReplyAction="http://tempuri.org/IDriveService/GetCarsByUserIdResponse")]
        SpendingReport.Models.Cars.Car[] GetCarsByUserId(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDriveService/GetCarsByUserId", ReplyAction="http://tempuri.org/IDriveService/GetCarsByUserIdResponse")]
        System.Threading.Tasks.Task<SpendingReport.Models.Cars.Car[]> GetCarsByUserIdAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDriveService/GetCarById", ReplyAction="http://tempuri.org/IDriveService/GetCarByIdResponse")]
        SpendingReport.Models.Cars.Car GetCarById(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDriveService/GetCarById", ReplyAction="http://tempuri.org/IDriveService/GetCarByIdResponse")]
        System.Threading.Tasks.Task<SpendingReport.Models.Cars.Car> GetCarByIdAsync(int Id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDriveServiceChannel : SpendingReport.remote.DriveService.IDriveService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DriveServiceClient : System.ServiceModel.ClientBase<SpendingReport.remote.DriveService.IDriveService>, SpendingReport.remote.DriveService.IDriveService {
        
        public DriveServiceClient() {
        }
        
        public DriveServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DriveServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DriveServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DriveServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AddNewCar(int userId, SpendingReport.Models.Cars.Car car) {
            base.Channel.AddNewCar(userId, car);
        }
        
        public System.Threading.Tasks.Task AddNewCarAsync(int userId, SpendingReport.Models.Cars.Car car) {
            return base.Channel.AddNewCarAsync(userId, car);
        }
        
        public SpendingReport.Models.Cars.Car[] GetCarsByUserId(int userId) {
            return base.Channel.GetCarsByUserId(userId);
        }
        
        public System.Threading.Tasks.Task<SpendingReport.Models.Cars.Car[]> GetCarsByUserIdAsync(int userId) {
            return base.Channel.GetCarsByUserIdAsync(userId);
        }
        
        public SpendingReport.Models.Cars.Car GetCarById(int Id) {
            return base.Channel.GetCarById(Id);
        }
        
        public System.Threading.Tasks.Task<SpendingReport.Models.Cars.Car> GetCarByIdAsync(int Id) {
            return base.Channel.GetCarByIdAsync(Id);
        }
    }
}
