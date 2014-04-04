using Gtk;
using System;
using System.Collections.Generic;

namespace Serpis.ed
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ArrayButton : Gtk.Bin
	{
		private int rows = 10;
		private int columns = 10;
		
		private Table table;
		
		private List<Button> buttons;
		
		public ArrayButton ()
		{
			this.Build ();
			
			/*table = new Table((uint)rows, (uint)columns, true);
			Add (table);
			*/
			refresh();
		}
		
		private void refresh(){
			/*Widget[]widgets =  table.Children;
			foreach (Widget widget in widgets)
				table.Remove (widget);
			*/
			if (table != null)
				Remove (table);
			
			table = new Table((uint)rows, (uint)columns, true);
			Add (table);
			
			buttons = new List<Button>();
			
			for (uint row = 0; row < rows; row++){
				for (uint column = 0; column < columns; column++){
					Button button = new Button();
					button.Visible = true;
					button.Label = string.Format ("[{0}, {1}]", row, column);
					table.Attach (button, column, column +1, row, row +1);
					buttons.Add (button);
				}
//			Button button = new Button();
//			button.Visible = true;
//			button.Label="33";
//			table.Attach(button, 0, 1, 0, 1);
			}
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
		
		public Button Get (int index){
			return (Button)table.Children[index];
			return buttons[index];
		}
		
		
		
	}
}
