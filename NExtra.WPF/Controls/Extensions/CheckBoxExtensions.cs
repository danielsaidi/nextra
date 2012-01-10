using System.Windows.Controls;

namespace NExtra.WPF.Controls.Extensions
{
    /// <summary>
    /// Extension methods for System.Windows.Controls.CheckBox.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public static class CheckBoxExtensions
    {
        /// <summary>
        /// Get the ThreeState state of a checkbox.
        /// </summary>
        public static ThreeState State(this CheckBox checkBox)
        {
            if (!checkBox.IsChecked.HasValue)
                return ThreeState.Undetermined;
            return checkBox.IsChecked.Value ? ThreeState.Checked : ThreeState.Unchecked;
        }
    }
}