using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSceneCut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
	    AudioManager.Instance.PlayMusic("theme_3");
	    StartCoroutine(Siguiente());
    }

	IEnumerator Siguiente(){
		yield return new WaitForSeconds(10f);
		LoadScene.Instance.LoadNextScene("Credits");
	}
}
