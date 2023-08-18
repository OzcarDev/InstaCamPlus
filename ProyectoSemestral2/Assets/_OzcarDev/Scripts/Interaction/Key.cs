using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
	public string keyID;
    
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	 void Update()
	{
		if(Globals.Instance.playerKeys.Contains(keyID)){
			Debug.Log("Desactivado");
			gameObject.SetActive(false);
			
			//Destroy(this.gameObject);
		}	else{
			gameObject.SetActive(true);
		}
	}
}
