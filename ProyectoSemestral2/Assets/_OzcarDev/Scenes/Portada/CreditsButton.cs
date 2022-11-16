using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreditsButton : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler,IPointerDownHandler
{
	public Animator anim;
    // Start is called before the first frame update
 public void OnPointerEnter(PointerEventData pointerEventData)
	{
		anim.CrossFade("Show",0.25f);
		Debug.Log("IN");
	}
	
	public void OnPointerExit(PointerEventData pointerEventData)
	{ 
		anim.CrossFade("Hide",0.25f);
		Debug.Log("OUT");
	}
	
	public void OnPointerDown(PointerEventData pointerEventData)
	{
		LoadScene.Instance.LoadNextScene("Credits");
	}
	
}
