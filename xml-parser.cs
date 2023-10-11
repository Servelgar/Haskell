using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.IO;


class Program
{
	static void Main(string[] args)
    {
		XmlDocument doc = new XmlDocument();
		doc.Load("ejemplo2.xml");
		int first_node_id = extract_first_id(doc);
		Console.WriteLine(doc.SelectSingleNode("root/node[@id="+1+"]").InnerText);
		Dictionary<string,List<string>> first_node = extract_node(first_node_id,doc);
		//Console.WriteLine(first_node["speaker"][0]); 
	}

	static Dictionary<string,List<string>> extract_node(int nodo_actual, 
	XmlDocument doc){
			// Create an XmlDocument object and load the XML file
			Dictionary<string,List<string>> res = new Dictionary<string,List<string>>();
			res["speaker"] = new List<string>();
			res["text"]= new List<string>();
			res["opciones"]= new List<string>();
			res["options_text"]= new List<string>();
			res["siguiente_nodos"] = new List<string>();
			
			// Get the root element
		//	XmlNode root = doc.SelectSingleNode("root");
			XmlNode nodo = doc.SelectSingleNode("/root/node[@id="+nodo_actual+"]");
			string speaker = nodo.SelectSingleNode("speaker").InnerText;	
			string text = nodo.SelectSingleNode("text").InnerText;
			XmlNode options = nodo.SelectSingleNode("options");

			if (options != null){
				foreach (XmlNode node in options.ChildNodes){
					// Doesn't work if the list is not sorted 
					res["options_text"].Add(node.SelectSingleNode("body").InnerText);
					res["opciones"].Add(node.Attributes["opt"].Value);
					res["siguiente_nodos"].Add(node.Attributes["nextNode"].Value);
				}
			} 
			res["speaker"].Add(speaker);
			res["text"].Add(text);			
			return res;
		}

	// Given a xml doc, extract the first id to begin dialogue process
	static int extract_first_id(XmlNode doc){
		XmlNode root = doc.SelectSingleNode("root");
		int res = 0;
		if (root.HasChildNodes){
			XmlNode primerNodo = root.FirstChild;
			if (primerNodo.Attributes["id"] == null){
				//Console.WriteLine("si");
			}
			res = Int32.Parse(primerNodo.Attributes["id"].Value);
		} 
		return res;
	}

	// given siguiente_nodos key and its values, parser them to integer
	static List<int> int_nodos_parser(List<string> siguiente_nodos){
		List<int> res = new List<int>();
		if(!siguiente_nodos.Any()){
			return res;
		} else {
			foreach(string nodo in siguiente_nodos){
			res.Add(Int32.Parse(nodo));
		}
			return res;
		}
	}

	// calculate next node 
	// the thing is, i need to check if the player can decide or not
	// if there is not siguiente_nodos, the next node is node++
	static void create_xml(string file){
		// first read the .txt
		List<string> l_acum = new List<string>();
		try
		{
			StreamReader sr = new StreamReader("");
			line = sr.ReadLine();
			while (line != null){
				l_acum.Add(line);
				line = sr.ReadLine();
			}
		}
		// then parse 
		itera_string_xml(l_acum);
		// then create xml 
	}

	static void itera_string_xml(List<string> xmlcrudo){
		string tab = "	";
		char pt = '>';
		char plus = '+';
		int cont = 0;
		XmlWriterSettings settings = new XmlWriterSettings();
		settings.Indent = true;
		settings.NewLineOnAttributes = true;
		XmlWriter writer = Xmlwriter.Create("root.xml",settings);
		// FUNCIONAMIENTO DE WRITE***ELEMENT //
		//	WriteStartElement("A");
		//	WriteStartElement("B");
		// ... attributes or content added here will become part af B element
		//	WriteEndElement(); // Closes the open B element.
		//	WriteEndElement(); // Closes the open A element.

		foreach (string node in xmlcrudo){
			if(node.startsWith(tab)){
				writer.WriteStartElement("x","root","123");
				writer.WriteEndElement();
			} else {
				writer.WriterStartElement("item");
				writer.WriteEndElement();
			}
			writer.WriterStarteElement("y","node","321");
			writer.WriteEndElement();

		}



	}

}
