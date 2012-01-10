namespace NExtra.WPF.Controls
{
    /// <summary>
    /// ThreeState state enum.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public enum ThreeState
    {
        /// <summary>
        /// When a ThreeState control is in this state, sub-groups are both checked and unchecked.
        /// </summary>
        Undetermined = -1,

        /// <summary>
        /// When a ThreeState control is in this state, it is unchecked.
        /// </summary>
        Unchecked = 0,

        /// <summary>
        /// When a ThreeState control is in this state, it is checked.
        /// </summary>
        Checked = 1
    }
}
