using System;

namespace NExtra.UI
{
    /// <summary>
    /// This interface can be implemented by any class that should
    /// be able to cancel an operation, that it is responsible for.
    /// </summary>
    [Obsolete("This class is useless and will be removed in 2.6.0.0")]
    public interface ICanCancel
    {
        ///<summary>
        /// This event is trigged when the operation is cancelled.
        ///</summary>
        event EventHandler Cancel;

        /// <summary>
        /// Whether or not the operation has been cancelled.
        /// </summary>
        bool Cancelled { get; }

        /// <summary>
        /// Trigger the Cancel event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        void OnCancel(EventArgs e);
    }
}
