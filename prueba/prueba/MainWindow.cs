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
		/*entry1.TextInserted += delegate (object o, TextInsertedArgs args){
			Console.WriteLine ("entry1.TextInserted args.Text={0}", args.Text);	
		}
		*/
//		Button[] buttons = new Button []{uno, dos};
//		foreach (Button uno in buttons) {
//			Button b = button;
//			button.Clicked += buttons;{
//				buttonClicked (b);
//			};
//		}
		//Solucion de complejidad alta!
		
		uno.Clicked +=delegate{		
			try{			
				buttonClicked (uno);
			}
			catch (FormatException){
				entryResult.Text=("¡Las letras no se operan, MELON!");
			}
		};
		
		uno.Clicked += delegate(object sender, EventArgs e){
			Button button = (Button)sender;
			Entry entry = Focus as Entry;
			if (entry != null)
				entry.Text = entry.Text + button.Label;	
		};
		
		
		dos.Clicked +=delegate{		
			try{	
				buttonClicked (dos);			
			}
			catch (FormatException){
				entryResult.Text=("¡Las letras no se operan, MELON!");
			}
		};
		
		tres.Clicked +=delegate{		
			try{	
				buttonClicked (tres);
			}
			catch (FormatException){
				entryResult.Text=("¡Las letras no se operan, MELON!");
			}
		};
	}
	private void buttonClicked(Button button){
		Entry entry = Focus as Entry;
				if (entry != null)
				entry.Text = entry.Text + button.Label;	
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
