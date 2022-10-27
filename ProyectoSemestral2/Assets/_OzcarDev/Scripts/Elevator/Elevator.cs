using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
	
	public PlayAnim doors;
    
	public void _Elevator()
	{
		StartCoroutine(ElevatorCoroutine());
	}
	
	IEnumerator ElevatorCoroutine()
	{
		gameObject.GetComponent<BoxCollider>().enabled = false;
		doors.PlayAnimation();
		yield return new WaitForSeconds(3);
		doors.PlayAnimation();
		gameObject.GetComponent<BoxCollider>().enabled = true;
	}
	
	// OnTriggerEnter is called when the Collider other enters the trigger.
	protected void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="Player"){
			other.transform.parent = transform;
		}
	}
	
	// OnTriggerExit is called when the Collider other has stopped touching the trigger.
	protected void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag=="Player"){
			other.transform.parent = null;
		}
	}
}
