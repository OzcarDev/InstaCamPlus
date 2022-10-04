using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhotoCard : MonoBehaviour
{
    
    public string name;
	public TextMeshPro title;
    
	public IEnumerator Start()
    {
	    WWW www = new WWW (Application.persistentDataPath + "/fotos/"+ "_" + name + ".png");

        while (!www.isDone)
            yield return null;
        
        Texture2D sampleTexture = www.texture;
        if(sampleTexture != null)
            gameObject.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", sampleTexture);

	    title.text = name;
        
    }

}
