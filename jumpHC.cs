using UnityEngine;
using System.Collections;

public class jumpHC : MonoBehaviour {
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
    private float jumpHeight;

    void Start() {
		myAnim=GetComponent<Animator>();
		myRB=GetComponent<Rigidbody>();
		jumpHeight = 20;
    }
    void FixedUpdate() {
    //for jumping
        if(grounded && Input.GetKeyDown(KeyCode.S)){
			grounded = false;
            myAnim.SetBool("grounded",grounded);
        //here add a new parameter float "yVelocity " use to check if rufus is raising or falling
        // if(myRB.velocity >0){myAnim.setFloat(yVelocity,yVelocity)}
        //set myRB.velocity as a variable 
			myRB.AddForce(new Vector3(myRB.velocity.x,jumpHeight,0));
        }
    
                        //·add circle       ·call the check position ·have a radius  ·check is it grounded.
        groundCollision = Physics.OverlapSphere(groundCheck.position,groundCheckRadius,groundLayer);
        if (groundCollision.Length > 0) {
			grounded = true; //if GC detect GL set parameter true
				}
        else grounded = false;
                       //·parameter ·variable
        myAnim.SetBool("grounded",grounded); 

    }
}  




