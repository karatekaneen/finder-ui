﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace finder_ui.MessageServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Messageinfo", Namespace="http://schemas.datacontract.org/2004/07/MessageService")]
    [System.SerializableAttribute()]
    public partial class Messageinfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RecievingUserIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SendingUserIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ServiceIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ServiceTitleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] UserPictureField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RecievingUserId {
            get {
                return this.RecievingUserIdField;
            }
            set {
                if ((this.RecievingUserIdField.Equals(value) != true)) {
                    this.RecievingUserIdField = value;
                    this.RaisePropertyChanged("RecievingUserId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SendingUserId {
            get {
                return this.SendingUserIdField;
            }
            set {
                if ((this.SendingUserIdField.Equals(value) != true)) {
                    this.SendingUserIdField = value;
                    this.RaisePropertyChanged("SendingUserId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ServiceId {
            get {
                return this.ServiceIdField;
            }
            set {
                if ((this.ServiceIdField.Equals(value) != true)) {
                    this.ServiceIdField = value;
                    this.RaisePropertyChanged("ServiceId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ServiceTitle {
            get {
                return this.ServiceTitleField;
            }
            set {
                if ((object.ReferenceEquals(this.ServiceTitleField, value) != true)) {
                    this.ServiceTitleField = value;
                    this.RaisePropertyChanged("ServiceTitle");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Time {
            get {
                return this.TimeField;
            }
            set {
                if ((this.TimeField.Equals(value) != true)) {
                    this.TimeField = value;
                    this.RaisePropertyChanged("Time");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] UserPicture {
            get {
                return this.UserPictureField;
            }
            set {
                if ((object.ReferenceEquals(this.UserPictureField, value) != true)) {
                    this.UserPictureField = value;
                    this.RaisePropertyChanged("UserPicture");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AddMessage", Namespace="http://schemas.datacontract.org/2004/07/MessageService")]
    [System.SerializableAttribute()]
    public partial class AddMessage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RecievingUserIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SendingUserIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ServiceIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ServiceTitleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] UserPictureField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RecievingUserId {
            get {
                return this.RecievingUserIdField;
            }
            set {
                if ((this.RecievingUserIdField.Equals(value) != true)) {
                    this.RecievingUserIdField = value;
                    this.RaisePropertyChanged("RecievingUserId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SendingUserId {
            get {
                return this.SendingUserIdField;
            }
            set {
                if ((this.SendingUserIdField.Equals(value) != true)) {
                    this.SendingUserIdField = value;
                    this.RaisePropertyChanged("SendingUserId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ServiceId {
            get {
                return this.ServiceIdField;
            }
            set {
                if ((this.ServiceIdField.Equals(value) != true)) {
                    this.ServiceIdField = value;
                    this.RaisePropertyChanged("ServiceId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ServiceTitle {
            get {
                return this.ServiceTitleField;
            }
            set {
                if ((object.ReferenceEquals(this.ServiceTitleField, value) != true)) {
                    this.ServiceTitleField = value;
                    this.RaisePropertyChanged("ServiceTitle");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Time {
            get {
                return this.TimeField;
            }
            set {
                if ((this.TimeField.Equals(value) != true)) {
                    this.TimeField = value;
                    this.RaisePropertyChanged("Time");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] UserPicture {
            get {
                return this.UserPictureField;
            }
            set {
                if ((object.ReferenceEquals(this.UserPictureField, value) != true)) {
                    this.UserPictureField = value;
                    this.RaisePropertyChanged("UserPicture");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MessageServiceReference.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetMessages", ReplyAction="http://tempuri.org/IService1/GetMessagesResponse")]
        finder_ui.MessageServiceReference.Messageinfo[] GetMessages();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetMessages", ReplyAction="http://tempuri.org/IService1/GetMessagesResponse")]
        System.Threading.Tasks.Task<finder_ui.MessageServiceReference.Messageinfo[]> GetMessagesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddMessage", ReplyAction="http://tempuri.org/IService1/AddMessageResponse")]
        void AddMessage(finder_ui.MessageServiceReference.AddMessage newMessage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddMessage", ReplyAction="http://tempuri.org/IService1/AddMessageResponse")]
        System.Threading.Tasks.Task AddMessageAsync(finder_ui.MessageServiceReference.AddMessage newMessage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUserMessage", ReplyAction="http://tempuri.org/IService1/GetUserMessageResponse")]
        finder_ui.MessageServiceReference.Messageinfo[] GetUserMessage(int id1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUserMessage", ReplyAction="http://tempuri.org/IService1/GetUserMessageResponse")]
        System.Threading.Tasks.Task<finder_ui.MessageServiceReference.Messageinfo[]> GetUserMessageAsync(int id1);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : finder_ui.MessageServiceReference.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<finder_ui.MessageServiceReference.IService1>, finder_ui.MessageServiceReference.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public finder_ui.MessageServiceReference.Messageinfo[] GetMessages() {
            return base.Channel.GetMessages();
        }
        
        public System.Threading.Tasks.Task<finder_ui.MessageServiceReference.Messageinfo[]> GetMessagesAsync() {
            return base.Channel.GetMessagesAsync();
        }
        
        public void AddMessage(finder_ui.MessageServiceReference.AddMessage newMessage) {
            base.Channel.AddMessage(newMessage);
        }
        
        public System.Threading.Tasks.Task AddMessageAsync(finder_ui.MessageServiceReference.AddMessage newMessage) {
            return base.Channel.AddMessageAsync(newMessage);
        }
        
        public finder_ui.MessageServiceReference.Messageinfo[] GetUserMessage(int id1) {
            return base.Channel.GetUserMessage(id1);
        }
        
        public System.Threading.Tasks.Task<finder_ui.MessageServiceReference.Messageinfo[]> GetUserMessageAsync(int id1) {
            return base.Channel.GetUserMessageAsync(id1);
        }
    }
}
