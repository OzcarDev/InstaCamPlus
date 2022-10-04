using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class  InteractMenu: MonoBehaviour,IPointerEnterHandler, IPointerExitHandler,IPointerDownHandler
{
	public Animator anim;
	public float obset;
	private float inicialPosition;
	public int index;
	public bool isPhotocard;
	PhotoAlbumManager manager;
	
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		manager = GameObject.Find("PhotoAlbumManager").GetComponent<PhotoAlbumManager>();
	}
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
		
		else{
			manager.ChangePage(index);
		}
	}
	
	
	
}