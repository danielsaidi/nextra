using System.Drawing;
using System.Windows.Forms;
using NExtra.WinForms.Extensions;
using NUnit.Framework;

namespace NExtra.WinForms.Tests.Extensions
{
	[TestFixture]
	public class DataGridViewExtensionsBehvaior
	{
		private DataGridView dgv;
		private Graphics graphics;
		private const string imageKey = "key";
		private ImageList imageList;
		private DataGridViewCellPaintingEventArgs paintingEventArgs;


		[SetUp]
		public void SetUp()
		{
			dgv = new DataGridView();
			dgv.Columns.Add(new DataGridViewImageColumn());
			dgv.Rows.Add(new DataGridViewRow());
			dgv.Rows.Add(new DataGridViewRow());
			dgv.Rows.Add(new DataGridViewRow());

			using (var dummyForm = new Form())
				graphics = dummyForm.CreateGraphics();

			imageList = new ImageList();
			imageList.Images.Add(imageKey, new Bitmap(16, 16));

			paintingEventArgs = new DataGridViewCellPaintingEventArgs(dgv, graphics, new Rectangle(0, 0, 1, 1), new Rectangle(0, 0, 1, 1), 0, 0, DataGridViewElementStates.Visible, "value", "value", "", new DataGridViewCellStyle(), new DataGridViewAdvancedBorderStyle(), new DataGridViewPaintParts());
		}

		[TearDown]
		public void TearDown()
		{
			dgv.Dispose();
			graphics.Dispose();
			imageList.Dispose();
			paintingEventArgs = null;
		}


		public void UnselectAll()
		{
			foreach (DataGridViewRow dgvr in dgv.Rows)
				dgvr.Selected = false;
			dgv.CurrentCell = null;
		}


		[Test]
		public void IsFirstRowSelected_ShouldHandleEmptyList()
		{
			Assert.That(new DataGridView().IsFirstRowSelected(), Is.False);
		}

		[Test]
		public void IsFirstRowSelected_ShouldHandleUnselectedRows()
		{
			UnselectAll();

			Assert.That(dgv.IsFirstRowSelected(), Is.False);
		}

		[Test]
		public void IsFirstRowSelected_ShouldReturnTrueForFirstRow()
		{
			UnselectAll();
			dgv.Rows[0].Selected = true;

			Assert.That(dgv.IsFirstRowSelected(), Is.True);
		}

		[Test]
		public void IsFirstRowSelected_ShouldReturnFalseForMiddleRow()
		{
			UnselectAll();
			dgv.Rows[1].Selected = true;

			Assert.That(dgv.IsFirstRowSelected(), Is.False);
		}

		[Test]
		public void IsFirstRowSelected_ShouldReturnFalseForLastRow()
		{
			UnselectAll();
			dgv.Rows[dgv.Rows.Count - 1].Selected = true;

			Assert.That(dgv.IsFirstRowSelected(), Is.False);
		}

		[Test]
		public void IsLastRowSelected_ShouldHandleEmptyList()
		{
			Assert.That(new DataGridView().IsLastRowSelected(), Is.False);
		}

		[Test]
		public void IsLastRowSelected_ShouldHandleUnselectedRows()
		{
			UnselectAll();

			Assert.That(dgv.IsLastRowSelected(), Is.False);
		}

		[Test]
		public void IsLastRowSelected_ShouldReturnFalseForFirstRow()
		{
			UnselectAll();
			dgv.Rows[0].Selected = true;

			Assert.That(dgv.IsLastRowSelected(), Is.False);
		}

		[Test]
		public void IsLastRowSelected_ShouldReturnFalseForMiddleRow()
		{
			UnselectAll();
			dgv.Rows[1].Selected = true;

			Assert.That(dgv.IsLastRowSelected(), Is.False);
		}

		[Test]
		public void IsLastRowSelected_ShouldReturnTrueForLastRow()
		{
			UnselectAll();
			dgv.Rows[dgv.Rows.Count - 1].Selected = true;

			Assert.That(dgv.IsLastRowSelected(), Is.True);
		}

		[Test]
		public void PaintImageCell_ShouldHandleNullEventArguments()
		{
			dgv.PaintImageCell(null, imageList, imageKey);

			Assert.That(paintingEventArgs.Handled, Is.False);
		}

		[Test]
		public void PaintImageCell_ShouldHandleNullImageList()
		{
			dgv.PaintImageCell(paintingEventArgs, null, imageKey);

			Assert.That(paintingEventArgs.Handled, Is.False);
		}

		[Test]
		public void PaintImageCell_ShouldHandleNullImageKey()
		{
			dgv.PaintImageCell(paintingEventArgs, imageList, null);

			Assert.That(paintingEventArgs.Handled, Is.False);
		}

		[Test]
		public void PaintImageCell_ShouldHandleInvalidImageKey()
		{
			dgv.PaintImageCell(paintingEventArgs, imageList, "invalid");

			Assert.That(paintingEventArgs.Handled, Is.False);
		}

		[Test, Ignore("The event arguments are missing some information")]
		public void Todo_PaintImageCell_ShouldSucceedUsingValidParameters()
		{
			//dgv.PaintImageCell(paintingEventArgs, imageList, "key");
		}

		[Test]
		public void SelectAndShowRow_ShouldHandleEmptyList()
		{
			var dgv_tmp = new DataGridView();
			dgv_tmp.SelectAndShowRow(0);

			Assert.AreEqual(0, dgv_tmp.SelectedRows.Count);
			Assert.IsNull(dgv_tmp.CurrentCell);
		}

		[Test]
		public void SelectAndShowRow_ShouldHandleTooLowIndex()
		{
			dgv.SelectAndShowRow(-1);

			Assert.AreEqual(0, dgv.FirstDisplayedScrollingRowIndex);
			Assert.AreEqual(1, dgv.SelectedRows.Count);
			Assert.AreEqual(0, dgv.SelectedRows[0].Index);
			Assert.IsNotNull(dgv.CurrentCell);
		}

		[Test]
		public void SelectAndShowRow_ShouldHandleTooHighIndex()
		{
			dgv.SelectAndShowRow(dgv.Rows.Count);

			Assert.That(dgv.FirstDisplayedScrollingRowIndex, Is.EqualTo(0) /* since dgv is not displayed */);
			Assert.That(dgv.SelectedRows.Count, Is.EqualTo(1));
			Assert.That(dgv.SelectedRows[0].Index, Is.EqualTo(dgv.Rows.Count - 1));
			Assert.That(dgv.CurrentCell, Is.Not.Null);
		}

		[Test]
		public void SelectAndShowRow_ShouldSucceedUsingValidIndex()
		{
			dgv.SelectAndShowRow(1);

			Assert.That(dgv.FirstDisplayedScrollingRowIndex, Is.EqualTo(0) /* since dgv is not displayed */);
			Assert.That(dgv.SelectedRows.Count, Is.EqualTo(1));
			Assert.That(dgv.SelectedRows[0].Index, Is.EqualTo(1));
			Assert.That(dgv.CurrentCell, Is.Not.Null);
		}

		[Test]
		public void SelectRow_ShouldHandleEmptyList()
		{
			var dgv_tmp = new DataGridView();
			dgv_tmp.SelectRow(0);

			Assert.That(dgv_tmp.SelectedRows.Count, Is.EqualTo(0));
			Assert.That(dgv_tmp.CurrentCell, Is.Null);
		}

		[Test]
		public void SelectRow_ShouldHandleTooLowIndex()
		{
			dgv.SelectRow(-1);

			Assert.That(dgv.SelectedRows.Count, Is.EqualTo(1));
			Assert.That(dgv.SelectedRows[0].Index, Is.EqualTo(0));
			Assert.That(dgv.CurrentCell, Is.Not.Null);
		}

		[Test]
		public void SelectRow_ShouldHandleTooHighIndex()
		{
			dgv.SelectRow(dgv.Rows.Count);

			Assert.That(dgv.SelectedRows.Count, Is.EqualTo(1));
			Assert.That(dgv.SelectedRows[0].Index, Is.EqualTo(dgv.Rows.Count - 1));
			Assert.That(dgv.CurrentCell, Is.Not.Null);
		}

		[Test]
		public void SelectRow_ShouldSelectValidIndex()
		{
			dgv.SelectRow(1);

			Assert.That(dgv.SelectedRows.Count, Is.EqualTo(1));
			Assert.That(dgv.SelectedRows[0].Index, Is.EqualTo(1));
			Assert.That(dgv.CurrentCell, Is.Not.Null);
		}
	}
}
