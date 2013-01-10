using System.Collections.Generic;
using System.Linq;
using System.Web.Security;

namespace NExtra.Web.Security
{
    /// <summary>
    /// This class can be used as a facade for the
    /// static Roles class.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class RolesFacade : IRoleService
    {
        public void AddUserToRole(string userName, string role, bool createRole)
        {
            if (!Roles.RoleExists(role) && createRole)
                Roles.CreateRole(role);

            if (!Roles.IsUserInRole(userName, role))
                Roles.AddUserToRole(userName, role);
        }

        public string[] GetAllRoles()
        {
            return Roles.GetAllRoles();
        }

        public string[] GetRolesForUser()
        {
            return Roles.GetRolesForUser();
        }

        public string[] GetRolesForUser(string userName)
        {
            return Roles.GetRolesForUser(userName);
        }

        public string[] GetUsersInRole(string roleName)
        {
            return Roles.GetUsersInRole(roleName);
        }

        public bool IsUserInRole(string roleName)
        {
            return Roles.IsUserInRole(roleName);
        }

        public bool IsUserInRole(string userName, string roleName)
        {
            return Roles.IsUserInRole(userName, roleName);
        }

        public void RemoveUserFromRole(string userName, string role)
        {
            if (IsUserInRole(userName, role))
                Roles.RemoveUserFromRole(userName, role);
        }

        public void RemoveUserFromRoles(string userName, IEnumerable<string> roles)
        {
            Roles.RemoveUserFromRoles(userName, roles.ToArray());
        }
    }
}
