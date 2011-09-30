using System;
using System.Collections.Generic;

namespace NExtra.Web.Security.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// should be able to provide user role services.
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
        /// <param name="userName">The user name</param>
        /// <param name="role">The role to add.</param>
        /// <param name="createRole">Whether or not to create the role if it does not exist.</param>
        void AddUserToRole(string userName, string role, bool createRole);

        /// <summary>
        /// Get a list of all existing roles.
        /// </summary>
        /// <returns>All existing roles.</returns>
        string[] GetAllRoles();

        /// <summary>
        /// Get a list of the roles that the currently logged-on user is in.
        /// </summary>
        /// <returns>A list of the roles that the currently logged-on user is in.</returns>
        string[] GetRolesForUser();

        /// <summary>
        /// Get a list of the roles that a certain user is in.
        /// </summary>
        /// <param name="userName">The user name of interest.</param>
        /// <returns>A list of the roles that the user is in.</returns>
        string[] GetRolesForUser(string userName);

        /// <summary>
        /// Get a list of users in a certain role.
        /// </summary>
        /// <param name="roleName">The role of interest.</param>
        /// <returns>A list of all the users in the role.</returns>
        string[] GetUsersInRole(string roleName);

        /// <summary>
        /// Check whether or not the currently logged-on user is in a certain role.
        /// </summary>
        /// <param name="roleName">The name of the role to search in.</param>
        /// <returns>Whether or not the currently logged-on user is in the role.</returns>
        bool IsUserInRole(string roleName);

        /// <summary>
        /// Check whether or not a certain user is in a certain role.
        /// </summary>
        /// <param name="userName">The name of the user to search for.</param>
        /// <param name="roleName">The name of the role to search in.</param>
        /// <returns>Whether or not the user is in the role.</returns>
        bool IsUserInRole(string userName, string roleName);

        /// <summary>
        /// Remove a certain user from a certain role.
        /// </summary>
        /// <param name="userName">The user to remove.</param>
        /// <param name="role">The role to remove the user from.</param>
        void RemoveUserFromRole(string userName, string role);

        /// <summary>
        /// Remove a certain user from a certain role.
        /// </summary>
        /// <param name="userName">The user to remove.</param>
        /// <param name="roles">The roles to remove the user from.</param>
        void RemoveUserFromRoles(string userName, IEnumerable<string> roles);
    }


    /// <summary>
    /// This interface can be implemented by classes that
    /// should be able to provide user role services.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    [Obsolete("Use IRoleService instead.")]
    public interface IRolesFacade
    {
        /// <summary>
        /// Add a certain role to a user.
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="role">The role to add.</param>
        /// <param name="createRole">Whether or not to create the role if it does not exist.</param>
        void AddUserToRole(string userName, string role, bool createRole);

        /// <summary>
        /// Get a list of all existing roles.
        /// </summary>
        /// <returns>All existing roles.</returns>
        string[] GetAllRoles();

        /// <summary>
        /// Get a list of the roles that the currently logged-on user is in.
        /// </summary>
        /// <returns>A list of the roles that the currently logged-on user is in.</returns>
        string[] GetRolesForUser();

        /// <summary>
        /// Get a list of the roles that a certain user is in.
        /// </summary>
        /// <param name="userName">The user name of interest.</param>
        /// <returns>A list of the roles that the user is in.</returns>
        string[] GetRolesForUser(string userName);

        /// <summary>
        /// Get a list of users in a certain role.
        /// </summary>
        /// <param name="roleName">The role of interest.</param>
        /// <returns>A list of all the users in the role.</returns>
        string[] GetUsersInRole(string roleName);

        /// <summary>
        /// Check whether or not the currently logged-on user is in a certain role.
        /// </summary>
        /// <param name="roleName">The name of the role to search in.</param>
        /// <returns>Whether or not the currently logged-on user is in the role.</returns>
        bool IsUserInRole(string roleName);

        /// <summary>
        /// Check whether or not a certain user is in a certain role.
        /// </summary>
        /// <param name="userName">The name of the user to search for.</param>
        /// <param name="roleName">The name of the role to search in.</param>
        /// <returns>Whether or not the user is in the role.</returns>
        bool IsUserInRole(string userName, string roleName);

        /// <summary>
        /// Remove a certain user from a certain role.
        /// </summary>
        /// <param name="userName">The user to remove.</param>
        /// <param name="role">The role to remove the user from.</param>
        void RemoveUserFromRole(string userName, string role);

        /// <summary>
        /// Remove a certain user from a certain role.
        /// </summary>
        /// <param name="userName">The user to remove.</param>
        /// <param name="roles">The roles to remove the user from.</param>
        void RemoveUserFromRoles(string userName, IEnumerable<string> roles);
    }
}
