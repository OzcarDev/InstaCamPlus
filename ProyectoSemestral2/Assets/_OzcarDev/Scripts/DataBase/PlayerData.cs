
[System.Serializable]
public class PlayerData 
{
  
	float positionX;
	float positionY;
	float positionZ;
	
	float rotationX;
	float rotationY;
	float rotationZ;

    public PlayerData()
    {
	    positionX=Globals.position[0];
	    positionY=Globals.position[1];
	    positionZ=Globals.position[2];
		
	    rotationX=Globals.rotation[0];
	    rotationY=Globals.rotation[1];
	    rotationZ=Globals.rotation[2];
    }
}
