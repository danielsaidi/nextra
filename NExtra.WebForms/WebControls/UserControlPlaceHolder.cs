using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using NExtra.Web.Extensions;

namespace NExtra.WebForms.WebControls
{
	/// <summary>
	/// This class can be used to dynamically load and unload
	/// user controls to and from the page. However, unlike a
	/// regular dynamic load (where user controls are removed
	/// at postback), this class ensures that each control is
	/// automatically reloaded after a postback.
	/// 
	/// If you want to apply any events to dynamically loaded
	/// user controls, or modify them in any way, you must do
	/// so in Page_Load.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://danielsaidi.github.com/nextra
	/// </remarks>
	public class UserControlPlaceHolder : PlaceHolder
	{
		/// <summary>
		/// This overridden method ensures that all dynamically
		/// loaded user controls are automatically reloaded.
		/// </summary>
		protected override void LoadViewState(object savedState)
		{
			base.LoadViewState(savedState);
			foreach (var tmpString in LoadedControls)
				LoadControl(tmpString.Split(',')[0], tmpString.Split(',')[1]);
		}


		/// <summary>
		/// A comma-separated string with IDs of the controls
		/// that have been added to the place holder.
		/// </summary>
		protected List<String> LoadedControls
		{
			get
			{
				if (ViewState.Get<List<String>>("LoadedControls") == null)
					ViewState.Set("LoadedControls", new List<String>());
				return ViewState.Get<List<String>>("LoadedControls");
			}
		}


        /// <summary>
        /// Retrieve a control that has been added to the place holder.
		/// </summary>
		public Control GetControl(String controlId)
		{
			return Controls.Cast<Control>().FirstOrDefault(control => control.ID == controlId);
		}

		/// <summary>
		/// Retrieve a typed control that has been added to the place holder.
		/// </summary>
		public T GetControl<T>(String controlId)
			where T : Control
		{
			var control = GetControl(controlId);
			return control == null ? null : (T) GetControl(controlId);
		}

		/// <summary>
		/// Dynamically load a user control to the place holder. If the
		/// control is already added, it is not be loaded a second time.
		/// </summary>
		public Control LoadControl(String controlId, String controlUrl)
		{
			//Add the control key to viewstate, if is not already added
			if (!LoadedControls.Contains(controlId + "," + controlUrl))
				LoadedControls.Add(controlId + "," + controlUrl);

			//Return a previously loaded instance, if any
			var tmpControl = GetControl(controlId);
			if (tmpControl != null)
				return tmpControl;

			//Add the control to the target container and return it
			var uc = Page.LoadControl(controlUrl);
			uc.ID = controlId;
			Controls.Add(uc);
			return uc;
		}

        /// <summary>
        /// Dynamically load a user control to the place holder. If the
        /// control is already added, it is not be loaded a second time.
		/// </summary>
		public T LoadControl<T>(String controlId, String controlUrl)
			where T : Control
		{
			return (T)LoadControl(controlId, controlUrl);
		}

		/// <summary>
		/// Unload a previously loaded user control.
		/// </summary>
		public void UnloadControl(String controlId)
		{
			//Retrieve the full control ID (inluding control url)
			var fullId = "";
			foreach (var tmpId in LoadedControls.Where(tmpId => controlId == tmpId.Split(',')[0]))
				fullId = tmpId;

			//Remove the control ID
			LoadedControls.Remove(fullId);

			//Remove the control from the target container
			foreach (var control in Controls.Cast<Control>().Where(control => control.ID == controlId))
				Controls.Remove(control);
		}
	}
}
