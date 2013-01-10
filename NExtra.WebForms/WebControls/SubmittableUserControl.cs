using System;
using System.Web.UI;

namespace NExtra.WebForms.WebControls
{
	/// <summary>
	/// This class represents a submittable as well as
	/// cancelable user control.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://danielsaidi.github.com/nextra
	/// </remarks>
	public class SubmittableUserControl : UserControl
	{
		///<summary>
		/// This event is triggered when a control cancels.
		///</summary>
		public event EventHandler Cancel;

        ///<summary>
        /// This event is triggered when a control submits.
        ///</summary>
		public event EventHandler Submit;


        /// <summary>
        /// Trigger the Cancel event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
	    public virtual void OnCancel(EventArgs e)
	    {
	        if (Cancel != null)
	            Cancel(this, e);
	    }

        /// <summary>
        /// Trigger the Submit event.
        /// </summary>
        /// <param name="e">Submit arguments.</param>
	    public virtual void OnSubmit(EventArgs e)
	    {
			if (Submit != null)
				Submit(this, e);
		}
	}
}
