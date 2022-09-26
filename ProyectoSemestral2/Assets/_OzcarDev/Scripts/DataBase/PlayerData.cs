using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class PlayerData 
{
	
	public List<string> playerKeys = new List<string>();
	
	public List<string> ToDoList = new List<string>();
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
		ToDoList=Globals.ToDoList;
		positionX=player.gameObject.transform.position.x;
		positionY=player.gameObject.transform.position.y;
		positionZ=player.gameObject.transform.position.z;
		
	  
    }
}
