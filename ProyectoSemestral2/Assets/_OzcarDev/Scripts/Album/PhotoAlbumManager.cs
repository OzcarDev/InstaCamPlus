using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoAlbumManager : MonoBehaviour
{
	// Start is called before the first frame update
	
    void Start()
    {
	    Cursor.lockState=CursorLockMode.None; 
    }

    // Update is called once per frame
    void Update()
    {
	    if(Input.GetKeyDown(KeyCode.P))
	    {
	    	LoadScene.LoadNextScene("Prueba");
	    }
    }
}
