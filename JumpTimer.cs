using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
    //global variables
    Animator myAnim;
    Rigidbody myRB;

    //for jump
    //create empty object "checkGroundLocation" and add it to rufus(make a tag)
    //create a ground layer in the inspector and add it to the floor obj
    bool grounded=false; 
    Collider[] groundCollision; //adding a collision detect
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer; //select ground layer in the inspector
    public Transform groundCheck; // drop "checkGorundLocation" here
    public float jumpHeight;

	//timer
	private float timer;


    void Start() {
		myAnim=GetComponent<Animator>();
		myRB=GetComponent<Rigidbody>();
		timer = 0f;
    }
    void FixedUpdate() {
    //for jumping
        if(grounded && Input.GetKey(KeyCode.S)){
			grounded = false;
            myAnim.SetBool("grounded",grounded);
        //here add a new parameter float "yVelocity " use to check if rufus is raising or falling
        // if(myRB.velocity >0){myAnim.setFloat(yVelocity,yVelocity)}
        //set myRB.velocity as a variable 
		//	myRB.velocity=Vector3.up*jumpHeight;
        }

		//timer
		if (Input.GetKey (KeyCode.S)&&timer<0.5f) {
			timer+=Time.deltaTime;
			myRB.velocity=Vector3.up*jumpHeight;
			Debug.Log(timer);
				}
		if (Input.GetKeyUp (KeyCode.S)) {
			timer=1;
				}

    
                        //·add circle       ·call the check position ·have a radius  ·check is it grounded.
        groundCollision = Physics.OverlapSphere(groundCheck.position,groundCheckRadius,groundLayer);
        if (groundCollision.Length > 0) {
			grounded = true; //if GC detect GL set parameter true
			timer=0;
				}
        else grounded = false;
                       //·parameter ·variable
        myAnim.SetBool("grounded",grounded); 

    }
}  




