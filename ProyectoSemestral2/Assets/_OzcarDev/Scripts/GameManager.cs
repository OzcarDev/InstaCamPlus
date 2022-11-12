using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isPaused;
    public bool photoMode;
	public bool readingMode;
	public bool photoAlbumMode = false;

	public GameObject panelPhotoMode;
	public GameObject lens;
    public GameObject panelGamePlay;
	public GameObject panelText;
	public GameObject Flash;
	public GameObject mainMenu;
	
    MessagesManager messagesManager;
    
	public GameObject Album;
	public TextMeshProUGUI noteBooK;
	public TextMeshProUGUI noteBookTitle;
	public Animator block;
	public Animator advice;
	public TextMeshProUGUI adviceContent;
	
	
	enum AnimState
	{
		On,
		Off
	}
	 AnimState _AnimState;
    
	
    
	public Transform player;
    // Awake is called when the script instance is being loaded.
   
	
    void Start()
	{
		photoAlbumMode = false;
		player = GameObject.Find("Player").GetComponent<Transform>();
		messagesManager = GameObject.Find("MessagesManager").GetComponent<MessagesManager>();
		Load();
		Draw();
		Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
	{
		
		if(Input.GetKeyDown(KeyCode.Q)&&Globals.playerKeys.Contains("PhotoAlbum")) NoteBook();
		if(Input.GetKeyDown(KeyCode.P)&&Globals.playerKeys.Contains("PhotoAlbum")&&!isPaused&&!readingMode) PhotoAlbum();

        if (Input.GetKeyDown(KeyCode.Escape)) Pause();

		if (Input.GetButtonDown("Camera")&&!isPaused&&!readingMode&&Globals.playerKeys.Contains("Camera")&&!photoAlbumMode)
        {
            PhotoMode();
        }
        
		

    }

    public void Pause()
    {
	    isPaused = !isPaused;
	    mainMenu.SetActive(isPaused);
    }
    
     void PhotoAlbum(){
	   
	     
	     // SaveManager.SavePlayerData(player.gameObject.GetComponent<Move>());
		 
	     if(photoAlbumMode){
		     player.gameObject.GetComponentInChildren<Camera>().depth = 1;
		     Cursor.lockState = CursorLockMode.Locked;
		     panelGamePlay.SetActive(true);
		     panelPhotoMode.SetActive(true);
		     photoMode = !photoMode;
		     PhotoMode();
		     Album.SetActive(false);
	     } 		else{
		     
		     player.gameObject.GetComponentInChildren<Camera>().depth = -1;
		     Cursor.lockState = CursorLockMode.None;
		     panelGamePlay.SetActive(false);
		     panelPhotoMode.SetActive(false);
		     Album.SetActive(true);
	     }
	     photoAlbumMode = !photoAlbumMode;
	}

	public void NoteBook(){
		if (_AnimState == AnimState.On)
		{
			block.CrossFade("In", .25f);
			_AnimState = AnimState.Off;
		}
		else
		{
			block.CrossFade("Out", .25f);
			_AnimState = AnimState.On;
		}
	}
	
	
	
	public void Draw()
	{
		noteBooK.text="";
		if(Globals.House.Count>0){
			noteBookTitle.text="Casa";
			
		for(int i=0;i<=Globals.House.Count-1;i++)
		{
			noteBooK.text+="-"+Globals.House[i]+"\n";
		    
		}
		} else if(Globals.House.Count==0&&Globals.Restaurant.Count>0){
			noteBookTitle.text="Restaurante";
			for(int i=0;i<=Globals.Restaurant.Count-1;i++)
			{
				noteBooK.text+="-"+Globals.Restaurant[i]+"\n";
		    
			}
		}else if(Globals.Restaurant.Count==0&&Globals.Park.Count>0){
			noteBookTitle.text="Parque";
			for(int i=0;i<=Globals.Park.Count-1;i++)
			{
				noteBooK.text+="-"+Globals.Park[i]+"\n";
		    
			}
		}else if(Globals.Park.Count==0&&Globals.Station.Count>0){
			noteBookTitle.text="Estación";
			for(int i=0;i<=Globals.Station.Count-1;i++)
			{
				noteBooK.text+="-"+Globals.Station[i]+"\n";
		    
			}
			
			
		}
		else if(Globals.Station.Count==0&&Globals.Hospital.Count>0){
			noteBookTitle.text="Hospital";
			for(int i=0;i<=Globals.Hospital.Count-1;i++)
			{
				noteBooK.text+="-"+Globals.Hospital[i]+"\n";
		    
			}
			
			
		}
		
		
		
		
	}

    public void ToDoList()
	{
		for(int i=0; i < Globals.House.Count; i++)
		{
        	
			if (Globals.currentObjective == Globals.House[i])
			{
		        
				Globals.House.Remove(Globals.currentObjective);
				adviceContent.text = "Nueva Foto" + " \""+Globals.currentObjective+"\"";
				advice.StopPlayback();
				advice.Play("Show");
			}
		}
		for(int i=0; i < Globals.Station.Count; i++)
		{
        	
			if (Globals.currentObjective == Globals.Station[i])
			{
		        
				Globals.Station.Remove(Globals.currentObjective);
				adviceContent.text = "Nueva Foto" + " \""+Globals.currentObjective+"\"";
				advice.StopPlayback();
				advice.Play("Show");
			}
		}
		for(int i=0; i < Globals.Park.Count; i++)
		{
        	
			if (Globals.currentObjective == Globals.Park[i])
			{
		        
				Globals.Park.Remove(Globals.currentObjective);
				adviceContent.text = "Nueva Foto" + " \""+Globals.currentObjective+"\"";
				advice.StopPlayback();
				advice.Play("Show");
			}
		}
		
		for(int i=0; i < Globals.Restaurant.Count; i++)
		{
        	
			if (Globals.currentObjective == Globals.Restaurant[i])
			{
		        
				Globals.Restaurant.Remove(Globals.currentObjective);
				adviceContent.text = "Nueva Foto" + " \""+Globals.currentObjective+"\"";
				advice.StopPlayback();
				advice.Play("Show");
			}
		}
		
	  
        
	    for(int i=0; i < Globals.Hospital.Count; i++)
	    {
        	
		    if (Globals.currentObjective == Globals.Hospital[i])
		    {
		        
			    Globals.Hospital.Remove(Globals.currentObjective);
			    adviceContent.text = "Nueva Foto" + " \""+Globals.currentObjective+"\"";
			    advice.StopPlayback();
			    advice.Play("Show");
		    }
	    }
        
	    for(int i=0; i < Globals.Extras.Count; i++)
	    {
        	
		    if (Globals.currentObjective == Globals.Extras[i])
		    {
		        
			    Globals.Extras.Remove(Globals.currentObjective);
			    adviceContent.text = "Nuevo Secreto" + " \""+Globals.currentObjective+"\"";
			    advice.StopPlayback();
			    advice.Play("Show");
		    }
	    }
        
	    
    }


    public void PhotoMode()
    {
        if (photoMode)
        {
            
            panelGamePlay.SetActive(true); 
	        panelPhotoMode.GetComponent<Animator>().Play("FadeOut");
	        lens.GetComponent<Animator>().Play("FadeOut");

        }
        else if (!photoMode)
        {
            panelPhotoMode.GetComponent<Animator>().Play("FadeIn");
            panelGamePlay.SetActive(false);
            
        }
        photoMode = !photoMode;
    }

    public void ReadingMode()
    {
        
	    panelText.SetActive(true);
	    panelGamePlay.SetActive(false);
	    readingMode = true;
	    messagesManager.StartDialogue();
	    
    }

	
   

	public void Load()
	{
		
      
            PlayerData playerData = SaveManager.LoadPlayerData();

            if (playerData == null) return;
	        Globals.playerKeys=playerData.playerKeys;
		
		Globals.House = playerData.House;
		Globals.Extras = playerData.Extras;
		Globals.Hospital = playerData.Hospital;
		Globals.Restaurant = playerData.Restaurant;
		Globals.Park = playerData.Park;
		Globals.Station = playerData.Station;
		player.position = new Vector3(playerData.positionX,playerData.positionY,playerData.positionZ);
            Debug.Log("DatosCargados");
        
		
	}
	
	public void Save(){
		SaveManager.SavePlayerData(player.gameObject.GetComponent<Move>());
	}


}
