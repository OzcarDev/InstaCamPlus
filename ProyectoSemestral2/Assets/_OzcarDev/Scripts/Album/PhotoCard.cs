using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class PhotoCard : MonoBehaviour
{
    
    public string name;
	public TextMeshPro title;
	public GameObject photoCard;
	public GameObject photo;
	private Sprite mySprite;
	
	
	
	// Awake is called when the script instance is being loaded.


	// This function is called when the object becomes enabled and active.
	protected void OnEnable()
	{
		Foto();
	}
	
	
	public void Foto()
	{
		title.text = name;
	    
		if(!File.Exists(Application.persistentDataPath + "/fotos/"+ "_" + name + ".png"))
		{
			photoCard.SetActive(false);
			
			return;
		}
		photoCard.SetActive(true);
		
		byte[] byteArray = File.ReadAllBytes(Application.persistentDataPath + "/fotos/"+ "_" + name + ".png");

		//create a texture and load byte array to it
		// Texture size does not matter 
		Texture2D sampleTexture = new Texture2D(2,2);
		// the size of the texture will be replaced by image size
		bool isLoaded = sampleTexture.LoadImage(byteArray);
		// apply this texure as per requirement on image or material
		
		if (isLoaded)
		{
			sampleTexture = Resize(sampleTexture,896,504);
			mySprite = Sprite.Create(sampleTexture,new Rect(0,0,sampleTexture.width,sampleTexture.height),new Vector2(0.5f,0.5f),100f);
			photo.GetComponent<SpriteRenderer>().sprite = mySprite;
			
		}
	  
        
	}
    
	Texture2D Resize(Texture2D texture2D,int targetX,int targetY)
	{
		RenderTexture rt=new RenderTexture(targetX, targetY,24);
		RenderTexture.active = rt;
		Graphics.Blit(texture2D,rt);
		Texture2D result=new Texture2D(targetX,targetY);
		result.ReadPixels(new Rect(0,0,targetX,targetY),0,0);
		result.Apply();
		return result;
	}

}
