using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using NExtra.Web.Security.Abstractions;

namespace NExtra.Web.Security
{
    /// <summary>
    /// This class can be used as a facade for the
    /// static Roles class.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class RolesFacade : IRoleService
    {
        /// <summary>
        /// Add a certain role to a user.
        /// </summary>
        public void AddUserToRole(string userName, string role, bool createRole)
        {
            if (!Roles.RoleExists(role) && createRole)
                Roles.CreateRole(role);

            if (!Roles.IsUserInRole(userName, role))
                Roles.AddUserToRole(userName, role);
        }

        /// <summary>
        /// Get a list of all the roles for the application.
        /// </summary>
        public string[] GetAllRoles()
        {
            return Roles.GetAllRoles();
        }

        /// <summary>
        /// Get a list of the roles that the currently logged-on user is in.
        /// </summary>
        public string[] GetRolesForUser()
        {
            return Roles.GetRolesForUser();
        }

        /// <summary>
        /// Get a list of the roles that a certain user is in.
        /// </summary>
        public string[] GetRolesForUser(string userName)
        {
            return Roles.GetRolesForUser(userName);
        }

        /// <summary>
        /// Get a list of users in a certain role.
        /// </summary>
        public string[] GetUsersInRole(string roleName)
        {
            return Roles.GetUsersInRole(roleName);
        }

        /// <summary>
        /// Check whether or not the currently logged-on user is in a certain role.
        /// </summary>
        public bool IsUserInRole(string roleName)
        {
            return Roles.IsUserInRole(roleName);
        }

        /// <summary>
        /// Check whether or not a certain user is in a certain role.
        /// </summary>
        public bool IsUserInRole(string userName, string roleName)
        {
            return Roles.IsUserInRole(userName, roleName);
        }

        /// <summary>
        /// Remove a certain user from a certain role.
        /// </summary>
        public void RemoveUserFromRole(string userName, string role)
        {
            if (IsUserInRole(userName, role))
                Roles.RemoveUserFromRole(userName, role);
        }

        /// <summary>
        /// Remove a certain user from a certain role.
        /// </summary>
        public void RemoveUserFromRoles(string userName, IEnumerable<string> roles)
        {
            Roles.RemoveUserFromRoles(userName, roles.ToArray());
        }
    }
}
