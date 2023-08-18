using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Globals : MonoBehaviour

{
	public static Globals Instance;
  
	public int totalPhotos=156;
	public int actualPhotos;
  public List<string> playerKeys = new List<string>();
  public List<string> currentContent = new List<string>();
  public string currentObject;
  public string currentObjective;
  public string[] mision = new string[]{"",""};

	public List<string> House = new List<string>() 
	{ 
	    "Batería","Pecera","Ajedrez","Pastel de cumpleaños","Pato Amarillo","Carrito","Moto Sierra"    
    
    };
    
	public List<string>Office = new List<string>(){
		"Recepcionista","Aspiradora","Reloj","Punk Empresarial","Cena Recalentada","Pay","Empleado Del Mes","Pan","JEFA"
	};
    
	public List<string> Restaurant = new List<string>(){
		"Punk Hambriento","Hamburguesa","Empleado Miserable","Carnicero","Ratón","Arcade","Hot Dog","Sushi"
	};
	
	public List<string> Park = new List<string>(){
		"Pastel","Punk Beisbolista","Gato","Perro","Lagarto","Loro"
	};
    
	public List<string>Station = new List<string>(){
		"Patrulla","Policía","Perro Policia", "Prisionero", "Rosquilla", "Café","Armas","Comida China"
	};
    
	public List<string> Hospital = new List<string>() 
	{ 
		"Ambulancia","Enfermera","Punk Enfermo","Dentista","Médico","Conejo de Terapia","Zombi","Radiólogo"
    };
    
	public List<string> Factory = new List<string>(){
		"Camión","Soda Gigante","Microscopio","Sodas","Azúcar","Montacargas","Paloma Gris", "Chimenea", "Supervisor","Científico"
	};
	
	
	
	public List<string>Beach = new List<string>(){
		"Marinero","Castillo De Arena","Pelota","Red De Volleyball","Barco","Tabla De Surf", "Nutria", "Delfín","Cangrejo","Orca","Pelicano","Tortuga","Punk Bañista"
	};
    
	public List<string> Extras = new List<string>() 
	{ 
		"Oso","Mancuernas","Automóvil","La chica de la perla","Caballero Hueco","Submarino Amarillo","Radio","Video Consola","Granjero","Hamburguesa Doble","Cura","Pavo","Sheriff","La novia","Menú",
		"Moto Roja","Pato Policiaco","Silla de Dentista","Medicamentos","Fuente","Hormiga Zombie","Símbolo Anarquista", "Pato De Hule","Dona Sexy","Calavera Punk","Ancla","Rebanada De Pizza","Taza Miserable",
		"Consola Portátil", "Huevo Frito","Cara Feliz", "Patineta","Dinosaurio","Vegetales","Vino","Viejo Adolorido","María Antonieta","Pato Radioactivo", "Antena","Pájaro De Colores", "Asaltante","Camión De Cemento",
		"Laboratorio Químico","Mr. White","Camioneta De Sandías","Camión De Tacos","Faro","Pescado","Langosta","Caza Tesoros","Guitarra Eléctrica","Punk Rockero","Bajo Eléctrico", "Punk Baterista", "Pez Payaso",
		"Taco","Anti Pato","Taquero","Cartel Amenazante","Torre De Emparedados","Jamón Gigante","Pato Malvado","Punk Con Cuchillo", "Rapero", "Pez Rojo", "Rana","Cocodrilo","Trabajador","Pato De Concreto", "Búho","Reno",
		"Auto Viejo","Autobús","Chófer","Mecánico","Tren","Vaca","Serpiente","Mapache","Punk Granjera","Punk Violento","Pato Doctor","Cuervo","Obrero","Punk Policía","Pinguino","Águila","Tigre"
    
    };
	
	private void Awake(){
		if (Instance == null)
		{
			Instance = this;
			
		}
		else
		{
			Destroy(Instance.gameObject);
			Instance=this;
		}
	}
	
	
}
