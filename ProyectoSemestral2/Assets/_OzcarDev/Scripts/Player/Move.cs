﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Move : MonoBehaviour
    {
	    // Movement
	    public Settings settings;
	    CharacterController characterController;
	    Rigidbody rigidbody;
        private float x;
        private float z;
        public float maxSpeed;
        public float crouchSpeed;
        public float groundSpeed;
        private float speed;
        private Vector3 dir;
        public float gravityForce;
        GameManager gameManager;

        //Rotation
        private Transform cam;
        Vector2 inputRot;
        public float sensibility;

        //Crouch
        Vector3 normalScale;
        Vector3 crouchScale;
        Vector3 lieScale;
       
        public float crouchingTime;

        public enum State
        {
            Normal,
            Crouching,
            Ground
        }
        public State _State;

	    private bool isTeleporting=false;
	    
	    private bool nextStep = true;
	    public float stepDuration;
	    private int stepindex;
        void Start()
	    {
	    	
		    rigidbody = GetComponent<Rigidbody>();
            Globals.Instance.playerKeys.Add("");
            speed = maxSpeed;
            _State = State.Normal;
            gameManager = GameObject.Find("GameManager").GetComponent <GameManager> ();
            characterController = GetComponent<CharacterController>();
            cam = transform.Find("Camera");
	       
            
	        

            normalScale = transform.localScale;
            crouchScale = normalScale;
            crouchScale.y = normalScale.y * 0.75f;
            lieScale = normalScale;
	        lieScale.y = normalScale.y * 0.2f;
	        
        }

	   
	   
        // Update is called once per frame
        void Update()
	    {
		   

		    if (gameManager.isPaused||gameManager.readingMode||isTeleporting||gameManager.photoAlbumMode) return;
		    
            RotateMouse();
		    Movement();
            Crouch();
            
            
        }

       

        void RotateMouse()
	    {
		  
		    inputRot.x = Input.GetAxis("Mouse X") * sensibility*settings.mouseSensitivity;
		    if(settings.invert_y_axis) 
			    inputRot.y = Input.GetAxis("Mouse Y") * sensibility*settings.mouseSensitivity*-1;
		    if(!settings.invert_y_axis) 
			    inputRot.y = Input.GetAxis("Mouse Y") * sensibility*settings.mouseSensitivity;
            
            transform.Rotate(Vector3.up*inputRot.x*sensibility*settings.mouseSensitivity);

            float angle = (cam.localEulerAngles.x - inputRot.y * sensibility+360)%360;

            if (angle > 180) angle -= 360;
            angle = Mathf.Clamp(angle, -80, 80);

            cam.localEulerAngles = Vector3.right * angle;
        }



        void Movement()
	    {
		    
            x = Input.GetAxisRaw("Horizontal");
            z = Input.GetAxisRaw("Vertical");

            dir.x = x;
		    dir.z = z;
		   
			 
		    var  movePlayer = dir.normalized.x * cam.right+ dir.normalized.z*transform.forward; 
            var gravity = Vector3.down * Time.deltaTime * gravityForce;
		    characterController.Move( (movePlayer* Time.deltaTime * speed)+gravity);
		   
		    if((dir.x!=0||dir.z!=0)&&nextStep){
		    	StartCoroutine(Step());
		    }
		    
		    if(Input.GetKey(KeyCode.LeftShift)&&_State == State.Normal){
		    	speed = 8;
		    	stepDuration = 0.25f;
		    }
		  
		    if(Input.GetKeyUp(KeyCode.LeftShift)&&_State==State.Normal){
		    	speed = maxSpeed;
		    	stepDuration = 0.4f;
		    }
            
	    }
        
	    IEnumerator Step(){
	    	nextStep = false;
	    	stepindex = Random.Range(0,10);
	    	AudioManager.Instance.PlaySFX("footstep"+stepindex);
	    	yield return new WaitForSeconds(stepDuration);
	    	
	    	nextStep = true;
	    	
	    	
	    }

        private Coroutine CrouchCoroutine;
        void Crouch()
	    { 
            if (Input.GetButtonDown("Crouch")&&CrouchCoroutine==null)
            {
                switch (_State)
                {
                    case State.Normal:
	                    _State = State.Crouching;
	                    stepDuration = 0.8f;
                        speed = crouchSpeed;
                        CrouchCoroutine=StartCoroutine(Crouching(normalScale, crouchScale));
                        
                        break;

                    case State.Crouching:
	                    _State = State.Ground;
	                    stepDuration = 1.2f;
                        speed = groundSpeed;
                        CrouchCoroutine = StartCoroutine(Crouching(crouchScale, lieScale));

                        break;

                    case State.Ground:
                        _State = State.Normal;
	                    speed = maxSpeed;
	                    stepDuration = 0.4f;
                        CrouchCoroutine = StartCoroutine(Crouching(lieScale, normalScale));

                        break;

                    default:
	                    _State = State.Normal;
	                    stepDuration = 0.4f;
                        speed = maxSpeed;
                        CrouchCoroutine = StartCoroutine(Crouching(lieScale, normalScale));
                        break;
                }
            }
           
        }

        IEnumerator Crouching(Vector3 a, Vector3 b)
        {
            
            float time=0;

            while (time < crouchingTime)
            {
                time += Time.deltaTime;
                float value = time / crouchingTime;
                transform.localScale = Vector3.Lerp(a, b,value);
                yield return null;
            }
            CrouchCoroutine = null;
        }
        
	    public IEnumerator Teleporting(Vector3 target){
	    	isTeleporting = true;
	    	yield return new WaitForEndOfFrame();
	    	this.gameObject.transform.position = target;
	    	yield return new WaitForEndOfFrame();
	    	isTeleporting = false;
	    }

    
}