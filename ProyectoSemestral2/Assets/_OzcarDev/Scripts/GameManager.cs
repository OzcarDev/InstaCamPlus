using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isPaused;
    public bool photoMode;
    public bool readingMode;

    public GameObject panelPhotoMode;
    public GameObject panelGamePlay;
    public GameObject panelText;

    MessagesManager messagesManager;
    
	public TextMeshProUGUI noteBooK;
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
		
		player = GameObject.Find("Player").GetComponent<Transform>();
		messagesManager = GameObject.Find("MessagesManager").GetComponent<MessagesManager>();
		Load();
	    Draw();
    }

    // Update is called once per frame
    void Update()
	{
		
		if(Input.GetKeyDown(KeyCode.Q)&&Globals.playerKeys.Contains("PhotoAlbum")) NoteBook();
		if(Input.GetKeyDown(KeyCode.P)&&Globals.playerKeys.Contains("PhotoAlbum")&&!isPaused) StartCoroutine(PhotoAlbum());

        if (Input.GetKeyDown(KeyCode.Escape)) Pause();

        if (Input.GetButtonDown("Camera")&&!isPaused&&!readingMode&&Globals.playerKeys.Contains("Camera"))
        {
            PhotoMode();
        }

    }

    public void Pause()
    {
        isPaused = !isPaused;
    }
    
	IEnumerator PhotoAlbum(){
		
		SaveManager.SavePlayerData(player.gameObject.GetComponent<Move>());
		Debug.Log("DatosGuardados");
		yield return new WaitForEndOfFrame();
		
		LoadScene.LoadNextScene("PhotoAlbum");
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
		for(int i=0;i<=Globals.ToDoList.Count-1;i++)
		{
			noteBooK.text+="-"+Globals.ToDoList[i]+"\n";
		    
		}
	}

    public void ToDoList()
    {
        for(int i=0; i < Globals.ToDoList.Count; i++)
        {
        	
	        if (Globals.currentObjective == Globals.ToDoList[i])
            {
		        
		        Globals.ToDoList.Remove(Globals.currentObjective);
		        adviceContent.text = "New Photo Album Entry" + " \""+Globals.currentObjective+"\"";
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
	        Globals.ToDoList = playerData.ToDoList;
		player.position = new Vector3(playerData.positionX,playerData.positionY,playerData.positionZ);
            Debug.Log("DatosCargados");
        
		
	}


}
