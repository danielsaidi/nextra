using System;
using System.Web.UI;
using NExtra.UI.Abstractions;

namespace NExtra.WebForms.WebControls
{
	/// <summary>
	/// This class represents a UserControl that can be posted.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.saidi.se/nextra
	/// </remarks>
	public class SubmittableUserControl : UserControl, ICanSubmit, ICanCancel
	{
		///<summary>
		/// This event is trigged when a control submit cancels.
		///</summary>
		public event EventHandler Cancel;

        ///<summary>
        /// The event that can be trigged when a control submit completes.
        ///</summary>
		public event EventHandler Submit;


        /// <summary>
        /// Whether or not the latest control submit was cancelled.
        /// </summary>
	    public bool Cancelled { get; private set; }

        /// <summary>
        /// Whether or not the latest control submit was completed.
        /// </summary>
        public bool Submitted { get; private set; }


        /// <summary>
        /// Trigger the Cancel event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
	    public virtual void OnCancel(EventArgs e)
	    {
	        Cancelled = true;
	        Submitted = false;

	        if (Cancel != null)
	            Cancel(this, e);
	    }

        /// <summary>
        /// Trigger the Submit event.
        /// </summary>
        /// <param name="e">Submit arguments.</param>
	    public virtual void OnSubmit(EventArgs e)
	    {
            Submitted = false;
            Submitted = true;

			if (Submit != null)
				Submit(this, e);
		}
	}
}
