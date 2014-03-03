using System;
using Gtk;
using System.Collections.Generic;
using System.Diagnostics;

public partial class MainWindow: Gtk.Window
{	
	
	private List<int> numeros;
	private Random random = new Random();
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		Table table = new Table (9, 10, true);
		vbox1.Add(table);
		table.Visible = true;
		
		//Vamos a crear un array para introducir una lista de BOTONES
		List<Button> buttons = new List<Button>();
		
		for (int index = 0; index < 90; index++){
			
			
			Button button = new Button();
			button.Label = string.Format ("{0}", index + 1);
			//tambien lo podemos poner asi
			//button.Label = (index + 1).ToString();
			button.Visible = true;
			
			buttons.Add(button);
			
			uint fila = (uint)index / 10;
			uint columna = (uint)index % 10;
			//uint unicamente cogera valores positivos
			
			table.Attach(button, columna, columna + 1, fila, fila + 1);
			//table.Attach(button, 1, 2, 0, 1);
		
		}
		//Aqui le aplicamos color verde al boton 0
		Gdk.Color verde = new Gdk.Color(0,255,0);
		
		
		
		numeros = new List<int>();		
		//TODO 90 parece que sera un "parametro" de la aplicacion
		for (int numero = 1; numero <= 90; numero++)
			numeros.Add(numero);
		
		showNumeros();		
		
		goForwardAction.Activated += delegate {
			
			int indexAleatorio = random.Next(numeros.Count);
			int numeroExtraido = numeros[ indexAleatorio ];
			
			entryNumero.Text = numeroExtraido.ToString();
			
			espeak (numeroExtraido);
			//PONERLO PARA QUE SE VEA CADA NUMERO ALEATORIO
			buttons[numeroExtraido-1].ModifyBg(StateType.Normal, verde);
			
			numeros.Remove(numeroExtraido);
			
			showNumeros();
		}; 
		
		
	}
	
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
