using System;

namespace NExtra.Web.Security.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// should be able to provide authentication services.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Sign in a certain user name.
        /// </summary>
        /// <param name="userName">The user name to sign in.</param>
        /// <param name="createPersistentCookie">Whether or not to create a persistent cookie.</param>
        void SignIn(string userName, bool createPersistentCookie);

        /// <summary>
        /// Sign out the currently signed in user.
        /// </summary>
        void SignOut();
    }



    /// <summary>
    /// This class is deprecated.
    /// </summary>
    [Obsolete("Use the IAuthenticationService interface instead.")]
    public interface IAuthenticationFacade
    {
        /// <summary>
        /// Sign in a certain user name.
        /// </summary>
        /// <param name="userName">The user name to sign in.</param>
        /// <param name="createPersistentCookie">Whether or not to create a persistent cookie.</param>
        void SignIn(string userName, bool createPersistentCookie);

        /// <summary>
        /// Sign out the currently signed in user.
        /// </summary>
        void SignOut();
    }

}
