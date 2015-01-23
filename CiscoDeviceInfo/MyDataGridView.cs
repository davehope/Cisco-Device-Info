using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CiscoDeviceInfo
{
	public partial class MyDataGridView : DataGridView
	{
		public MyDataGridView() : base() { }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
		{
			base.OnDataBindingComplete(e);

			ContextMenuStrip contextMenu = new ContextMenuStrip();

			// Loop over columns in the data grid.
			foreach (DataGridViewColumn column in this.Columns)
			{
				// If this column doesn't have a context menu, set it.
				column.HeaderCell.ContextMenuStrip = contextMenu;

				// Create a menu item for this column.
				ToolStripMenuItem menuItem = new ToolStripMenuItem(column.HeaderText);
				menuItem.Checked = column.Visible;
				menuItem.Click += new EventHandler(ContextMenuClick);
				menuItem.Tag = this;
				contextMenu.Items.Add(menuItem);
			}
		}
		

		/// <summary>
		/// Onclick event for datagridview content menu items. Toggles column visibility.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ContextMenuClick(object sender, EventArgs e)
		{
			var clicked = sender as ToolStripMenuItem;

			if (clicked != null)
			{
				int visibleColCount = ((DataGridView)clicked.Tag).Columns.GetColumnCount(DataGridViewElementStates.Visible);
				if (visibleColCount == 1 && clicked.Checked == true)
					return;

				clicked.Checked = !clicked.Checked;

				// Loop over all columns
				foreach (DataGridViewColumn col in ((DataGridView)clicked.Tag).Columns)
				{
					if (col.HeaderText == clicked.Text)
					{
						col.Visible = clicked.Checked;
					}
					col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
				}
				((DataGridView)clicked.Tag).Columns.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			}
		}
	}
}
