using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		Valor1.Text = "2";
		Valor2.Text = "2";
		
		int num1 = int.Parse (Valor1.Text);
		int num2 = int.Parse (Valor1.Text);
		
		Resultado.Text = (num1 + num2).ToString();
		
		
		//ButtonSuma.Clicked += delegate{
		//};
		
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	
}
