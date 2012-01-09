using System.Collections.Generic;

namespace NExtra.Web.Security
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// provides user role services.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public interface IRoleService
    {
        /// <summary>
        /// Add a certain role to a user.
        /// </summary>
        void AddUserToRole(string userName, string role, bool createRole);

        /// <summary>
        /// Get a list of all existing roles.
        /// </summary>
        string[] GetAllRoles();

        /// <summary>
        /// Get a list of the roles that the currently logged-on user is in.
        /// </summary>
        string[] GetRolesForUser();

        /// <summary>
        /// Get a list of the roles that a certain user is in.
        /// </summary>
        string[] GetRolesForUser(string userName);

        /// <summary>
        /// Get a list of users in a certain role.
        /// </summary>
        string[] GetUsersInRole(string roleName);

        /// <summary>
        /// Check whether or not the currently logged-on user is in a certain role.
        /// </summary>
        bool IsUserInRole(string roleName);

        /// <summary>
        /// Check whether or not a certain user is in a certain role.
        /// </summary>
        bool IsUserInRole(string userName, string roleName);

        /// <summary>
        /// Remove a certain user from a certain role.
        /// </summary>
        void RemoveUserFromRole(string userName, string role);

        /// <summary>
        /// Remove a certain user from a certain role.
        /// </summary>
        void RemoveUserFromRoles(string userName, IEnumerable<string> roles);
    }
}
