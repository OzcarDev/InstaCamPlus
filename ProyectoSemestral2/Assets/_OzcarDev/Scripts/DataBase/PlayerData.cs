using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class PlayerData 
{
	
	public List<string> playerKeys = new List<string>();
	
	public string[] misions;
	public int actualPhotos;
	public List<string> House = new List<string>();
	public List<string> Extras = new List<string>();
	public List<string> Hospital = new List<string>();
	public List<string> Restaurant = new List<string>();
	public List<string> Park = new List<string>();
	public List<string> Station = new List<string>();
	public List<string> Factory = new List<string>();
	public List<string> Office = new List<string>();
	public List<string>Beach=new List<string>();
	
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
		playerKeys = Globals.Instance.playerKeys;
		misions = Globals.Instance.mision;
		actualPhotos=Globals.Instance.actualPhotos;
		
		House=Globals.Instance.House;
		Extras = Globals.Instance.Extras;
		Hospital = Globals.Instance.Hospital;
		Restaurant = Globals.Instance.Restaurant;
		Park = Globals.Instance.Park;
		Station = Globals.Instance.Station;
		Factory = Globals.Instance.Factory;
		Office = Globals.Instance.Office;
		Beach = Globals.Instance.Beach;
		positionX=player.gameObject.transform.position.x;
		positionY=player.gameObject.transform.position.y;
		positionZ=player.gameObject.transform.position.z;
		
	  
    }
}
