using System.Web.Security;
using NExtra.Web.Security.Abstractions;

namespace NExtra.Web.Security
{
    /// <summary>
    /// This class implements IMembershipService and can be used as a
    /// facade for the Membership class. It provides methods for both
    /// the Membership class as well as for the MembershipUser class.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class MembershipService : IMembershipService
    {
        /// <summary>
        /// Gets or sets the name of the application.
        /// </summary>
        public string ApplicationName
        {
            get { return Membership.ApplicationName; }
            set { Membership.ApplicationName = value; }
        }

        /// <summary>
        /// Whether or not it is possible to reset the password of a user.
        /// </summary>
        public bool EnablePasswordReset
        {
            get { return Membership.EnablePasswordReset; }
        }

        /// <summary>
        /// Whether or not it is possible to retrieve the password of a user.
        /// </summary>
        public bool EnablePasswordRetrieval
        {
            get { return Membership.EnablePasswordRetrieval; }
        }

        /// <summary>
        /// The currently used hash algorithm.
        /// </summary>
        public string HashAlgorithmType
        {
            get { return Membership.HashAlgorithmType; }
        }

        /// <summary>
        /// Get the max number of password attempts before the user is locked out.
        /// </summary>
        public int MaxInvalidPasswordAttempts
        {
            get { return Membership.MaxInvalidPasswordAttempts; }
        }

        /// <summary>
        /// Get the minimum required password length.
        /// </summary>
        public int MinPasswordLength
        {
            get { return Membership.MinRequiredPasswordLength; }
        }

        /// <summary>
        /// Get the min number of required non-alphanumeric characters.
        /// </summary>
        public int MinRequiredNonAlphanumericCharacters
        {
            get { return Membership.MinRequiredNonAlphanumericCharacters; }
        }

        /// <summary>
        /// Get the password strength regular expression.
        /// </summary>
        public string PasswordStrengthRegularExpression
        {
            get { return Membership.PasswordStrengthRegularExpression; }
        }

        /// <summary>
        /// Whether or not a question and answer is required when reseting and retrieving passwords.
        /// </summary>
        public bool RequiresQuestionAndAnswer
        {
            get { return Membership.RequiresQuestionAndAnswer; }
        }


        /// <summary>
        /// Change the password of a certain user.
        /// </summary>
        /// <param name="user">The user of interest.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>Whether or not the password changed.</returns>
        public bool ChangePassword(MembershipUser user, string oldPassword, string newPassword)
        {
            return user.ChangePassword(oldPassword, newPassword);
        }

        /// <summary>
        /// Create a new membership user.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The user password.</param>
        /// <returns>The created user, if any.</returns>
        public MembershipUser CreateUser(string userName, string password)
        {
            return Membership.CreateUser(userName, password);
        }

        /// <summary>
        /// Create a new membership user.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The user password.</param>
        /// <param name="email">The user's e-mail address.</param>
        /// <returns>The created user, if any.</returns>
        public MembershipUser CreateUser(string userName, string password, string email)
        {
            return Membership.CreateUser(userName, password, email);
        }

        /// <summary>
        /// Create a new membership user.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The user password.</param>
        /// <param name="email">The user's e-mail address.</param>
        /// <param name="passwordQuestion">The user's password question.</param>
        /// <param name="passwordAnswer">The user's password answer.</param>
        /// <param name="isApproved">Whether or not the user should be approved from start.</param>
        /// <param name="status">A status indicating if the user could be created or, if not, why the crewation failed.</param>
        /// <returns>The created user, if any.</returns>
        public MembershipUser CreateUser(string userName, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, out MembershipCreateStatus status)
        {
            return Membership.CreateUser(userName, password, email, passwordQuestion, passwordAnswer, isApproved, out status);
        }

        /// <summary>
        /// Create a new membership user.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The user password.</param>
        /// <param name="email">The user's e-mail address.</param>
        /// <param name="passwordQuestion">The user's password question.</param>
        /// <param name="passwordAnswer">The user's password answer.</param>
        /// <param name="isApproved">Whether or not the user should be approved from start.</param>
        /// <param name="providerUserKey">Membership provider user key.</param>
        /// <param name="status">A status indicating if the user could be created or, if not, why the crewation failed.</param>
        /// <returns>The created user, if any.</returns>
        public MembershipUser CreateUser(string userName, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            return Membership.CreateUser(userName, password, email, passwordQuestion, passwordAnswer, isApproved, providerUserKey, out status);
        }

        /// <summary>
        /// Delete a certain user.
        /// </summary>
        /// <param name="userName">The name of the user to delete.</param>
        public bool DeleteUser(string userName)
        {
            return Membership.DeleteUser(userName);
        }

        /// <summary>
        /// Delete a certain user.
        /// </summary>
        /// <param name="userName">The name of the user to delete.</param>
        /// <param name="deleteAllRelatedData">Whether or not to delete all related data for the user.</param>
        public bool DeleteUser(string userName, bool deleteAllRelatedData)
        {
            return Membership.DeleteUser(userName, deleteAllRelatedData);
        }

        /// <summary>
        /// Get membership users by user name.
        /// </summary>
        /// <param name="userNameToMatch">The user name to search for.</param>
        /// <returns>The resulting membership user collection, if any.</returns>
        public MembershipUserCollection FindUsersByName(string userNameToMatch)
        {
            return Membership.FindUsersByName(userNameToMatch);
        }

        /// <summary>
        /// Get membership users by user name.
        /// </summary>
        /// <param name="userNameToMatch">The user name to search for.</param>
        /// <param name="pageIndex">The index of the page to return.</param>
        /// <param name="pageSize">The max amount of hits per page.</param>
        /// <param name="totalRecords">The total numbers of matched users.</param>
        /// <returns>The resulting membership user collection, if any.</returns>
        public MembershipUserCollection FindUsersByName(string userNameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            return Membership.FindUsersByName(userNameToMatch, pageIndex, pageSize, out totalRecords);
        }

        /// <summary>
        /// Get membership users by user e-mail.
        /// </summary>
        /// <param name="emailToMatch">The e-mail address to search for.</param>
        /// <returns>The resulting membership user collection, if any.</returns>
        public MembershipUserCollection FindUsersByEmail(string emailToMatch)
        {
            return Membership.FindUsersByEmail(emailToMatch);
        }

        /// <summary>
        /// Get membership users by user Email.
        /// </summary>
        /// <param name="emailToMatch">The e-mail address to search for.</param>
        /// <param name="pageIndex">The index of the page to return.</param>
        /// <param name="pageSize">The max amount of hits per page.</param>
        /// <param name="totalRecords">The total numbers of matched users.</param>
        /// <returns>The resulting membership user collection, if any.</returns>
        public MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            return Membership.FindUsersByEmail(emailToMatch, pageIndex, pageSize, out totalRecords);
        }

        /// <summary>
        /// Get membership users by user Email.
        /// </summary>
        /// <param name="length">The length of the password.</param>
        /// <param name="numberOfNonAlphanumericCharacters">The number of non-alphanumeric characters.</param>
        /// <returns>The resulting membership user collection, if any.</returns>
        public string GeneratePassword(int length, int numberOfNonAlphanumericCharacters)
        {
            return Membership.GeneratePassword(length, numberOfNonAlphanumericCharacters);
        }

        /// <summary>
        /// Get a collection with all existing users.
        /// </summary>
        /// <returns>The resulting membership user collection, if any.</returns>
        public MembershipUserCollection GetAllUsers()
        {
            return Membership.GetAllUsers();
        }

        /// <summary>
        /// Get a collection with all existing users.
        /// </summary>
        /// <param name="pageIndex">The index of the page to return.</param>
        /// <param name="pageSize">The max amount of hits per page.</param>
        /// <param name="totalRecords">The total numbers of matched users.</param>
        /// <returns>The resulting membership user collection, if any.</returns>
        public MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            return Membership.GetAllUsers(pageIndex, pageSize, out totalRecords);
        }

        /// <summary>
        /// Get the number of currently online users.
        /// </summary>
        /// <returns>The number of currently online users.</returns>
        public int GetNumbersOfUsersOnline()
        {
            return Membership.GetNumberOfUsersOnline();
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
        /// Get the currently logged in user.
        /// </summary>
        /// <param name="userIsOnline">If true, update the last activity date time for the user.</param>
        /// <returns>The currently logged in user.</returns>
        public MembershipUser GetUser(bool userIsOnline)
        {
            return Membership.GetUser(userIsOnline);
        }

        /// <summary>
        /// Get a certain user.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <returns>The corresponding user, if any.</returns>
        public MembershipUser GetUser(string userName)
        {
            return Membership.GetUser(userName);
        }

        /// <summary>
        /// Get a certain user.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="userIsOnline">If true, update the last activity date time for the user.</param>
        /// <returns>The corresponding user, if any.</returns>
        public MembershipUser GetUser(string userName, bool userIsOnline)
        {
            return Membership.GetUser(userName);
        }

        /// <summary>
        /// Get the user name for a certain e-mail address.
        /// </summary>
        /// <param name="email">The e-mail address of interest.</param>
        /// <returns>The corresponding user name, if any.</returns>
        public string GetUserNameByEmail(string email)
        {
            return Membership.GetUserNameByEmail(email);
        }

        /// <summary>
        /// Reset the password of a certain membership user.
        /// </summary>
        /// <param name="user">The user to affect.</param>
        /// <returns>The new, auto-generated password.</returns>
        public string ResetPassword(MembershipUser user)
        {
            return user.ResetPassword();
        }

        /// <summary>
        /// Reset the password of a certain membership user.
        /// </summary>
        /// <param name="user">The user to affect.</param>
        /// <param name="passwordAnswer">The password answer for the user.</param>
        /// <returns>The new, auto-generated password.</returns>
        public string ResetPassword(MembershipUser user, string passwordAnswer)
        {
            return user.ResetPassword(passwordAnswer);
        }

        /// <summary>
        /// Unlock a certain user.
        /// </summary>
        /// <param name="user">The user to affect.</param>
        /// <returns>Whether or not the user was unlocked.</returns>
        public bool Unlock(MembershipUser user)
        {
            return user.UnlockUser();
        }

        /// <summary>
        /// Update a certain user.
        /// </summary>
        /// <param name="user">The user to update.</param>
        public void UpdateUser(MembershipUser user)
        {
            Membership.UpdateUser(user);
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
        /// Verifies that a user name and password are valid.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The user password.</param>
        /// <returns>Whether or not the user name and password are valid</returns>
        public bool ValidateUser(string userName, string password)
        {
            return Membership.ValidateUser(userName, password);
        }
    }
}
