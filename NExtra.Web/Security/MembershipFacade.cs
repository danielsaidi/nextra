using System.Web.Security;

namespace NExtra.Web.Security
{
    /// <summary>
    /// This class can be used as a facade for the
    /// static Membership class.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class MembershipFacade : IMembershipService
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
        public bool ChangePassword(MembershipUser user, string oldPassword, string newPassword)
        {
            return user.ChangePassword(oldPassword, newPassword);
        }

        /// <summary>
        /// Create a new membership user.
        /// </summary>
        public MembershipUser CreateUser(string userName, string password)
        {
            return Membership.CreateUser(userName, password);
        }

        /// <summary>
        /// Create a new membership user.
        /// </summary>
        public MembershipUser CreateUser(string userName, string password, string email)
        {
            return Membership.CreateUser(userName, password, email);
        }

        /// <summary>
        /// Create a new membership user.
        /// </summary>
        public MembershipUser CreateUser(string userName, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, out MembershipCreateStatus status)
        {
            return Membership.CreateUser(userName, password, email, passwordQuestion, passwordAnswer, isApproved, out status);
        }

        /// <summary>
        /// Create a new membership user.
        /// </summary>
        public MembershipUser CreateUser(string userName, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            return Membership.CreateUser(userName, password, email, passwordQuestion, passwordAnswer, isApproved, providerUserKey, out status);
        }

        /// <summary>
        /// Create a new membership user.
        /// </summary>
        public MembershipCreateStatus CreateUser(string userName, string password, string email, bool isApproved)
        {
            MembershipCreateStatus result;
            Membership.CreateUser(userName, password, email, null, null, isApproved, null, out result);
            return result;
        }

        /// <summary>
        /// Delete a certain user.
        /// </summary>
        public bool DeleteUser(string userName)
        {
            return Membership.DeleteUser(userName);
        }

        /// <summary>
        /// Delete a certain user.
        /// </summary>
        public bool DeleteUser(string userName, bool deleteAllRelatedData)
        {
            return Membership.DeleteUser(userName, deleteAllRelatedData);
        }

        /// <summary>
        /// Get membership users by user name.
        /// </summary>
        public MembershipUserCollection FindUsersByName(string userNameToMatch)
        {
            return Membership.FindUsersByName(userNameToMatch);
        }

        /// <summary>
        /// Get membership users by user name.
        /// </summary>
        public MembershipUserCollection FindUsersByName(string userNameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            return Membership.FindUsersByName(userNameToMatch, pageIndex, pageSize, out totalRecords);
        }

        /// <summary>
        /// Get membership users by user e-mail.
        /// </summary>
        public MembershipUserCollection FindUsersByEmail(string emailToMatch)
        {
            return Membership.FindUsersByEmail(emailToMatch);
        }

        /// <summary>
        /// Get membership users by user Email.
        /// </summary>
        public MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            return Membership.FindUsersByEmail(emailToMatch, pageIndex, pageSize, out totalRecords);
        }

        /// <summary>
        /// Get membership users by user Email.
        /// </summary>
        public string GeneratePassword(int length, int numberOfNonAlphanumericCharacters)
        {
            return Membership.GeneratePassword(length, numberOfNonAlphanumericCharacters);
        }

        /// <summary>
        /// Get a collection with all existing users.
        /// </summary>
        public MembershipUserCollection GetAllUsers()
        {
            return Membership.GetAllUsers();
        }

        /// <summary>
        /// Get a collection with all existing users.
        /// </summary>
        public MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            return Membership.GetAllUsers(pageIndex, pageSize, out totalRecords);
        }

        /// <summary>
        /// Get the number of currently online users.
        /// </summary>
        public int GetNumbersOfUsersOnline()
        {
            return Membership.GetNumberOfUsersOnline();
        }

        /// <summary>
        /// Get the currently logged in user.
        /// </summary>
        public MembershipUser GetUser()
        {
            return Membership.GetUser();
        }

        /// <summary>
        /// Get the currently logged in user.
        /// </summary>
        public MembershipUser GetUser(bool userIsOnline)
        {
            return Membership.GetUser(userIsOnline);
        }

        /// <summary>
        /// Get a certain user.
        /// </summary>
        public MembershipUser GetUser(string userName)
        {
            return Membership.GetUser(userName);
        }

        /// <summary>
        /// Get a certain user.
        /// </summary>
        public MembershipUser GetUser(string userName, bool userIsOnline)
        {
            return Membership.GetUser(userName);
        }

        /// <summary>
        /// Get the user name for a certain e-mail address.
        /// </summary>
        public string GetUserNameByEmail(string email)
        {
            return Membership.GetUserNameByEmail(email);
        }

        /// <summary>
        /// Reset the password of a certain membership user.
        /// </summary>
        public string ResetPassword(MembershipUser user)
        {
            return user.ResetPassword();
        }

        /// <summary>
        /// Reset the password of a certain membership user.
        /// </summary>
        public string ResetPassword(MembershipUser user, string passwordAnswer)
        {
            return user.ResetPassword(passwordAnswer);
        }

        /// <summary>
        /// Unlock a certain user.
        /// </summary>
        public bool Unlock(MembershipUser user)
        {
            return user.UnlockUser();
        }

        /// <summary>
        /// Update a certain user.
        /// </summary>
        public void UpdateUser(MembershipUser user)
        {
            Membership.UpdateUser(user);
        }

        /// <summary>
        /// Check whether or not a certain user exists.
        /// </summary>
        public bool UserExists(string userName)
        {
            return GetUser(userName) != null;
        }

        /// <summary>
        /// Verifies that a user name and password are valid.
        /// </summary>
        public bool ValidateUser(string userName, string password)
        {
            return Membership.ValidateUser(userName, password);
        }
    }
}
