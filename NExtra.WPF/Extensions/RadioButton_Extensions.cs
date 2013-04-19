using System.Windows.Controls;
using NExtra.WPF.Controls;

namespace NExtra.WPF.Extensions
{
    /// <summary>
    /// Extension methods for System.Windows.Controls.RadioButton.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public static class RadioButton_Extensions
    {
        public static ThreeState State(this RadioButton radioButton)
        {
            if (!radioButton.IsChecked.HasValue)
                return ThreeState.Undetermined;
            return radioButton.IsChecked.Value ? ThreeState.Checked : ThreeState.Unchecked;
        }
    }
}