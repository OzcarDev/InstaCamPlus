using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Credits: MonoBehaviour
{
	// Start is called before the first frame update
    
	public float seconds;
	public string scene;
	public TextMeshProUGUI text;
	
    void Start()
    {
	    Invoke("End",seconds);
	    if(text == null)return;
	    Ending();
    }
    
    
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape)){
			End();
		}
	}
    
	public void End(){
		LoadScene.Instance.LoadNextScene(scene);
		
	}
    
	void Ending(){
		if(Globals.Instance.actualPhotos>=Globals.Instance.totalPhotos){
			text.text = "Fotógrafo local gana premio de fotografía nacional";
		} else {
			text.text = "Fotógrafo local muere de hambre";
		}
	}

}
