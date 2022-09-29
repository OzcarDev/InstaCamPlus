using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCVagrant: MonoBehaviour
{
	int rutina;
	float cronometro;
	Animator anim;
	public float cron;
	public Transform point;
	public Transform point1;
	public Transform point2;
	public float velRot;
	bool canRotate = false;
	public float rotationTime;
	public float speed;
	GameManager gameManager;
	CharacterController characterController;
    // Start is called before the first frame update
    void Start()
	{
	    anim = GetComponent<Animator>();
	    characterController = GetComponent<CharacterController>();
	    
	    gameManager = GameObject.Find("GameManager").GetComponent <GameManager> ();
    }

    // Update is called once per frame
    void Update()
	{
		
		if(gameManager.isPaused) return;
		if (gameManager.readingMode) {
		
			anim.SetBool("Walk",false);
			rutina = 0;
			cronometro = 0;
			return;
		}
		IdentificarPared();
	    Behaviour();
	    if(canRotate)Rotar();
	}
    
	void IdentificarPared(){
		RaycastHit hit1;
		RaycastHit hit2;
		RaycastHit hit3;
		if(Physics.Raycast(point.position,point.forward, out hit1, 2.5f)||Physics.Raycast(point1.position,point1.forward,out hit2,1f)||Physics.Raycast(point2.position,point2.forward,out hit3,1f)){
			Rotar();
		}
	}
    
	void Behaviour()
	{
		cronometro += 1*Time.deltaTime;
		if(cronometro >=cron ) {
			rutina = Random.RandomRange(0,3);
			cronometro = 0;
		}
		
		switch(rutina)
		{
		case 0:
			anim.SetBool("Walk",false);
			break;
			
		case 1:
			canRotate=true;
			rutina++;
			break;
			
		case 2:
			var gravity = Vector3.down * Time.deltaTime * 10;
			Vector2 resultado = new Vector2(Mathf.Cos(transform.eulerAngles.y*Mathf.Deg2Rad), Mathf.Sin(transform.eulerAngles.y*Mathf.Deg2Rad));
			characterController.Move( (new Vector3(resultado.y,0,resultado.x)* Time.deltaTime * speed)+gravity);
			anim.SetBool("Walk",true);
			
			break;
		
			
		}
	}
	
	void Rotar()
	{
		transform.Rotate(Vector3.up*velRot*Time.deltaTime);	
		StartCoroutine(RotationTime());
		
		
	}
	
	IEnumerator RotationTime(){
		yield return new WaitForSeconds (rotationTime);
		canRotate = false;
	}
    
}
