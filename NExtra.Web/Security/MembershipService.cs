using System;
using System.Web.Security;
using NExtra.Web.Security.Abstractions;

namespace NExtra.Web.Security
{
    /// <summary>
    /// This class implements IMembershipService and can
    /// be used as a facade for the static Membership class.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class MembershipService : IMembershipService
    {
        /// <summary>
        /// Get the minimum required password length.
        /// </summary>
        public int MinPasswordLength
        {
            get { return Membership.MinRequiredPasswordLength; }
        }


        /// <summary>
        /// Change the password of a certain user.
        /// </summary>
        /// <param name="userName">The name of the user.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>Whether or not the password changed.</returns>
        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            var currentUser = Membership.GetUser(userName, true /* userIsOnline */);
            if (currentUser == null)
                throw new ArgumentException("MembershipFacade.ChangePassword: userName cannot be null");
            return currentUser.ChangePassword(oldPassword, newPassword);
        }

        /// <summary>
        /// Create a new membership user.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The user password.</param>
        /// <param name="email">The user's e-mail address.</param>
        /// <returns>Whether or not the user could be created.</returns>
        public MembershipCreateStatus CreateUser(string userName, string password, string email)
        {
            MembershipCreateStatus status;
            Membership.CreateUser(userName, password, email, null, null, true, null, out status);
            return status;
        }

        /// <summary>
        /// Delete a certain user.
        /// </summary>
        /// <param name="userName">The name of the user to delete.</param>
        public void DeleteUser(string userName)
        {
            Membership.DeleteUser(userName);
        }

        /// <summary>
        /// Get membership users by user name.
        /// </summary>
        /// <param name="userName">The user name of interest.</param>
        /// <returns>The resulting membership user collection, if any.</returns>
        public MembershipUserCollection FindUsersByName(string userName)
        {
            return Membership.FindUsersByName(userName);
        }

        /// <summary>
        /// Get membership users by e-mail.
        /// </summary>
        /// <param name="email">The e-mail address of interest.</param>
        /// <returns>The resulting membership user collection, if any.</returns>
        public MembershipUserCollection FindUsersByEmail(string email)
        {
            return Membership.FindUsersByEmail(email);
        }

        /// <summary>
        /// Get the currently logged in user.
        /// </summary>
        /// <returns>The currently logged in user.</returns>
        public MembershipUser GetUser()
        {
            return Membership.GetUser();
        }

        /// <summary>
        /// Get a certain user by user name.
        /// </summary>
        /// <param name="userName">The user name of interest.</param>
        /// <returns>The corresponding user, if any.</returns>
        public MembershipUser GetUser(string userName)
        {
            return FindUsersByName(userName)[userName];
        }

        /// <summary>
        /// Reset the password of a certain membership user.
        /// </summary>
        /// <param name="userName">The user name of interest.</param>
        /// <returns>The new, auto-generated password.</returns>
        public string ResetPassword(string userName)
        {
            return GetUser(userName).ResetPassword();
        }

        /// <summary>
        /// Set the IsApproved property of a certain user.
        /// </summary>
        /// <param name="userName">The user name of interest.</param>
        /// <param name="approved">Whether or not the user should be approved.</param>
        public void SetIsApproved(string userName, bool approved)
        {
            var user = GetUser(userName);
            user.IsApproved = approved;
            Membership.UpdateUser(user);
        }

        /// <summary>
        /// Verifies that a user name and password are valid.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The user password.</param>
        /// <returns>Whether or not the user name and password are valid</returns>
        public bool ValidateUser(string userName, string password)
        {
            return Membership.ValidateUser(userName, password);
        }

        /// <summary>
        /// Check whether or not a certain user exists.
        /// </summary>
        /// <param name="userName">The user name of interest.</param>
        /// <returns>Whether or not the user exists.</returns>
        public bool UserExists(string userName)
        {
            return GetUser(userName) != null;
        }

        /// <summary>
        /// Update a certain user.
        /// </summary>
        /// <param name="user">The user to update.</param>
        public void UpdateUser(MembershipUser user)
        {
            Membership.UpdateUser(user);
        }
    }
}
