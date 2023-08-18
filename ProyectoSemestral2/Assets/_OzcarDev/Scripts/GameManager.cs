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
		AudioManager.Instance.PlayMusic("theme_2");
		Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
	{
		
		if(Input.GetKeyDown(KeyCode.Q)&&Globals.Instance.playerKeys.Contains("PhotoAlbum")) NoteBook();
		if(Input.GetKeyDown(KeyCode.F)&&Globals.Instance.playerKeys.Contains("PhotoAlbum")&&!isPaused&&!readingMode) PhotoAlbum();

        if (Input.GetKeyDown(KeyCode.Escape)) Pause();

		if (Input.GetButtonDown("Camera")&&!isPaused&&!readingMode&&Globals.Instance.playerKeys.Contains("Camera")&&!photoAlbumMode)
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
		     AudioManager.Instance.PlaySFX("PhotoAlbum");
	     } 		else{
		     
		     player.gameObject.GetComponentInChildren<Camera>().depth = -1;
		     Cursor.lockState = CursorLockMode.None;
		     panelGamePlay.SetActive(false);
		     panelPhotoMode.SetActive(false);
		     Album.SetActive(true);
		     AudioManager.Instance.PlaySFX("PhotoAlbum");
	     }
	     photoAlbumMode = !photoAlbumMode;
	}

	public void NoteBook(){
		if (_AnimState == AnimState.On)
		{
			block.CrossFade("In", .25f);
			_AnimState = AnimState.Off;
			AudioManager.Instance.PlaySFX("NoteBook");
		}
		else
		{
			block.CrossFade("Out", .25f);
			_AnimState = AnimState.On;
			AudioManager.Instance.PlaySFX("NoteBook");
		}
	}
	
	public void newMision(){
		adviceContent.text = "Objetivo Actualizado \n Presiona \" Esc \" ";
		advice.StopPlayback();
		AudioManager.Instance.PlaySFX("Notification");
		advice.Play("Show");
	}
	
	public void Draw()
	{
		noteBooK.text="";
		
		
		if(Globals.Instance.House.Count>0){
			noteBookTitle.text="Casa";
			
		for(int i=0;i<=Globals.Instance.House.Count-1;i++)
		{
			noteBooK.text+="-"+Globals.Instance.House[i]+"\n";
		    
		}
		
		} else if(Globals.Instance.House.Count==0&&Globals.Instance.Office.Count>0){
			noteBookTitle.text="Oficinas";
			for(int i=0;i<=Globals.Instance.Office.Count-1;i++)
			{
				noteBooK.text+="-"+Globals.Instance.Office[i]+"\n";
		    
			}
		}
		else if(Globals.Instance.Office.Count==0&&Globals.Instance.Restaurant.Count>0){
			noteBookTitle.text="Restaurante";
			for(int i=0;i<=Globals.Instance.Restaurant.Count-1;i++)
			{
				noteBooK.text+="-"+Globals.Instance.Restaurant[i]+"\n";
		    
			}
		}else if(Globals.Instance.Restaurant.Count==0&&Globals.Instance.Park.Count>0){
			noteBookTitle.text="Parque";
			for(int i=0;i<=Globals.Instance.Park.Count-1;i++)
			{
				noteBooK.text+="-"+Globals.Instance.Park[i]+"\n";
		    
			}
		}else if(Globals.Instance.Park.Count==0&&Globals.Instance.Station.Count>0){
			noteBookTitle.text="Estación";
			for(int i=0;i<=Globals.Instance.Station.Count-1;i++)
			{
				noteBooK.text+="-"+Globals.Instance.Station[i]+"\n";
		    
			}
			
			
		}
		else if(Globals.Instance.Station.Count==0&&Globals.Instance.Hospital.Count>0){
			noteBookTitle.text="Hospital";
			for(int i=0;i<=Globals.Instance.Hospital.Count-1;i++)
			{
				noteBooK.text+="-"+Globals.Instance.Hospital[i]+"\n";
		    
			}}
			
		else if(Globals.Instance.Hospital.Count==0&&Globals.Instance.Factory.Count>0){
			noteBookTitle.text="Fábrica";
			for(int i=0;i<=Globals.Instance.Factory.Count-1;i++)
			{
				noteBooK.text+="-"+Globals.Instance.Factory[i]+"\n";
		    
			}
			
			
		}

		else if(Globals.Instance.Factory.Count==0&&Globals.Instance.Beach.Count>0){
			noteBookTitle.text="Playa";
			for(int i=0;i<=Globals.Instance.Beach.Count-1;i++)
			{
				noteBooK.text+="-"+Globals.Instance.Beach[i]+"\n";
		    
			}
			
			
		}
		else if(Globals.Instance.Beach.Count==0&&Globals.Instance.Extras.Count>0){
			
			
			noteBookTitle.text="¿?";
			for(int i=0;i<=Globals.Instance.Extras.Count-1;i++)
			{
				noteBooK.text+="-"+Globals.Instance.Extras[i]+"\n";
		    
			}
			
			
		}
		
			
		else if(Globals.Instance.Extras.Count==0){
			noteBookTitle.text="No hay más objetivos";
			
			
		}
		
		
	}

    public void ToDoList()
	{
		for(int i=0; i < Globals.Instance.House.Count; i++)
		{
        	
			if (Globals.Instance.currentObjective == Globals.Instance.House[i])
			{
		        
				Globals.Instance.House.Remove(Globals.Instance.currentObjective);
				adviceContent.text = "Nueva Foto" + " \""+Globals.Instance.currentObjective+"\"";
				advice.StopPlayback();
				advice.Play("Show");
				AudioManager.Instance.PlaySFX("Notification");
				Globals.Instance.actualPhotos++;
				Debug.Log(Globals.Instance.actualPhotos);
			}
		}
		for(int i=0; i < Globals.Instance.Station.Count; i++)
		{
        	
			if (Globals.Instance.currentObjective == Globals.Instance.Station[i])
			{
		        
				Globals.Instance.Station.Remove(Globals.Instance.currentObjective);
				adviceContent.text = "Nueva Foto" + " \""+Globals.Instance.currentObjective+"\"";
				advice.StopPlayback();
				advice.Play("Show");
				AudioManager.Instance.PlaySFX("Notification");
				Globals.Instance.actualPhotos++;
				Debug.Log(Globals.Instance.actualPhotos);
			}
		}
		for(int i=0; i < Globals.Instance.Park.Count; i++)
		{
        	
			if (Globals.Instance.currentObjective == Globals.Instance.Park[i])
			{
		        
				Globals.Instance.Park.Remove(Globals.Instance.currentObjective);
				adviceContent.text = "Nueva Foto" + " \""+Globals.Instance.currentObjective+"\"";
				advice.StopPlayback();
				advice.Play("Show");
				AudioManager.Instance.PlaySFX("Notification");
				Globals.Instance.actualPhotos++;
				Debug.Log(Globals.Instance.actualPhotos);
			}
		}
		
		for(int i=0; i < Globals.Instance.Restaurant.Count; i++)
		{
        	
			if (Globals.Instance.currentObjective == Globals.Instance.Restaurant[i])
			{
		        
				Globals.Instance.Restaurant.Remove(Globals.Instance.currentObjective);
				adviceContent.text = "Nueva Foto" + " \""+Globals.Instance.currentObjective+"\"";
				advice.StopPlayback();
				advice.Play("Show");
				AudioManager.Instance.PlaySFX("Notification");
				Globals.Instance.actualPhotos++;
				Debug.Log(Globals.Instance.actualPhotos);
			}
		}
		
	  
        
	    for(int i=0; i < Globals.Instance.Hospital.Count; i++)
	    {
        	
		    if (Globals.Instance.currentObjective == Globals.Instance.Hospital[i])
		    {
		        
			    Globals.Instance.Hospital.Remove(Globals.Instance.currentObjective);
			    adviceContent.text = "Nueva Foto" + " \""+Globals.Instance.currentObjective+"\"";
			    advice.StopPlayback();
			    advice.Play("Show");
			    AudioManager.Instance.PlaySFX("Notification");
			    Globals.Instance.actualPhotos++;
			    Debug.Log(Globals.Instance.actualPhotos);
		    }
	    }
        
		for(int i=0; i < Globals.Instance.Factory.Count; i++)
		{
        	
			if (Globals.Instance.currentObjective == Globals.Instance.Factory[i])
			{
		        
				Globals.Instance.Factory.Remove(Globals.Instance.currentObjective);
				adviceContent.text = "Nueva Foto" + " \""+Globals.Instance.currentObjective+"\"";
				advice.StopPlayback();
				advice.Play("Show");
				AudioManager.Instance.PlaySFX("Notification");
				Globals.Instance.actualPhotos++;
				Debug.Log(Globals.Instance.actualPhotos);
			}
		}
		
		for(int i=0; i < Globals.Instance.Office.Count; i++)
		{
        	
			if (Globals.Instance.currentObjective == Globals.Instance.Office[i])
			{
		        
				Globals.Instance.Office.Remove(Globals.Instance.currentObjective);
				adviceContent.text = "Nueva Foto" + " \""+Globals.Instance.currentObjective+"\"";
				advice.StopPlayback();
				advice.Play("Show");
				AudioManager.Instance.PlaySFX("Notification");
				Globals.Instance.actualPhotos++;
				Debug.Log(Globals.Instance.actualPhotos);
			}
		}
		
		for(int i=0; i < Globals.Instance.Beach.Count; i++)
		{
        	
			if (Globals.Instance.currentObjective == Globals.Instance.Beach[i])
			{
		        
				Globals.Instance.Beach.Remove(Globals.Instance.currentObjective);
				adviceContent.text = "Nueva Foto" + " \""+Globals.Instance.currentObjective+"\"";
				advice.StopPlayback();
				advice.Play("Show");
				AudioManager.Instance.PlaySFX("Notification");
				Globals.Instance.actualPhotos++;
				Debug.Log(Globals.Instance.actualPhotos);
			}
		}
        
	    for(int i=0; i < Globals.Instance.Extras.Count; i++)
	    {
        	
		    if (Globals.Instance.currentObjective == Globals.Instance.Extras[i])
		    {
		        
			    Globals.Instance.Extras.Remove(Globals.Instance.currentObjective);
			    adviceContent.text = "Nuevo Secreto" + " \""+Globals.Instance.currentObjective+"\"";
			    advice.StopPlayback();
			    advice.Play("Show");
			    AudioManager.Instance.PlaySFX("Notification");
			    Globals.Instance.actualPhotos++;
			    Debug.Log(Globals.Instance.actualPhotos);
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
	        AudioManager.Instance.PlaySFX("Object");
            
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
		Globals.Instance.mision = playerData.misions;
	        Globals.Instance.playerKeys=playerData.playerKeys;
		Globals.Instance.actualPhotos=playerData.actualPhotos;
		
		Globals.Instance.House = playerData.House;
		Globals.Instance.Extras = playerData.Extras;
		Globals.Instance.Hospital = playerData.Hospital;
		Globals.Instance.Restaurant = playerData.Restaurant;
		Globals.Instance.Park = playerData.Park;
		Globals.Instance.Station = playerData.Station;
		Globals.Instance.Factory = playerData.Factory;
		Globals.Instance.Beach = playerData.Beach;
		Globals.Instance.Office = playerData.Office;
		player.position = new Vector3(playerData.positionX,playerData.positionY,playerData.positionZ);
            Debug.Log("DatosCargados");
        
		
	}
	
	public void Save(){
		SaveManager.SavePlayerData(player.gameObject.GetComponent<Move>());
	}


}
