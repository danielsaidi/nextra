using EPiServer.Personalization;

namespace NExtra.EpiServer.Profile.Abstractions
{
    public interface ICanCreateEPiServerProfile
    {
        EPiServerProfile CreateEPiServerProfile(string userName, string company, string email, string firstName, string lastName, string title);
    }
}
