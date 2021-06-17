using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
//==============================PUBLIC VARIABLES============================================
	public float speed;
	public float jumpHeight;
//==============================COMPONENTS===================================
    Animator myAnim;
    Rigidbody myRB;
//=============================JUMP VARIABLES========================================
	bool grounded=false; 
	Collider[] groundCollision; 
	float groundCheckRadius = 0.2f;
	public LayerMask groundLayer; 
	public Transform groundCheck;
	private float timer=0;


    void Start()
    {
        myRB=GetComponent<Rigidbody>();
        myAnim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
    //========================MOVE FORWARD=====================================
        myRB.velocity=new Vector3(speed,myRB.velocity.y,0);
		if (grounded==true)
		{
			myRB.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
		}else
		{
			transform.localEulerAngles= new Vector3(0,90,0);
			myRB.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ  | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
		}  
    //=======================COLLISION EVENTS=====================================
    	groundCollision = Physics.OverlapSphere(groundCheck.position,groundCheckRadius,groundLayer);
		if (groundCollision.Length > 0) {
			grounded = true;
			timer=0;   
		}
		else grounded = false;
		timer += Time.deltaTime;
		myAnim.SetBool("grounded",grounded);
    //========================JUMP CONTROL=======================================
    	myAnim.SetFloat("isUp",myRB.velocity.y);
		if (timer<0.4f&& Input.GetKey (KeyCode.S)) {
			myRB.velocity=new Vector3(myRB.velocity.x,jumpHeight,0);

		if (grounded == false && myRB.velocity.y < 0) {
			timer=2;
			}
		 }	
    }
}
