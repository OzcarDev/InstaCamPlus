using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoCard : MonoBehaviour
{
    
    public string name;
    
    IEnumerator Start()
    {
        WWW www = new WWW (Application.persistentDataPath + "_" + name + ".png");

        while (!www.isDone)
            yield return null;
        
        Texture2D sampleTexture = www.texture;
        if(sampleTexture != null)
            gameObject.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", sampleTexture);

       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
