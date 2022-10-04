using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoAlbumManager : MonoBehaviour
{
	public GameObject[] pages;
	
	public void ChangePage(int page){
		for(int i = 0; i<= pages.Length-1;i++){
			if(i==page){
				pages[i].SetActive(true);
			}
			else{
				pages[i].SetActive(false);
			}
		}
		
	}
	
}
