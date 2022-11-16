using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    GameManager gameManager;
	public ScreenShotHandler Cam;
	
	bool canTakePhoto=true;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
	    if (Input.GetButtonDown("Shot")&&gameManager.photoMode&&!gameManager.isPaused&&!gameManager.readingMode&&Globals.playerKeys.Contains("Camera")&&!gameManager.photoAlbumMode&&canTakePhoto)
	    { 
		    canTakePhoto=false;
		    Cam.TakeScreenshot();
		    StartCoroutine(Timer());
        }
    }
    
	IEnumerator Timer()
	{
		yield return new WaitForSeconds(0.5f);
		canTakePhoto = true;
	}
    
}
