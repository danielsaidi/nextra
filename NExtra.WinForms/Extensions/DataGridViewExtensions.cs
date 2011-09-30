using System;
using System.Windows.Forms;
using NExtra.Extensions;

namespace NExtra.WinForms.Extensions
{
	/// <summary>
	/// Extension methods for System.Windows.Forms.DataGridView.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.saidi.se/nextra
	/// </remarks>
	public static class DataGridViewExtensions
	{
		/// <summary>
		/// Evaluate whether or not the first row, if any, is selected in the data grid view.
		/// </summary>
		/// <param name="dataGridView">The DataGridView to use.</param>
		public static bool IsFirstRowSelected(this DataGridView dataGridView)
		{
			return (dataGridView.SelectedRows.Count > 0 && dataGridView.SelectedRows[0].Index == 0);
		}

		/// <summary>
		/// Evaluate whether or not the last row, if any, is selected in the data grid view.
		/// </summary>
		/// <param name="dataGridView">The DataGridView to use.</param>
		public static bool IsLastRowSelected(this DataGridView dataGridView)
		{
			return (dataGridView.SelectedRows.Count > 0 && dataGridView.SelectedRows[0].Index == dataGridView.Rows.Count - 1);
		}

		/// <summary>
		/// Select and show a row in a DataGridView.
		/// </summary>
		/// <param name="dataGridView">The DataGridView of interest.</param>
		/// <param name="rowIndex">The row index.</param>
		public static void SelectAndShowRow(this DataGridView dataGridView, int rowIndex)
		{
			dataGridView.SelectRow(rowIndex);
			dataGridView.ShowRow(rowIndex);
		}

		/// <summary>
		/// Select a row in a DataGridView.
		/// </summary>
		/// <param name="dataGridView">The DataGridView to use.</param>
		/// <param name="selectIndex">The row index to select.</param>
		public static void SelectRow(this DataGridView dataGridView, int selectIndex)
		{
			//Abort if the data grid view does not have any rows
			if (dataGridView.Rows.Count == 0)
				return;

			//Adjust for the last row
			selectIndex = selectIndex.Limit(0, dataGridView.Rows.Count - 1);

			//Select the proper row, if any
			dataGridView.Rows[selectIndex].Selected = true;
			dataGridView.CurrentCell = dataGridView.Rows[selectIndex].Cells[0];
		}

		/// <summary>
		/// Shows a row and selects another one in a DataGridView.
		/// The function will handle invalid indices and also set
		/// the CurrentCell property of the DataGridView.
		/// </summary>
		/// <param name="dataGridView">The DataGridView to use.</param>
		/// <param name="showIndex">The row index to show.</param>
		public static void ShowRow(this DataGridView dataGridView, int showIndex)
		{
			//Abort if the data grid view does not have any rows
			if (dataGridView.Rows.Count == 0)
				return;

			//Adjust for the last row
			showIndex = showIndex.Limit(0, dataGridView.Rows.Count - 1);

			//Show the proper row, if any
			dataGridView.FirstDisplayedScrollingRowIndex = showIndex;
		}


		/// <summary>
		/// Repaint an image cell with an image in an image list. Just execute
		/// this method in the CellPainting event of the DataGridView.
		/// 
		/// This method ignores invalid parameters. Providing it with empty or
		/// non-existing key indices will simply cause the event to abort.
		/// </summary>
		/// <param name="dataGridView">The DataGridView of interest.</param>
		/// <param name="e">Paint event arguments.</param>
		/// <param name="imageList">The image list that contains the images</param>
		/// <param name="imageKey">The image key to display.</param>
		public static void PaintImageCell(this DataGridView dataGridView, DataGridViewCellPaintingEventArgs e, ImageList imageList, String imageKey)
		{
			//Abort if any parameter is null or if the image does not exist
			if (e == null || imageList == null || imageKey.IsNullOrEmpty())
				return;
			if (!imageList.Images.ContainsKey(imageKey))
				return;

			//Paint the image
			e.PaintBackground(e.ClipBounds, false);
			var pt = e.CellBounds.Location;
			pt.X += (e.CellBounds.Width - imageList.ImageSize.Width) / 2;
			pt.Y += 4;
			imageList.Draw(e.Graphics, pt, imageList.Images.IndexOfKey(imageKey));
			e.Handled = true;
		}
	}
}
