using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckKey : MonoBehaviour
{
	public string id;
	public GameObject key;
	// This function is called when the object becomes enabled and active.
	protected void OnEnable()
	{
		if(Globals.playerKeys.Contains(id)){
			key.SetActive(true);
		}
		else{
			key.SetActive(false);
		}
	}
}
