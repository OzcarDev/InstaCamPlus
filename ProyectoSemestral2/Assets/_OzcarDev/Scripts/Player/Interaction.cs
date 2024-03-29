﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace com.OzcarDev.WalkingSim
{
    public class Interaction : MonoBehaviour
{
        public LayerMask layerMask;
        GameManager gameManager;
	public TextMeshProUGUI objectText;
	public TextMeshProUGUI objectText2;
	public TextMeshProUGUI cameraObjectText;
        // Start is called before the first frame update
    void Start()
    {
       gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
	    if(gameManager.photoMode){
		    CheckPhoto();
	    	
	    } else{
	    CheckInteraction();
	    }
    }
    
	void CheckPhoto()
	{
		
		RaycastHit hit;
		var ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f));
		if (Physics.Raycast(ray, out hit, 100,layerMask))
		{
			if(hit.transform.gameObject.tag== "Photo"){
				

				gameManager.lens.GetComponent<Animator>().Play("bigCursor");
				cameraObjectText.text = hit.transform.gameObject.name;
			
				Globals.Instance.currentObjective = hit.transform.gameObject.name;

			   

			}
			else
			{
				
				gameManager.lens.GetComponent<Animator>().Play("normalCursor");
				cameraObjectText.text = "";
			
				Globals.Instance.currentObjective = null;
			}
       
		} else
		{
			gameManager.lens.GetComponent<Animator>().Play("normalCursor");
			cameraObjectText.text = "";
			
			Globals.Instance.currentObjective = null;
		}
	}
       
    void CheckInteraction()
    {
       RaycastHit hit;
       var ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .4f));
     
       if (Physics.Raycast(ray, out hit, 5, layerMask))
       {
       	if(hit.transform.gameObject.tag== "Interaction"||hit.transform.gameObject.tag=="Photo"){
	       	
                gameManager.panelGamePlay.GetComponent<Animator>().Play("bigCursor");
	       	objectText.text = hit.transform.gameObject.name;
	       	objectText2.text = hit.transform.gameObject.name;
                Globals.Instance.currentObjective = hit.transform.gameObject.name;

           if (Input.GetButtonDown("Interaction") && !gameManager.readingMode&&!gameManager.photoMode)
           {
	           if(hit.transform.gameObject.GetComponent<LastMision>()!=null){
	           	hit.transform.gameObject.GetComponent<LastMision>().LastMission();
	           }
                    if(hit.transform.gameObject.GetComponent<PlayAnim>()!=null) hit.transform.gameObject.GetComponent<PlayAnim>().PlayAnimation();
                    if (hit.transform.gameObject.GetComponent<Letter>() != null)
                    {
                        Globals.Instance.currentContent = hit.transform.gameObject.GetComponent<Letter>().content;
                        Globals.Instance.currentObject = hit.transform.gameObject.GetComponent<Letter>().objectName;
                        gameManager.ReadingMode();
                    }
                    if (hit.transform.gameObject.GetComponent<Key>() != null)
                    {
                        Globals.Instance.playerKeys.Add(hit.transform.gameObject.GetComponent<Key>().keyID);
                        Destroy(hit.transform.gameObject);
                        
                    }
                    
	        		if (hit.transform.gameObject.GetComponent<PlaySound>() != null)
	        		{
		        		hit.transform.gameObject.GetComponent<PlaySound>().Sound();
                        
	        		}
                    
	        		if(hit.transform.gameObject.GetComponent<NPC>()!=null)
	        		{
		        		hit.transform.gameObject.GetComponent<NPC>().LookAtMe();	
	        		}
	        		
	           if(hit.transform.gameObject.GetComponent<NewMission>()!=null){
		           Globals.Instance.mision=hit.transform.gameObject.GetComponent<NewMission>().newMission;
		           hit.transform.gameObject.GetComponent<NewMission>().Mision();
		           gameManager.newMision();
	           }
	        		
	           
           }

            }
            else
       	{
            	
                gameManager.panelGamePlay.GetComponent<Animator>().Play("normalCursor");
	            objectText.text = "";
	            objectText2.text = "";
                Globals.Instance.currentObjective = null;
            }
       
       } else
       {
	       gameManager.panelGamePlay.GetComponent<Animator>().Play("normalCursor");
	       objectText.text = "";
	       objectText2.text = "";
	       Globals.Instance.currentObjective = null;
       }
            
    }

     
}
}
