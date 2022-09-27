using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class  InteractMenu: MonoBehaviour,IPointerEnterHandler, IPointerExitHandler,IPointerDownHandler
{
	public Animator anim;
	public float obset;
	private float inicialPosition;
	
	public GameObject active;
	public GameObject deactive;
	public bool isPhotocard;
	
	public void OnPointerEnter(PointerEventData pointerEventData)
	{
		if(anim==null)return;
		anim.CrossFade("Show",0.25f);
		var objectTransform = anim.gameObject.GetComponent<Transform>();
		inicialPosition = objectTransform.position.z;
		objectTransform.position = new Vector3(objectTransform.transform.position.x,objectTransform.position.y,obset);
		
	}
	
	public void OnPointerExit(PointerEventData pointerEventData)
	{   
		if(anim==null)return;
		anim.CrossFade("Hide",0.25f);
		var objectTransform = anim.gameObject.GetComponent<Transform>();
		objectTransform.position = new Vector3(objectTransform.transform.position.x,objectTransform.position.y,inicialPosition);
		
	}
	
	public void OnPointerDown(PointerEventData pointerEventData)
	{
		if(isPhotocard)
		{
			
			
		}
		
		if(active==null||deactive==null) return;
		ActivePanels();
		
	}
	
	
	public void ActivePanels()
	{
		deactive.SetActive(false);
		active.SetActive(true);
	}
	
}
