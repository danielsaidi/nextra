using System;

namespace NExtra.UI
{
    /// <summary>
    /// This interface can be implemented by any class that should
    /// be able to submit an operation, that it is responsible for.
    /// </summary>
    [Obsolete("This class is useless and will be removed in 2.6.0.0")]
    public interface ICanSubmit
    {
        ///<summary>
        /// This event is trigged when the operation is submitted.
        ///</summary>
        event EventHandler Submit;

        /// <summary>
        /// Whether or not the operation has been submitted.
        /// </summary>
        bool Submitted { get; }

        /// <summary>
        /// Trigger the Submit event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        void OnSubmit(EventArgs e);
    }
}
