using ProjectDemoV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace ProjectDemoV1.Security
{
    public class CustomPrincipal : IPrincipal
    {
        public IIdentity Identity
        {
            get;
            set;
        }

        private Account Account;

        public CustomPrincipal(Account Account)
        {
            this.Account = Account;
            this.Identity = new GenericIdentity(Account.UserName);
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => this.Account.Role.RoleName.Contains(r));
        }
    }
}