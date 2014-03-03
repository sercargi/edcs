using System;
using Gtk;
using System.Collections.Generic;
using System.Diagnostics;

public partial class MainWindow: Gtk.Window
{	
	
	private List<int> numeros = new List<int>();
	
	private Random random = new Random();
	
	private Table table;
	private Table table2;
	//Vamos a crear un array para introducir una lista de BOTONES
	private List<Button> buttons = new List<Button>();
	
	private static readonly Gdk.Color COLOR_GREEN = new Gdk.Color(0,255,0);
	
	private int numeroTotalBolas = 90;
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		//uint numeroTotalFilas = (((uint)numeroTotalBolas-1)/10)+1;
		
		table = new Table (9, 10, true);		
		vbox1.Add(table);		
		table.Visible = true;	
		
		table2 = new Table (9, 10, true);
		vbox1.Add(table2);
		table2.Visible = true;
		
		addButtons();
		
		
				
		for (int numero = 1; numero <= 90; numero++)
			numeros.Add(numero);
		
		showNumeros();	
		
		
		goForwardAction.Activated += delegate {
			
			int indexAleatorio = random.Next(numeros.Count);
			int numeroExtraido = numeros[ indexAleatorio ];
			
			entryNumero.Text = numeroExtraido.ToString();
			
			espeak (numeroExtraido);
			//PONERLO PARA QUE SE VEA CADA NUMERO ALEATORIO
			buttons[numeroExtraido-1].ModifyBg(StateType.Normal, COLOR_GREEN);
			
			numeros.Remove(numeroExtraido);
			
			showNumeros();
			
			addButtonsExtraidos(numeroExtraido);
		}; 
		
		
	}
	private void addButtons(){
		// añadir los botones al table
		for (int index = 0; index < numeroTotalBolas; index++){			
			Button button = new Button();
			button.Label = string.Format ("{0}", index + 1);			
			button.Visible = true;
			
			buttons.Add(button);
			
			uint fila = (uint)index / 10;
			uint columna = (uint)index % 10;
			//uint unicamente cogera valores positivos
			
			table.Attach(button, columna, columna + 1, fila, fila + 1);
			//table.Attach(button, 1, 2, 0, 1);
		
		}
	}
	int cont = 0;
	private void addButtonsExtraidos(int num){	
					
			Button button = new Button();
			button.Label = num.ToString();
			//tambien lo podemos poner asi
			
			button.Visible = true;
			
			buttons.Add(button);
			
			uint fila = (uint)cont / 10;
			uint columna = (uint)cont % 10;
			//uint unicamente cogera valores positivos
		
			cont++;
			
			table2.Attach(button, columna, columna + 1, fila, fila + 1);		
	}
//	private void addButtonsExtraidos(){	
//					
//			Button button = new Button();
//			button.Label = entryNumero.Text;			
//			button.Visible = true;
//		
//		int count = table2.Children.Length;
//			
//			buttons.Add(button);
//			
//			uint fila = (uint)cont / 10;
//			uint columna = (uint)cont % 10;			
//		
//			cont++;
//			
//			table2.Attach(button, columna, columna + 1, fila, fila + 1);		
//	}
	
	private void showNumeros(){
//		for (int index = 0; index < numeros.Count; index++)
//			Console.Write (numeros[index]+" ");
//		Console.WriteLine();    
//	}
	
		foreach (int numero in numeros)
			Console.Write (numero + " ");
		Console.WriteLine();
	}
	
	private void espeak(int numeroExtraido){
		string numeroCantado = numeroExtraido.ToString();
		if (numeroCantado.Length > 1){
			string digitos = numeroCantado;
			foreach (char digito in digitos)
				numeroCantado = numeroCantado + " " + digitos;
		}
		
		Process.Start("espeak", "-v es \"" + numeroExtraido + "\"");
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
