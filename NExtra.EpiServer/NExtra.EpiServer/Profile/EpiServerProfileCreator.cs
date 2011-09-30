using EPiServer.Personalization;
using NExtra.EpiServer.Profile.Abstractions;

namespace NExtra.EpiServer.Profile
{
    /// <summary>
    /// This class can be used to create an EPiServerProfile.
    /// </summary>
    public class EpiServerProfileCreator : ICanCreateEPiServerProfile
    {
        /// <summary>
        /// Create an EPiServer profile.
        /// </summary>
        /// <returns>The created profile.</returns>
        public EPiServerProfile CreateEPiServerProfile(string userName, string company, string email, string firstName, string lastName, string title)
        {
            var profile = EPiServerProfile.Get(userName);
            profile.Company = company;
            profile.Email = email;
            profile.FirstName = firstName;
            profile.LastName = lastName;
            profile.Title = title;

            profile.Save();
            return profile;
        }
    }
}
