using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShotHandler : MonoBehaviour
{
    // Start is called before the first frame update

    private static ScreenShotHandler instance;
    private bool takeScreenShotOnNextFrame;
    private Camera myCamera;
    GameManager gameManager;


    void Awake()
    {
        instance = this;
        myCamera = gameObject.GetComponent<Camera>();
    }

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnPostRender()
    {
        if (takeScreenShotOnNextFrame)
        {
            
            takeScreenShotOnNextFrame = false;
            RenderTexture renderTexture = myCamera.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32,false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);

            renderResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.persistentDataPath +"_"+Globals.currentObjective+".png", byteArray);
	        Debug.Log("ScreenShot");
	        
	        if(Globals.playerKeys.Contains("PhotoAlbum"))
	        {
	        	
	        	gameManager.ToDoList();
	        	gameManager.Draw();
	        	
	        }
	        
	        gameManager.panelPhotoMode.GetComponent<Animator>().Play("Flash");
            RenderTexture.ReleaseTemporary(renderTexture);
            
            myCamera.targetTexture = null;
        }
    }

    private void TakeScreenshot(int width, int height)
    {
        myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeScreenShotOnNextFrame = true;
    }

    public static void TakeScreenshot_Static(int width, int height)
    {
        instance.TakeScreenshot(width, height);
    }
}
