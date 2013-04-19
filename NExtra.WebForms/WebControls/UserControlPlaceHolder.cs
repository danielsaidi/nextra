using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using NExtra.Web.Extensions;

namespace NExtra.WebForms.WebControls
{
	/// <summary>
	/// This class can be used to dynamically load/unload
	/// user controls to and from a page. However, unlike
	/// a regular dynamic load where controls are removed
	/// at postback, this class ensures that each control
	/// is automatically reloaded after a postback.
	/// 
	/// Use the Add method to add a user control into the
	/// placeholder. It will then be automatically loaded
	/// on each postback. Use the Remove method to remove
	/// any added user controls from the placeholder.
	/// 
	/// If you want to apply events to dynamically loaded
	/// user controls or modify them in any way, you must
	/// do so in Page_Load.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://danielsaidi.github.com/nextra
	/// </remarks>
	public class UserControlPlaceHolder : PlaceHolder
	{
		protected override void LoadViewState(object savedState)
		{
			base.LoadViewState(savedState);
			foreach (var tmpString in LoadedControls)
				Add(tmpString.Split(',')[0], tmpString.Split(',')[1]);
		}


		protected List<String> LoadedControls
		{
			get
			{
				if (ViewState.Get<List<String>>("LoadedControls") == null)
					ViewState.Set("LoadedControls", new List<String>());
				return ViewState.Get<List<String>>("LoadedControls");
			}
		}


	    public Control Add(String controlId, String filePath)
	    {
	        //Add the control key to viewstate, if is not already added
	        if (!LoadedControls.Contains(controlId + "," + filePath))
	            LoadedControls.Add(controlId + "," + filePath);

	        //Return a previously loaded instance, if any
	        var tmpControl = GetControl(controlId);
	        if (tmpControl != null)
	            return tmpControl;

	        //Add the control to the target container and return it
	        var uc = Page.LoadControl(filePath);
	        uc.ID = controlId;
	        Controls.Add(uc);
	        return uc;
	    }

	    /// <summary>
	    /// Dynamically load a user control to the place holder. If the
	    /// control is already added, it is not be loaded a second time.
	    /// </summary>
	    public T Add<T>(String controlId, String filePath)
	        where T : Control
	    {
	        return (T)Add(controlId, filePath);
	    }

	    public Control GetControl(String controlId)
        {
            return GetControls().FirstOrDefault(control => control.ID == controlId);
        }

        public T GetControl<T>(String controlId)
			where T : Control
		{
			var control = GetControl(controlId);
			return control == null ? null : (T) GetControl(controlId);
		}

        public IEnumerable<Control> GetControls()
        {
            return Controls.Cast<Control>();
        }

		public void Remove(String controlId)
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
