using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowPhoto : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
	public Animator photo;
	public void OnPointerEnter(PointerEventData pointerEventData)
	{
		photo.CrossFade("Show",0.25f);
		
	}
	
	public void OnPointerExit(PointerEventData pointerEventData)
	{
		photo.CrossFade("Hide",0.25f);
		
	}
}
