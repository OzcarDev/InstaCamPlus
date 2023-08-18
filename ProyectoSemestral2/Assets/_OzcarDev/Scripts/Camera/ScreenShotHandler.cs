using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class ScreenShotHandler : MonoBehaviour
{
    // Start is called before the first frame update

	public bool takeScreenShotOnNextFrame;
    private Camera myCamera;
    GameManager gameManager;
    
	// Awake is called when the script instance is being loaded.
	protected void Awake()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	public void TakeScreenshot()
	{  
        
		StartCoroutine(CoroutineScreenshot());
	    
	}
	
	private IEnumerator CoroutineScreenshot(){
		gameManager.panelPhotoMode.SetActive(false);
		yield return new WaitForEndOfFrame();
	
		int width= Screen.width;
		int height=Screen.height;
		Texture2D screenshotTexture=new Texture2D(width, height, TextureFormat.ARGB32,false);
		Rect rect = new Rect(0,0,width,height);
		screenshotTexture.ReadPixels(rect,0,0);
		screenshotTexture.Apply();
		
		byte[] byteArray = screenshotTexture.EncodeToPNG();
		System.IO.File.WriteAllBytes(Application.persistentDataPath +"/fotos/"+"_"+Globals.Instance.currentObjective+".png", byteArray);
		Debug.Log("Screenshot");
		if(Globals.Instance.playerKeys.Contains("PhotoAlbum"))
		{
			
			gameManager.ToDoList();
			gameManager.Draw();
	        	
		}
		yield return new WaitForEndOfFrame();
		gameManager.panelPhotoMode.SetActive(true);
		gameManager.Flash.GetComponent<Animator>().Play("Idle");
		gameManager.Flash.GetComponent<Animator>().CrossFade("Flash",0.01f);
		AudioManager.Instance.PlaySFX("Photo");
	}
	
	
	
	/*
	private void Awake()
	{
		RenderPipelineManager.endCameraRendering += RenderPipelineManager_endCameraRendering;
       
	}
    
	private void OnDisable(){
		RenderPipelineManager.endCameraRendering-= RenderPipelineManager_endCameraRendering;
	}
    
	private void RenderPipelineManager_endCameraRendering(ScriptableRenderContext arg1,Camera arg2){
		if(takeScreenShotOnNextFrame){
			takeScreenShotOnNextFrame=false;
			int width = Screen.width;
			int height = Screen.height;
			Texture2D renderResult = new Texture2D(width, height, TextureFormat.ARGB32,false);
			Rect rect = new Rect(0, 0, width, height);
			renderResult.ReadPixels(rect, 0, 0);
			renderResult.Apply();
			
			byte[] byteArray = renderResult.EncodeToPNG();
			System.IO.File.WriteAllBytes(Application.persistentDataPath +"/fotos/"+"_"+Globals.currentObjective+".png", byteArray);
			Debug.Log("ScreenShot");
			if(Globals.playerKeys.Contains("PhotoAlbum"))
			{
	        	
				gameManager.ToDoList();
				gameManager.Draw();
	        	
			}
			
			gameManager.panelPhotoMode.SetActive(true);
			gameManager.Flash.GetComponent<Animator>().Play("Idle");
			gameManager.Flash.GetComponent<Animator>().Play("Flash");
			AudioManager.Instance.PlaySFX("Photo");
		}
	}

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	*
	private IEnumerator OnPostRender()
	{   
		
		yield return new WaitForEndOfFrame();
		
        if (takeScreenShotOnNextFrame)
        {
	      
            takeScreenShotOnNextFrame = false;
            RenderTexture renderTexture = myCamera.targetTexture;

	        Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32,false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);

            renderResult.ReadPixels(rect, 0, 0);

	        byte[] byteArray = renderResult.EncodeToPNG();
	        System.IO.File.WriteAllBytes(Application.persistentDataPath +"/fotos/"+"_"+Globals.currentObjective+".png", byteArray);
	        Debug.Log("ScreenShot");
	        
	        if(Globals.playerKeys.Contains("PhotoAlbum"))
	        {
	        	
	        	gameManager.ToDoList();
	        	gameManager.Draw();
	        	
	        }
	        
	       
            RenderTexture.ReleaseTemporary(renderTexture);
            
	        myCamera.targetTexture = null;
	        yield return new WaitForEndOfFrame();
	        gameManager.panelPhotoMode.SetActive(true);
	        gameManager.Flash.GetComponent<Animator>().Play("Idle");
	        gameManager.Flash.GetComponent<Animator>().Play("Flash");
	        AudioManager.Instance.PlaySFX("Photo");
        }
		
	}*/



}
