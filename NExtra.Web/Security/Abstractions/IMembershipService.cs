using System;
using System.Web.Security;

namespace NExtra.Web.Security.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// should be able to provide membership services.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public interface IMembershipService
    {
        /// <summary>
        /// The minimum amount of chars in a password.
        /// </summary>
        int MinPasswordLength { get; }
        
        /// <summary>
        /// Change the password of a certain user.
        /// </summary>
        /// <param name="userName">The name of the user.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>Whether or not the password changed.</returns>
        bool ChangePassword(string userName, string oldPassword, string newPassword);

        /// <summary>
        /// Create a new membership user.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The user password.</param>
        /// <param name="email">The user's e-mail address.</param>
        /// <returns>Whether or not the user could be created.</returns>
        MembershipCreateStatus CreateUser(string userName, string password, string email);

        /// <summary>
        /// Delete a certain user.
        /// </summary>
        /// <param name="userName">The name of the user to delete.</param>
        void DeleteUser(string userName);

        /// <summary>
        /// Get membership users by user name.
        /// </summary>
        /// <param name="userName">The user name of interest.</param>
        /// <returns>The resulting membership user collection, if any.</returns>
        MembershipUserCollection FindUsersByName(string userName);

        /// <summary>
        /// Get membership users by e-mail.
        /// </summary>
        /// <param name="email">The e-mail address of interest.</param>
        /// <returns>The resulting membership user collection, if any.</returns>
        MembershipUserCollection FindUsersByEmail(string email);

        /// <summary>
        /// Get the currently logged in user.
        /// </summary>
        /// <returns>The currently logged in user.</returns>
        MembershipUser GetUser();

        /// <summary>
        /// Get a certain user by user name.
        /// </summary>
        /// <param name="userName">The user name of interest.</param>
        /// <returns>The corresponding user, if any.</returns>
        MembershipUser GetUser(string userName);

        /// <summary>
        /// Reset the password of a certain membership user.
        /// </summary>
        /// <param name="userName">The user name of interest.</param>
        /// <returns>The new, auto-generated password.</returns>
        string ResetPassword(string userName);

        /// <summary>
        /// Set whether or not the user is approved.
        /// </summary>
        /// <param name="userName">The user name of interest.</param>
        /// <param name="approved">Whether or not the user is approved.</param>
        void SetIsApproved(string userName, bool approved);

        /// <summary>
        /// Verifies that a user name and password are valid.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The user password.</param>
        /// <returns>Whether or not the user name and password are valid</returns>
        bool ValidateUser(string userName, string password);

        /// <summary>
        /// Check whether or not a certain user exists.
        /// </summary>
        /// <param name="userName">The user name of interest.</param>
        /// <returns>Whether or not the user exists.</returns>
        bool UserExists(string userName);

        /// <summary>
        /// Update a certain user.
        /// </summary>
        /// <param name="user">The user to update.</param>
        void UpdateUser(MembershipUser user);
    }



    /// <summary>
    /// This interface can be implemented by classes that
    /// should be able to provide membership services.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    [Obsolete("Use IMembershipService instead.")]
    public interface IMembershipFacade
    {
        /// <summary>
        /// The minimum amount of chars in a password.
        /// </summary>
        int MinPasswordLength { get; }

        /// <summary>
        /// Change the password of a certain user.
        /// </summary>
        /// <param name="userName">The name of the user.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>Whether or not the password changed.</returns>
        bool ChangePassword(string userName, string oldPassword, string newPassword);

        /// <summary>
        /// Create a new membership user.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The user password.</param>
        /// <param name="email">The user's e-mail address.</param>
        /// <returns>Whether or not the user could be created.</returns>
        MembershipCreateStatus CreateUser(string userName, string password, string email);

        /// <summary>
        /// Delete a certain user.
        /// </summary>
        /// <param name="userName">The name of the user to delete.</param>
        void DeleteUser(string userName);

        /// <summary>
        /// Get membership users by user name.
        /// </summary>
        /// <param name="userName">The user name of interest.</param>
        /// <returns>The resulting membership user collection, if any.</returns>
        MembershipUserCollection FindUsersByName(string userName);

        /// <summary>
        /// Get membership users by e-mail.
        /// </summary>
        /// <param name="email">The e-mail address of interest.</param>
        /// <returns>The resulting membership user collection, if any.</returns>
        MembershipUserCollection FindUsersByEmail(string email);

        /// <summary>
        /// Get the currently logged in user.
        /// </summary>
        /// <returns>The currently logged in user.</returns>
        MembershipUser GetUser();

        /// <summary>
        /// Get a certain user by user name.
        /// </summary>
        /// <param name="userName">The user name of interest.</param>
        /// <returns>The corresponding user, if any.</returns>
        MembershipUser GetUser(string userName);

        /// <summary>
        /// Reset the password of a certain membership user.
        /// </summary>
        /// <param name="userName">The user name of interest.</param>
        /// <returns>The new, auto-generated password.</returns>
        string ResetPassword(string userName);

        /// <summary>
        /// Set whether or not the user is approved.
        /// </summary>
        /// <param name="userName">The user name of interest.</param>
        /// <param name="approved">Whether or not the user is approved.</param>
        void SetIsApproved(string userName, bool approved);

        /// <summary>
        /// Verifies that a user name and password are valid.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The user password.</param>
        /// <returns>Whether or not the user name and password are valid</returns>
        bool ValidateUser(string userName, string password);

        /// <summary>
        /// Check whether or not a certain user exists.
        /// </summary>
        /// <param name="userName">The user name of interest.</param>
        /// <returns>Whether or not the user exists.</returns>
        bool UserExists(string userName);
    }
}
