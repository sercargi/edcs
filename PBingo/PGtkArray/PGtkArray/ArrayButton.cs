using Gtk;
using System;

namespace PGtkArray
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ArrayButton : Gtk.Bin
	{
		private int rows = 1;
		private int columns = 1;
		
		private Table table;
		
		public ArrayButton ()
		{
			this.Build ();
			
			table = new Table((uint)rows, (uint)columns, true);
			Add (table);
			
			refresh();
		}
		
		public int Rows{
			get {return rows;}
			set {rows = value;
				refresh();
			}
		}
		
		public int Columns{
			get {return columns;}
			set {columns = value;
				refresh();
			}
		}
		
		
		
		private void refresh(){
			for (uint row = 0; row < rows; row++){
				for (uint column = 0; column < columns; column++){
					Button button = new Button();
					button.Visible = true;
					button.Label = string.Format ("[{0}, {1}]", row, column);
					table.Attach (button, column, column +1, row, row +1);
				}
//			Button button = new Button();
//			button.Visible = true;
//			button.Label="33";
//			table.Attach(button, 0, 1, 0, 1);
			}
		}		
	}
}

