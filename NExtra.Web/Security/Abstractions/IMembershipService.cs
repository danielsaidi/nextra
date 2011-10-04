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
        /// Change the password of a certain user.
        /// </summary>
        /// <param name="user">The user of interest.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>Whether or not the password changed.</returns>
        bool ChangePassword(MembershipUser user, string oldPassword, string newPassword);

        /// <summary>
        /// Create a new membership user.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The user password.</param>
        /// <returns>The created user, if any.</returns>
        MembershipUser CreateUser(string userName, string password);

        /// <summary>
        /// Create a new membership user.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The user password.</param>
        /// <param name="email">The user's e-mail address.</param>
        /// <returns>The created user, if any.</returns>
        MembershipUser CreateUser(string userName, string password, string email);

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
        MembershipUser CreateUser(string userName, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, out MembershipCreateStatus status);

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
        MembershipUser CreateUser(string userName, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status);

        /// <summary>
        /// Create a new membership user.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The user password.</param>
        /// <param name="email">The user's e-mail address.</param>
        /// <param name="isApproved">Whether or not the user should be approved from start.</param>
        /// <returns>The creation result.</returns>
        MembershipCreateStatus CreateUser(string userName, string password, string email, bool isApproved);

        /// <summary>
        /// Delete a certain user.
        /// </summary>
        /// <param name="userName">The name of the user to delete.</param>
        bool DeleteUser(string userName);

        /// <summary>
        /// Delete a certain user.
        /// </summary>
        /// <param name="userName">The name of the user to delete.</param>
        /// <param name="deleteAllRelatedData">Whether or not to delete all related data for the user.</param>
        bool DeleteUser(string userName, bool deleteAllRelatedData);

        /// <summary>
        /// Get membership users by user name.
        /// </summary>
        /// <param name="userNameToMatch">The user name to search for.</param>
        /// <returns>The resulting membership user collection, if any.</returns>
        MembershipUserCollection FindUsersByName(string userNameToMatch);

        /// <summary>
        /// Get membership users by user name.
        /// </summary>
        /// <param name="userNameToMatch">The user name to search for.</param>
        /// <param name="pageIndex">The index of the page to return.</param>
        /// <param name="pageSize">The max amount of hits per page.</param>
        /// <param name="totalRecords">The total numbers of matched users.</param>
        /// <returns>The resulting membership user collection, if any.</returns>
        MembershipUserCollection FindUsersByName(string userNameToMatch, int pageIndex, int pageSize, out int totalRecords);

        /// <summary>
        /// Get membership users by user e-mail.
        /// </summary>
        /// <param name="emailToMatch">The e-mail address to search for.</param>
        /// <returns>The resulting membership user collection, if any.</returns>
        MembershipUserCollection FindUsersByEmail(string emailToMatch);

        /// <summary>
        /// Get membership users by user Email.
        /// </summary>
        /// <param name="emailToMatch">The e-mail address to search for.</param>
        /// <param name="pageIndex">The index of the page to return.</param>
        /// <param name="pageSize">The max amount of hits per page.</param>
        /// <param name="totalRecords">The total numbers of matched users.</param>
        /// <returns>The resulting membership user collection, if any.</returns>
        MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords);

        /// <summary>
        /// Get membership users by user Email.
        /// </summary>
        /// <param name="length">The length of the password.</param>
        /// <param name="numberOfNonAlphanumericCharacters">The number of non-alphanumeric characters.</param>
        /// <returns>The resulting membership user collection, if any.</returns>
        string GeneratePassword(int length, int numberOfNonAlphanumericCharacters);

        /// <summary>
        /// Get a collection with all existing users.
        /// </summary>
        /// <returns>The resulting membership user collection, if any.</returns>
        MembershipUserCollection GetAllUsers();

        /// <summary>
        /// Get a collection with all existing users.
        /// </summary>
        /// <param name="pageIndex">The index of the page to return.</param>
        /// <param name="pageSize">The max amount of hits per page.</param>
        /// <param name="totalRecords">The total numbers of matched users.</param>
        /// <returns>The resulting membership user collection, if any.</returns>
        MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords);

        /// <summary>
        /// Get the currently logged in user.
        /// </summary>
        /// <returns>The currently logged in user.</returns>
        MembershipUser GetUser();

        /// <summary>
        /// Get the currently logged in user.
        /// </summary>
        /// <param name="userIsOnline">Whether or not the user is currently online..</param>
        /// <returns>The currently logged in user.</returns>
        MembershipUser GetUser(bool userIsOnline);

        /// <summary>
        /// Get a certain user.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <returns>The corresponding user, if any.</returns>
        MembershipUser GetUser(string userName);

        /// <summary>
        /// Get a certain user.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="userIsOnline">Whether or not the user is currently online..</param>
        /// <returns>The corresponding user, if any.</returns>
        MembershipUser GetUser(string userName, bool userIsOnline);

        /// <summary>
        /// Get the user name for a certain e-mail address.
        /// </summary>
        /// <param name="email">The e-mail address of interest.</param>
        /// <returns>The corresponding user name, if any.</returns>
        string GetUserNameByEmail(string email);

        /// <summary>
        /// Reset the password of a certain membership user.
        /// </summary>
        /// <param name="user">The user to affect.</param>
        /// <returns>The new, auto-generated password.</returns>
        string ResetPassword(MembershipUser user);

        /// <summary>
        /// Reset the password of a certain membership user.
        /// </summary>
        /// <param name="user">The user to affect.</param>
        /// <param name="passwordAnswer">The password answer for the user.</param>
        /// <returns>The new, auto-generated password.</returns>
        string ResetPassword(MembershipUser user, string passwordAnswer);

        /// <summary>
        /// Unlock a certain user.
        /// </summary>
        /// <param name="user">The user to affect.</param>
        /// <returns>Whether or not the user was unlocked.</returns>
        bool Unlock(MembershipUser user);

        /// <summary>
        /// Update a certain user.
        /// </summary>
        /// <param name="user">The user to update.</param>
        void UpdateUser(MembershipUser user);

        /// <summary>
        /// Check whether or not a certain user exists.
        /// </summary>
        /// <param name="userName">The user name of interest.</param>
        /// <returns>Whether or not the user exists.</returns>
        bool UserExists(string userName);

        /// <summary>
        /// Verifies that a user name and password are valid.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The user password.</param>
        /// <returns>Whether or not the user name and password are valid</returns>
        bool ValidateUser(string userName, string password);
    }
}
