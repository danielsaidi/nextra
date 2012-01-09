using System.Web.Security;

namespace NExtra.Web.Security
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// provides membership services.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public interface IMembershipService
    {
        /// <summary>
        /// Gets or sets the name of the application.
        /// </summary>
        string ApplicationName { get; set; }

        /// <summary>
        /// Whether or not it is possible to reset the password of a user.
        /// </summary>
        bool EnablePasswordReset { get; }

        /// <summary>
        /// Whether or not it is possible to retrieve the password of a user.
        /// </summary>
        bool EnablePasswordRetrieval { get; }

        /// <summary>
        /// The currently used hash algorithm.
        /// </summary>
        string HashAlgorithmType { get; }

        /// <summary>
        /// Get the max number of password attempts before the user is locked out.
        /// </summary>
        int MaxInvalidPasswordAttempts { get; }

        /// <summary>
        /// The minimum amount of chars in a password.
        /// </summary>
        int MinPasswordLength { get; }

        /// <summary>
        /// Get the min number of required non-alphanumeric characters.
        /// </summary>
        int MinRequiredNonAlphanumericCharacters { get; }

        /// <summary>
        /// Get the password strength regular expression.
        /// </summary>
        string PasswordStrengthRegularExpression { get; }

        /// <summary>
        /// Whether or not a question and answer is required when reseting and retrieving passwords.
        /// </summary>
        bool RequiresQuestionAndAnswer { get; }


        /// <summary>
        /// Change the password for a certain user.
        /// </summary>
        bool ChangePassword(MembershipUser user, string oldPassword, string newPassword);

        /// <summary>
        /// Create a new membership user.
        /// </summary>
        MembershipUser CreateUser(string userName, string password);

        /// <summary>
        /// Create a new membership user.
        /// </summary>
        MembershipUser CreateUser(string userName, string password, string email);

        /// <summary>
        /// Create a new membership user.
        /// </summary>
        MembershipUser CreateUser(string userName, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, out MembershipCreateStatus status);

        /// <summary>
        /// Create a new membership user.
        /// </summary>
        MembershipUser CreateUser(string userName, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status);

        /// <summary>
        /// Create a new membership user.
        /// </summary>
        MembershipCreateStatus CreateUser(string userName, string password, string email, bool isApproved);

        /// <summary>
        /// Delete a certain user.
        /// </summary>
        bool DeleteUser(string userName);

        /// <summary>
        /// Delete a certain user.
        /// </summary>
        bool DeleteUser(string userName, bool deleteAllRelatedData);

        /// <summary>
        /// Get membership users by user name.
        /// </summary>
        MembershipUserCollection FindUsersByName(string userNameToMatch);

        /// <summary>
        /// Get membership users by user name.
        /// </summary>
        MembershipUserCollection FindUsersByName(string userNameToMatch, int pageIndex, int pageSize, out int totalRecords);

        /// <summary>
        /// Get membership users by user e-mail.
        /// </summary>
        MembershipUserCollection FindUsersByEmail(string emailToMatch);

        /// <summary>
        /// Get membership users by user Email.
        /// </summary>
        MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords);

        /// <summary>
        /// Get membership users by user Email.
        /// </summary>
        string GeneratePassword(int length, int numberOfNonAlphanumericCharacters);

        /// <summary>
        /// Get a collection with all existing users.
        /// </summary>
        MembershipUserCollection GetAllUsers();

        /// <summary>
        /// Get a collection with all existing users.
        /// </summary>
        MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords);

        /// <summary>
        /// Get the currently logged in user.
        /// </summary>
        MembershipUser GetUser();

        /// <summary>
        /// Get the currently logged in user and set its online status.
        /// </summary>
        MembershipUser GetUser(bool userIsOnline);

        /// <summary>
        /// Get a certain user.
        /// </summary>
        MembershipUser GetUser(string userName);

        /// <summary>
        /// Get a certain user and set its online status.
        /// </summary>
        MembershipUser GetUser(string userName, bool userIsOnline);

        /// <summary>
        /// Get the user name for a certain e-mail address.
        /// </summary>
        string GetUserNameByEmail(string email);

        /// <summary>
        /// Reset the password for a certain membership user.
        /// </summary>
        string ResetPassword(MembershipUser user);

        /// <summary>
        /// Reset the password for a certain membership user.
        /// </summary>
        string ResetPassword(MembershipUser user, string passwordAnswer);

        /// <summary>
        /// Unlock a certain user.
        /// </summary>
        bool Unlock(MembershipUser user);

        /// <summary>
        /// Update a certain user.
        /// </summary>
        void UpdateUser(MembershipUser user);

        /// <summary>
        /// Check whether or not a certain user exists.
        /// </summary>
        bool UserExists(string userName);

        /// <summary>
        /// Verifies that a user name and password are valid.
        /// </summary>
        bool ValidateUser(string userName, string password);
    }
}
