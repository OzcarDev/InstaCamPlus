using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastMision : MonoBehaviour
{
	public Letter dialogue;
	public GameManager gameManager;
	bool missionComplete=false;
	bool LoadingScene=false;
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		if(!gameManager.readingMode&&missionComplete&&!LoadingScene){
			LoadingScene=true;
			LoadScene.Instance.LoadNextScene("FinalScene");
		}
	}
  
	public void LastMission()
    {
	    if(Globals.actualPhotos >=5){
	    	dialogue.content.Clear();
	    	gameManager.Save();
	    	dialogue.content.Add("Así que ya tienes las 50 fotos");
	    	dialogue.content.Add("Dejame revisar lo que tienes y te dire si te contratamos otra vez o no");
	    	StartCoroutine(Wait());
	    } 
	    
	    
	    
    }
	IEnumerator Wait(){
		yield return new WaitForSeconds(0.1f);
		missionComplete=true;
	}
    
	// Update is called every frame, if the MonoBehaviour is enabled.
	
}
