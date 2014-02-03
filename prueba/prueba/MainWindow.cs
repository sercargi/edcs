using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();		
		
		BotonSuma.Clicked +=delegate{			
			//Convert.toInt32	
			try{			
				decimal num1 = decimal.Parse(entry1.Text);
				decimal num2 = decimal.Parse(entry2.Text);		
				entryResult.Text=(num1 + num2).ToString();
			}
			catch (FormatException){
				entryResult.Text=("¡Las letras no se operan, MELON!");
				//Con esto hacemos que el mensaje aparezca en la ventana
				//Console.Writer(" ") asi sale por consola
			}
		};	
		
		BotonResta.Clicked +=delegate{		
			try{			
				decimal num1 = decimal.Parse(entry1.Text);
				decimal num2 = decimal.Parse(entry2.Text);		
				entryResult.Text=(num1 - num2).ToString();
			}
			catch (FormatException){
				entryResult.Text=("¡Las letras no se operan, MELON!");
			}
		};
		
		BotonMulti.Clicked +=delegate{		
			try{			
				decimal num1 = decimal.Parse(entry1.Text);
				decimal num2 = decimal.Parse(entry2.Text);		
				entryResult.Text=(num1 * num2).ToString();
			}
			catch (FormatException){
				entryResult.Text=("¡Las letras no se operan, MELON!");
			}
		};
		
		BotonDiv.Clicked +=delegate{		
			try{			
				decimal num1 = decimal.Parse(entry1.Text);
				decimal num2 = decimal.Parse(entry2.Text);		
				entryResult.Text=(num1 / num2).ToString();
			}
			catch (FormatException){
				entryResult.Text=("¡Las letras no se operan, MELON!");
			}
			catch ( System.DivideByZeroException){
				entryResult.Text=("Vamos majo, prueba algo que no sea 0");
			}
		};
		
		BotonReset.Clicked +=delegate{		
			entry1.Text = " ";
			entry2.Text = " ";	
			entryResult.Text = " ";
		};
		
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
