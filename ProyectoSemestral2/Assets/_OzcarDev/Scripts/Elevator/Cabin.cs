using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabin : MonoBehaviour
{
	
	public Transform EndPoint,StartPoint;
	public GameObject cabin;
	public float speed;
	private Vector3 currentPoint;
	private bool isActive;
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		isActive=false;
		currentPoint=StartPoint.position;
	}
	
	public void ActivateElevator()
	{
		isActive=true;
	}
	
	
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		if(!isActive)return;
		cabin.transform.position = Vector3.MoveTowards(transform.position,currentPoint,speed*Time.deltaTime);
		if(cabin.transform.position==EndPoint.position){
			currentPoint=StartPoint.position;
			isActive=false;
		}
		if(cabin.transform.position == StartPoint.position){
			currentPoint=EndPoint.position;
			isActive=false;
		}
	}
}
