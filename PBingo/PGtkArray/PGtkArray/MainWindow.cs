using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		int count = ArrayButton.Rows * ArrayButton.Columns;
		for (int index = 0; index < count; index++)
			ArrayButton.Get(index).Label = string.Format ("{0}", count - 1 - index);
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
