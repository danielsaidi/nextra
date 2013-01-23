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
	/// Link:       http://danielsaidi.github.com/nextra
	/// </remarks>
	public static class DataGridViewExtensions
	{
		/// <summary>
		/// Evaluate whether or not the first row, if any, is selected.
		/// </summary>
		public static bool IsFirstRowSelected(this DataGridView dataGridView)
		{
			return (dataGridView.SelectedRows.Count > 0 && dataGridView.SelectedRows[0].Index == 0);
		}

		/// <summary>
		/// Evaluate whether or not the last row, if any, is selected.
		/// </summary>
		public static bool IsLastRowSelected(this DataGridView dataGridView)
		{
			return (dataGridView.SelectedRows.Count > 0 && dataGridView.SelectedRows[0].Index == dataGridView.Rows.Count - 1);
		}

		/// <summary>
		/// Select and show a certain row.
		/// </summary>
		public static void SelectAndShowRow(this DataGridView dataGridView, int rowIndex)
		{
			dataGridView.SelectRow(rowIndex);
			dataGridView.ShowRow(rowIndex);
		}

		/// <summary>
		/// Select a certain row.
		/// </summary>
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
		/// Shows a certain row.
		/// </summary>
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
		/// Repaint an image cell with an image in an image
		/// list. Run this method in the CellPainting event
		/// of the DataGridView.
		/// 
		/// This method ignores invalid parameters. Provide
		/// it with empty or invalid indices to cause it to
		/// abort.
		/// </summary>
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
