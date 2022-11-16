using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhotoAlbumManager : MonoBehaviour
{
	public GameObject[] pages;
	int page;
	public TextMeshPro pageText;
	public TextMeshPro PhotosPercent;
	
	
	
	public void ChangePage(int newPage){
		
		page = newPage;
	}
	
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		for(int i = 0; i<= pages.Length-1;i++){
			if(i==page){
				pages[i].SetActive(true);
				pageText.text = (page+1) + "/"+(pages.Length);
				
				PhotosPercent.text = ((Globals.actualPhotos*100)/Globals.totalPhotos)+"%";
			}
			else{
				pages[i].SetActive(false);
			}
			
			
		}
		
		
		
	}
	
	public void NextPage() 
	{
		page ++;
		if(page>pages.Length-1){
			page = pages.Length-1;
		}
	}
	
	public void PrevPage(){
		page--;
		if(page<0){
			page = 0;
		}
	}
	
	
	
}
