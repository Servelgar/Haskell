// JE Split
// Entrada: Fichero de Journal Entries de SAP 
// Salida: Realiza un split por sociedad y genera un fichero por sociedad, además de devolver por consola un conteo de asientos por sociedad
// Versión 3: Se ha omitido la función counting y reemplazado por un diccionario en process
// Mejorado el tiempo de ejecución, sobretodo en JE que contiene varias sociedades 
// archivo llamado jesplitv3.cs, cambiado cmp.bat 


using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
// using System.Threading;

class Program
{
static Encoding ENCODING = Encoding.GetEncoding(1252);
// static Encoding ENCODING = Encoding.UTF8;
static String FILE_NAME = "JE.txt";
static ulong HEADER_LINE = 5;
static ulong DATA_LINE = 7;
static String COMPANY_STRING = "Soc.";
//static int COMPANY_COLUMN = 0;


static void Main(){
	var watch = System.Diagnostics.Stopwatch.StartNew();
	Console.WriteLine(System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription);
	process();
	watch.Stop();
	Console.WriteLine("TIEMPO DE EJECUCIÓN (milisegundos): {0}", watch.ElapsedMilliseconds);
	
	
	// List<string> companies = process(); 
	// Llamada a la función process, que a parte de crear los ficheros, devuelve una lista de las sociedades
	//counting(companies);
}


// Procesa el JE, separa en splits por diferentes sociedades y calcula el numero de asientos 
// de cada sociedad procesada de esta forma. 

public static void process(){
	 StreamReader sr;
	 ulong lineNumber;
	 string line;
	 string[] fields;
	 string previous_company = "-";
	 string company = "";
	 string new_file = "";
	 int company_column = 0;
	 List<string> header = new List<string>();
	 List<StreamWriter> sw = new List<StreamWriter>();
	 
	 // Diccionario donde vamos a guardar el conteo de los asientos de cada sociedad.
	 Dictionary<string, int> diccionario_conteo =
    new Dictionary<string, int>();
	string pattern = "\t 001\t";
	 
	 sr = new StreamReader(FILE_NAME, ENCODING);
	
	 
	 
	 lineNumber = 0;
	 while ((line = sr.ReadLine()) != null){
		lineNumber++;
		fields = line.Split('\t');
		
		if(lineNumber < DATA_LINE) {
			header.Add(line);
		}
		
		if (lineNumber == HEADER_LINE){
			company_column = Array.IndexOf(fields, COMPANY_STRING);
			Console.WriteLine("El indice de Sociedad es {0}", company_column);
			Console.WriteLine("The encoding used was {0}.", sr.CurrentEncoding);
		}
	  
		if (lineNumber >= DATA_LINE && line.Length != 0){
			company = fields[company_column];
			new_file = company + ".txt";
			if (previous_company != company){
				// NUEVA SOCIEDAD DETECTADA
				// Añadimos en diccionario, cerramos viejo streamwriter y creamos nuevo
				// Escribimos cabecera en fichero 
				diccionario_conteo.Add(company,0);
				previous_company = company;
				if(sw.Count >= 1){
					// Nos aseguramos de cerrar el viejo streamwriter
					// Esta lista no debería de pasar de tamaño 1 nunca.
					sw[0].Close();
					sw.RemoveAt(0);
				}
				sw.Add(new StreamWriter(new_file,true,ENCODING));
				foreach(string h in header){
					sw[0].WriteLine(h);
				}
			}
			if(line.Contains(pattern)){
				diccionario_conteo[company] += 1;
			}
			sw[0].WriteLine(line);		
			}
		}
		
	if(sw.Count >= 1){
		sw[0].Close();
		sw.RemoveAt(0);
	}
	Console.WriteLine("Los JE han sido creados.");
	
	// Devolvemos por consola el resultado del diccionario
	foreach(var kvp in diccionario_conteo){
			Console.WriteLine("> La sociedad: {0} tiene {1} asientos", kvp.Key, kvp.Value);
	}
	
	sr.Close();
	
	}


//// Funcion auxiliar que necesita una lista de strings devuelta en process. 
//// Mientras funcione process ahora mismo no hace falta descomentar esta funcion, pero está aqui por si acaso.
//// nunca se sabe 
/*
static void counting(List<string> c){
	StreamReader sr; 
	int cont;
	string pattern = "\t 001\t";
	string line;
	
	foreach(string company in c){
		cont = 0; 
		sr = new StreamReader(company, ENCODING);
		while((line = sr.ReadLine()) != null){
			if(line.Contains(pattern)){
				cont++;
			}
		}
		Console.WriteLine("> La sociedad: {0} tiene {1} asientos", company, cont);
		sr.Close();
	}
}
*/



	
}
