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
		GameObject image = GameObject.Find("RawImage");
		if (isLoaded)
		{
			photo.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", sampleTexture);
		}
	  
        
    }

}
