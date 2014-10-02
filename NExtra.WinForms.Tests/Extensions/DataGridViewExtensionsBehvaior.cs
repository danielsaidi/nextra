using System.Drawing;
using System.Windows.Forms;
using NExtra.WinForms.Extensions;
using NUnit.Framework;

namespace NExtra.WinForms.Tests.Extensions
{
	[TestFixture]
	public class DataGridViewExtensionsBehvaior
    {
        private const string ImageKey = "key";

		private DataGridView _dgv;
		private Graphics _graphics;
		private ImageList _imageList;
		private DataGridViewCellPaintingEventArgs _paintingEventArgs;


		[SetUp]
		public void SetUp()
		{
			_dgv = new DataGridView();
			_dgv.Columns.Add(new DataGridViewImageColumn());
			_dgv.Rows.Add(new DataGridViewRow());
			_dgv.Rows.Add(new DataGridViewRow());
			_dgv.Rows.Add(new DataGridViewRow());

			using (var dummyForm = new Form())
				_graphics = dummyForm.CreateGraphics();

			_imageList = new ImageList();
			_imageList.Images.Add(ImageKey, new Bitmap(16, 16));

			_paintingEventArgs = new DataGridViewCellPaintingEventArgs(_dgv, _graphics, new Rectangle(0, 0, 1, 1), new Rectangle(0, 0, 1, 1), 0, 0, DataGridViewElementStates.Visible, "value", "value", "", new DataGridViewCellStyle(), new DataGridViewAdvancedBorderStyle(), new DataGridViewPaintParts());
		}

		[TearDown]
		public void TearDown()
		{
			_dgv.Dispose();
			_graphics.Dispose();
			_imageList.Dispose();
			_paintingEventArgs = null;
		}


		public void UnselectAll()
		{
			foreach (DataGridViewRow dgvr in _dgv.Rows)
				dgvr.Selected = false;
			_dgv.CurrentCell = null;
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

			Assert.That(_dgv.IsFirstRowSelected(), Is.False);
		}

		[Test]
		public void IsFirstRowSelected_ShouldReturnTrueForFirstRow()
		{
			UnselectAll();
			_dgv.Rows[0].Selected = true;

			Assert.That(_dgv.IsFirstRowSelected(), Is.True);
		}

		[Test]
		public void IsFirstRowSelected_ShouldReturnFalseForMiddleRow()
		{
			UnselectAll();
			_dgv.Rows[1].Selected = true;

			Assert.That(_dgv.IsFirstRowSelected(), Is.False);
		}

		[Test]
		public void IsFirstRowSelected_ShouldReturnFalseForLastRow()
		{
			UnselectAll();
			_dgv.Rows[_dgv.Rows.Count - 1].Selected = true;

			Assert.That(_dgv.IsFirstRowSelected(), Is.False);
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

			Assert.That(_dgv.IsLastRowSelected(), Is.False);
		}

		[Test]
		public void IsLastRowSelected_ShouldReturnFalseForFirstRow()
		{
			UnselectAll();
			_dgv.Rows[0].Selected = true;

			Assert.That(_dgv.IsLastRowSelected(), Is.False);
		}

		[Test]
		public void IsLastRowSelected_ShouldReturnFalseForMiddleRow()
		{
			UnselectAll();
			_dgv.Rows[1].Selected = true;

			Assert.That(_dgv.IsLastRowSelected(), Is.False);
		}

		[Test]
		public void IsLastRowSelected_ShouldReturnTrueForLastRow()
		{
			UnselectAll();
			_dgv.Rows[_dgv.Rows.Count - 1].Selected = true;

			Assert.That(_dgv.IsLastRowSelected(), Is.True);
		}

		[Test]
		public void PaintImageCell_ShouldHandleNullEventArguments()
		{
			_dgv.PaintImageCell(null, _imageList, ImageKey);

			Assert.That(_paintingEventArgs.Handled, Is.False);
		}

		[Test]
		public void PaintImageCell_ShouldHandleNullImageList()
		{
			_dgv.PaintImageCell(_paintingEventArgs, null, ImageKey);

			Assert.That(_paintingEventArgs.Handled, Is.False);
		}

		[Test]
		public void PaintImageCell_ShouldHandleNullImageKey()
		{
			_dgv.PaintImageCell(_paintingEventArgs, _imageList, null);

			Assert.That(_paintingEventArgs.Handled, Is.False);
		}

		[Test]
		public void PaintImageCell_ShouldHandleInvalidImageKey()
		{
			_dgv.PaintImageCell(_paintingEventArgs, _imageList, "invalid");

			Assert.That(_paintingEventArgs.Handled, Is.False);
		}

		[Test, Ignore("The event arguments are missing some information")]
		public void Todo_PaintImageCell_ShouldSucceedUsingValidParameters()
		{
			//dgv.PaintImageCell(paintingEventArgs, imageList, "key");
		}

		[Test]
		public void SelectAndShowRow_ShouldHandleEmptyList()
		{
			var dgvTmp = new DataGridView();
			dgvTmp.SelectAndShowRow(0);

			Assert.AreEqual(0, dgvTmp.SelectedRows.Count);
			Assert.IsNull(dgvTmp.CurrentCell);
		}

		[Test]
		public void SelectAndShowRow_ShouldHandleTooLowIndex()
		{
			_dgv.SelectAndShowRow(-1);

			Assert.AreEqual(0, _dgv.FirstDisplayedScrollingRowIndex);
			Assert.AreEqual(1, _dgv.SelectedRows.Count);
			Assert.AreEqual(0, _dgv.SelectedRows[0].Index);
			Assert.IsNotNull(_dgv.CurrentCell);
		}

		[Test]
		public void SelectAndShowRow_ShouldHandleTooHighIndex()
		{
			_dgv.SelectAndShowRow(_dgv.Rows.Count);

			Assert.That(_dgv.FirstDisplayedScrollingRowIndex, Is.EqualTo(0) /* since dgv is not displayed */);
			Assert.That(_dgv.SelectedRows.Count, Is.EqualTo(1));
			Assert.That(_dgv.SelectedRows[0].Index, Is.EqualTo(_dgv.Rows.Count - 1));
			Assert.That(_dgv.CurrentCell, Is.Not.Null);
		}

		[Test]
		public void SelectAndShowRow_ShouldSucceedUsingValidIndex()
		{
			_dgv.SelectAndShowRow(1);

			Assert.That(_dgv.FirstDisplayedScrollingRowIndex, Is.EqualTo(0) /* since dgv is not displayed */);
			Assert.That(_dgv.SelectedRows.Count, Is.EqualTo(1));
			Assert.That(_dgv.SelectedRows[0].Index, Is.EqualTo(1));
			Assert.That(_dgv.CurrentCell, Is.Not.Null);
		}

		[Test]
		public void SelectRow_ShouldHandleEmptyList()
		{
			var dgvTmp = new DataGridView();
			dgvTmp.SelectRow(0);

			Assert.That(dgvTmp.SelectedRows.Count, Is.EqualTo(0));
			Assert.That(dgvTmp.CurrentCell, Is.Null);
		}

		[Test]
		public void SelectRow_ShouldHandleTooLowIndex()
		{
			_dgv.SelectRow(-1);

			Assert.That(_dgv.SelectedRows.Count, Is.EqualTo(1));
			Assert.That(_dgv.SelectedRows[0].Index, Is.EqualTo(0));
			Assert.That(_dgv.CurrentCell, Is.Not.Null);
		}

		[Test]
		public void SelectRow_ShouldHandleTooHighIndex()
		{
			_dgv.SelectRow(_dgv.Rows.Count);

			Assert.That(_dgv.SelectedRows.Count, Is.EqualTo(1));
			Assert.That(_dgv.SelectedRows[0].Index, Is.EqualTo(_dgv.Rows.Count - 1));
			Assert.That(_dgv.CurrentCell, Is.Not.Null);
		}

		[Test]
		public void SelectRow_ShouldSelectValidIndex()
		{
			_dgv.SelectRow(1);

			Assert.That(_dgv.SelectedRows.Count, Is.EqualTo(1));
			Assert.That(_dgv.SelectedRows[0].Index, Is.EqualTo(1));
			Assert.That(_dgv.CurrentCell, Is.Not.Null);
		}
	}
}
