using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
	public string keyID;
    
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	 void Start()
	{
		if(Globals.playerKeys.Contains(keyID)){
			Destroy(this.gameObject);
		}	
	}
}
