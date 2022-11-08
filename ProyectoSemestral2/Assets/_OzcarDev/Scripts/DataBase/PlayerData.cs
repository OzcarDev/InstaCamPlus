using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class PlayerData 
{
	
	public List<string> playerKeys = new List<string>();
	
	public List<string> House = new List<string>();
	public List<string> Extras = new List<string>();
	public List<string> Hospital = new List<string>();
	public List<string> Restaurant = new List<string>();
	public List<string> Park = new List<string>();
	public List<string> Station = new List<string>();
	//Posición
	public float positionX;
	public float positionY;
	public float positionZ;
	//Rotación
	public float rotationX;
	public float rotationY;
	public float rotationZ;

	public PlayerData(Move player)
	{
		playerKeys = Globals.playerKeys;
		House=Globals.House;
		Extras = Globals.Extras;
		Hospital = Globals.Hospital;
		Restaurant = Globals.Restaurant;
		Park = Globals.Park;
		Station = Globals.Station;
		positionX=player.gameObject.transform.position.x;
		positionY=player.gameObject.transform.position.y;
		positionZ=player.gameObject.transform.position.z;
		
	  
    }
}
