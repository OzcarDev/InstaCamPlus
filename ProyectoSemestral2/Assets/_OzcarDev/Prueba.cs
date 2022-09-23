using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
	// Start is called before the first frame update
	GameManager gameManager;
    void Start()
    {
	    gameManager = GameObject.Find("GameManager").GetComponent <GameManager> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	// OnTriggerEnter is called when the Collider other enters the trigger.
	protected void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="Player"){
			Debug.Log("HOla");
			
			StartCoroutine(	other. gameObject.GetComponent<Move>().Teleporting(new Vector3(300,300,300)));
		}
	}
}
