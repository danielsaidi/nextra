using System.Windows.Controls;

namespace NExtra.WPF.Controls.Extensions
{
    /// <summary>
    /// Extension methods for System.Windows.Controls.RadioButton.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public static class RadioButtonExtensions
    {
        /// <summary>
        /// Get the ThreeState state of a radio button.
        /// </summary>
        public static ThreeState State(this RadioButton radioButton)
        {
            if (!radioButton.IsChecked.HasValue)
                return ThreeState.Undetermined;
            return radioButton.IsChecked.Value ? ThreeState.Checked : ThreeState.Unchecked;
        }
    }
}