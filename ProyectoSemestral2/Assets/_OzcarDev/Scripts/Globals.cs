﻿using System.Collections;
using System.Collections.Generic;
public class Globals 
{
  
  public static List<string> playerKeys = new List<string>();
  public static List<string> currentContent = new List<string>();
  public static string currentObject;
  public static string currentObjective;


	public static List<string> House = new List<string>() 
    { 
	    "Batería","Pecera","Ajedrez","Pastel de cumpleaños","Pato Amarillo","Carrito","Moto Sierra"    
    
    };
    
	public static List<string> Restaurant = new List<string>(){
		"Punk Hambriento","Hamburguesa","Empleado del Restaurante","Carnicero","Ratón","Arcade","Hot Dog","Sushi"
	};
	
	public static List<string> Park = new List<string>(){
		"Pastel","Punk Beisbolista","Gato","Perro","Lagarto","Loro"
	};
    
	public static List<string>Station = new List<string>(){
		"Patrulla","Policia","Perro Policia", "Prisionero", "Rosquilla", "Café","Armas","Comida China"
	};
    
	public static List<string> Hospital = new List<string>() 
	{ 
		"Ambulancia","Enfermera","Punk Enfermo","Dentista","Médico","Conejo de Terapia","Zombi","Radiólogo"
    };
    
	public static List<string> Extras = new List<string>() 
	{ 
		"Oso","Mancuernas","Automóvil","La chica de la perla","Caballero Hueco","Submarino Amarillo","Radio","Video Consola","Granjero","Hamburguesa Doble","Cura","Pavo","Sheriff","La novia","Menú",
		"Moto Roja","Pato Policiaco","Silla de Dentista","Medicamentos","Fuente"
    
    };
	/*
	public static void Restart(){
		playerKeys = null;
		
		
		House = new List<string>() 
		{ 
			"Batería","Pecera","Oso","Ajedrez","Pastel de cumpleaños","Pato Amarillo","Carrito","Moto Sierra"    
     
        };
        
		Hospital = new List<string>() 
		{ 
			"Hospital"
    };
    
		Extras = new List<string>() 
		{ 
			"Mancuernas","Automóvil","La chica de la perla","Caballero Hueco","Submarino Amarillo","Radio","Video Consola","Granjero","Hamburguesa Doble", "Cura", "Pavo", "Sushi","Sheriff"
    
    };
	
	}*/
	
	
}
