using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
	Transform target;
	public string animationName;
	GameManager gameManager;
	bool rotate = false;
	public bool Sit;
	public bool Lay;
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		target = GameObject.FindGameObjectWithTag("Player").transform;
		if(Sit){
			gameObject.GetComponent<Animator>().Play(animationName);
		}
		
	}
	
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		
		if(!gameManager.readingMode)
		{
			rotate = false;
			
		}
		
		if(rotate) {
		
		var lookPos = target.position - transform.position;
		lookPos.y = 0;
		var rotation = Quaternion.LookRotation (lookPos);
		
		transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation,3);
		}
	}
	
	public void LookAtMe()
	{
		if(Lay) return;
		
		rotate = true;
	}
}
