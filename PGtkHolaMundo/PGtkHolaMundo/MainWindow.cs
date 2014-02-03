using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		buttonAceptar.Clicked += delegate {
			labelSaludo.LabelProp = "Hola " + entryNombre.Text;
		};
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnButton2Clicked (object sender, System.EventArgs e)
	{
		throw new System.NotImplementedException ();
	}
}
