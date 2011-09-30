using System.Web.Security;

namespace NExtra.Web.Testing
{
    /// <summary>
    /// This class inherits MembershipUser and can be
    /// used to create membership user instances that
    /// can be used in, for instance, test context.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class FakeMembershipUser : MembershipUser
    {
    }
}
