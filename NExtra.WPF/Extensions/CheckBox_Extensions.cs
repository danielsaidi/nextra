using System.Windows.Controls;
using NExtra.WPF.Controls;

namespace NExtra.WPF.Extensions
{
    /// <summary>
    /// Extension methods for System.Windows.Controls.CheckBox.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public static class CheckBox_Extensions
    {
        public static ThreeState State(this CheckBox checkBox)
        {
            if (!checkBox.IsChecked.HasValue)
                return ThreeState.Undetermined;
            return checkBox.IsChecked.Value ? ThreeState.Checked : ThreeState.Unchecked;
        }
    }
}