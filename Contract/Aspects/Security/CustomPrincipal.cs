using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;

namespace Contract
{
    [Serializable]
    public class CustomIdentity : IIdentity
    {
        private string authenticationType;
        private bool isAuthenticated;
        private string userId;
        private string userName;
        private int empresaId;

        public CustomIdentity(string userId, string userName, string authenticationType)
        {
            this.userId = userId;
            this.userName = userName;
            this.isAuthenticated = true;
            this.authenticationType = authenticationType;
        }

        public string UserId
        {
            get { return userId; }
        }

        public int EmpresaId
        {
            get { return empresaId; }
            set { empresaId = value; }
        }

        #region IIdentity Members

        public string AuthenticationType
        {
            get { return this.authenticationType; }
        }

        public bool IsAuthenticated
        {
            get { return this.isAuthenticated; }
        }

        public string Name
        {
            get { return this.userName; }
        }

        #endregion
    }

    [Serializable]
    public class CustomPrincipal : IPrincipal
    {
        private CustomIdentity customIdentity;
        private string[] roles;

        public CustomPrincipal(CustomIdentity customIdentity, string[] roles)
        {
            this.customIdentity = customIdentity;
            this.roles = roles;
        }

        #region IPrincipal Members

        public IIdentity Identity
        {
            get { return this.customIdentity; }
        }

        public bool IsInRole(string role)
        {
            bool result = false;
            foreach (string roleName in this.roles)
            {
                if (roleName.ToLower() == role.ToLower())
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        #endregion
    }

}