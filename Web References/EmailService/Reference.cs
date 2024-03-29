﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace QuizBook.EmailService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="EmailServiceSoap", Namespace="http://fidelitybankplc.com/emailservice")]
    public partial class EmailService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback RegisterEmailOperationCompleted;
        
        private System.Threading.SendOrPostCallback RegisterSmsAsapOperationCompleted;
        
        private System.Threading.SendOrPostCallback RegisterProcessEmailOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public EmailService() {
            this.Url = global::QuizBook.Properties.Settings.Default.FidelityEquiz_EmailService_EmailService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event RegisterEmailCompletedEventHandler RegisterEmailCompleted;
        
        /// <remarks/>
        public event RegisterSmsAsapCompletedEventHandler RegisterSmsAsapCompleted;
        
        /// <remarks/>
        public event RegisterProcessEmailCompletedEventHandler RegisterProcessEmailCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://fidelitybankplc.com/emailservice/RegisterEmail", RequestNamespace="http://fidelitybankplc.com/emailservice", ResponseNamespace="http://fidelitybankplc.com/emailservice", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool RegisterEmail(string subject, string body, string senderemail, string recieveremails, string AppCode, string sessionToken, string IPAddress) {
            object[] results = this.Invoke("RegisterEmail", new object[] {
                        subject,
                        body,
                        senderemail,
                        recieveremails,
                        AppCode,
                        sessionToken,
                        IPAddress});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void RegisterEmailAsync(string subject, string body, string senderemail, string recieveremails, string AppCode, string sessionToken, string IPAddress) {
            this.RegisterEmailAsync(subject, body, senderemail, recieveremails, AppCode, sessionToken, IPAddress, null);
        }
        
        /// <remarks/>
        public void RegisterEmailAsync(string subject, string body, string senderemail, string recieveremails, string AppCode, string sessionToken, string IPAddress, object userState) {
            if ((this.RegisterEmailOperationCompleted == null)) {
                this.RegisterEmailOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRegisterEmailOperationCompleted);
            }
            this.InvokeAsync("RegisterEmail", new object[] {
                        subject,
                        body,
                        senderemail,
                        recieveremails,
                        AppCode,
                        sessionToken,
                        IPAddress}, this.RegisterEmailOperationCompleted, userState);
        }
        
        private void OnRegisterEmailOperationCompleted(object arg) {
            if ((this.RegisterEmailCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RegisterEmailCompleted(this, new RegisterEmailCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://fidelitybankplc.com/emailservice/RegisterSmsAsap", RequestNamespace="http://fidelitybankplc.com/emailservice", ResponseNamespace="http://fidelitybankplc.com/emailservice", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool RegisterSmsAsap(string recipient, string body, string appCode, string ipAddress, string sessionToken) {
            object[] results = this.Invoke("RegisterSmsAsap", new object[] {
                        recipient,
                        body,
                        appCode,
                        ipAddress,
                        sessionToken});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void RegisterSmsAsapAsync(string recipient, string body, string appCode, string ipAddress, string sessionToken) {
            this.RegisterSmsAsapAsync(recipient, body, appCode, ipAddress, sessionToken, null);
        }
        
        /// <remarks/>
        public void RegisterSmsAsapAsync(string recipient, string body, string appCode, string ipAddress, string sessionToken, object userState) {
            if ((this.RegisterSmsAsapOperationCompleted == null)) {
                this.RegisterSmsAsapOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRegisterSmsAsapOperationCompleted);
            }
            this.InvokeAsync("RegisterSmsAsap", new object[] {
                        recipient,
                        body,
                        appCode,
                        ipAddress,
                        sessionToken}, this.RegisterSmsAsapOperationCompleted, userState);
        }
        
        private void OnRegisterSmsAsapOperationCompleted(object arg) {
            if ((this.RegisterSmsAsapCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RegisterSmsAsapCompleted(this, new RegisterSmsAsapCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://fidelitybankplc.com/emailservice/RegisterProcessEmail", RequestNamespace="http://fidelitybankplc.com/emailservice", ResponseNamespace="http://fidelitybankplc.com/emailservice", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool RegisterProcessEmail(string subject, string body, string senderemail, string recieveremails, string AppCode, string IPAddress) {
            object[] results = this.Invoke("RegisterProcessEmail", new object[] {
                        subject,
                        body,
                        senderemail,
                        recieveremails,
                        AppCode,
                        IPAddress});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void RegisterProcessEmailAsync(string subject, string body, string senderemail, string recieveremails, string AppCode, string IPAddress) {
            this.RegisterProcessEmailAsync(subject, body, senderemail, recieveremails, AppCode, IPAddress, null);
        }
        
        /// <remarks/>
        public void RegisterProcessEmailAsync(string subject, string body, string senderemail, string recieveremails, string AppCode, string IPAddress, object userState) {
            if ((this.RegisterProcessEmailOperationCompleted == null)) {
                this.RegisterProcessEmailOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRegisterProcessEmailOperationCompleted);
            }
            this.InvokeAsync("RegisterProcessEmail", new object[] {
                        subject,
                        body,
                        senderemail,
                        recieveremails,
                        AppCode,
                        IPAddress}, this.RegisterProcessEmailOperationCompleted, userState);
        }
        
        private void OnRegisterProcessEmailOperationCompleted(object arg) {
            if ((this.RegisterProcessEmailCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RegisterProcessEmailCompleted(this, new RegisterProcessEmailCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void RegisterEmailCompletedEventHandler(object sender, RegisterEmailCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RegisterEmailCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RegisterEmailCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void RegisterSmsAsapCompletedEventHandler(object sender, RegisterSmsAsapCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RegisterSmsAsapCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RegisterSmsAsapCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void RegisterProcessEmailCompletedEventHandler(object sender, RegisterProcessEmailCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RegisterProcessEmailCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RegisterProcessEmailCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591