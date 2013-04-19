using System.Web.Security;

namespace NExtra.Web.Security
{
    /// <summary>
    /// This class can be used as a facade for the static
    /// Membership class.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class MembershipFacade : IMembershipService
    {
        public string ApplicationName
        {
            get { return Membership.ApplicationName; }
            set { Membership.ApplicationName = value; }
        }

        public bool EnablePasswordReset
        {
            get { return Membership.EnablePasswordReset; }
        }

        public bool EnablePasswordRetrieval
        {
            get { return Membership.EnablePasswordRetrieval; }
        }

        public string HashAlgorithmType
        {
            get { return Membership.HashAlgorithmType; }
        }

        public int MaxInvalidPasswordAttempts
        {
            get { return Membership.MaxInvalidPasswordAttempts; }
        }

        public int MinPasswordLength
        {
            get { return Membership.MinRequiredPasswordLength; }
        }

        public int MinRequiredNonAlphanumericCharacters
        {
            get { return Membership.MinRequiredNonAlphanumericCharacters; }
        }

        public string PasswordStrengthRegularExpression
        {
            get { return Membership.PasswordStrengthRegularExpression; }
        }

        public bool RequiresQuestionAndAnswer
        {
            get { return Membership.RequiresQuestionAndAnswer; }
        }


        public bool ChangePassword(MembershipUser user, string oldPassword, string newPassword)
        {
            return user.ChangePassword(oldPassword, newPassword);
        }

        public MembershipUser CreateUser(string userName, string password)
        {
            return Membership.CreateUser(userName, password);
        }

        public MembershipUser CreateUser(string userName, string password, string email)
        {
            return Membership.CreateUser(userName, password, email);
        }

        public MembershipUser CreateUser(string userName, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, out MembershipCreateStatus status)
        {
            return Membership.CreateUser(userName, password, email, passwordQuestion, passwordAnswer, isApproved, out status);
        }

        public MembershipUser CreateUser(string userName, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            return Membership.CreateUser(userName, password, email, passwordQuestion, passwordAnswer, isApproved, providerUserKey, out status);
        }

        public MembershipCreateStatus CreateUser(string userName, string password, string email, bool isApproved)
        {
            MembershipCreateStatus result;
            Membership.CreateUser(userName, password, email, null, null, isApproved, null, out result);
            return result;
        }

        public bool DeleteUser(string userName)
        {
            return Membership.DeleteUser(userName);
        }

        public bool DeleteUser(string userName, bool deleteAllRelatedData)
        {
            return Membership.DeleteUser(userName, deleteAllRelatedData);
        }

        public MembershipUserCollection FindUsersByName(string userNameToMatch)
        {
            return Membership.FindUsersByName(userNameToMatch);
        }

        public MembershipUserCollection FindUsersByName(string userNameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            return Membership.FindUsersByName(userNameToMatch, pageIndex, pageSize, out totalRecords);
        }

        public MembershipUserCollection FindUsersByEmail(string emailToMatch)
        {
            return Membership.FindUsersByEmail(emailToMatch);
        }

        public MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            return Membership.FindUsersByEmail(emailToMatch, pageIndex, pageSize, out totalRecords);
        }

        public string GeneratePassword(int length, int numberOfNonAlphanumericCharacters)
        {
            return Membership.GeneratePassword(length, numberOfNonAlphanumericCharacters);
        }

        public MembershipUserCollection GetAllUsers()
        {
            return Membership.GetAllUsers();
        }

        public MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            return Membership.GetAllUsers(pageIndex, pageSize, out totalRecords);
        }

        public int GetNumbersOfUsersOnline()
        {
            return Membership.GetNumberOfUsersOnline();
        }

        public MembershipUser GetUser()
        {
            return Membership.GetUser();
        }

        public MembershipUser GetUser(bool userIsOnline)
        {
            return Membership.GetUser(userIsOnline);
        }

        public MembershipUser GetUser(string userName)
        {
            return Membership.GetUser(userName);
        }

        public MembershipUser GetUser(string userName, bool userIsOnline)
        {
            return Membership.GetUser(userName);
        }

        public string GetUserNameByEmail(string email)
        {
            return Membership.GetUserNameByEmail(email);
        }

        public string ResetPassword(MembershipUser user)
        {
            return user.ResetPassword();
        }

        public string ResetPassword(MembershipUser user, string passwordAnswer)
        {
            return user.ResetPassword(passwordAnswer);
        }

        public bool Unlock(MembershipUser user)
        {
            return user.UnlockUser();
        }

        public void UpdateUser(MembershipUser user)
        {
            Membership.UpdateUser(user);
        }

        public bool UserExists(string userName)
        {
            return GetUser(userName) != null;
        }

        public bool ValidateUser(string userName, string password)
        {
            return Membership.ValidateUser(userName, password);
        }
    }
}
