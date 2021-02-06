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
    float groundCheckRadius = 0,2f;
    public LayerMask groundLayer; //select ground layer in the inspector
    public Transform groundCheck; // drop "checkGorundLocation" here
    public float jumpHeight;


    void Start() {
        
    }
    void FixedUpdate() {
    //for jumping
        if(grounded && input.GetAxis("jump")>0){
            grounded = false;
            myAnim.setBool("grounded",grounded);
            myRB.addForce(new vector3(0.jumpheight,0));
        }           
    
                        //·add circle       ·call the check position ·have a radius  ·check is it grounded.
        groundCollision = Physics.OverlapSphere(groundCheck.position,groundCheckRadius,groundLayer);
        if(groundCollision.length>0) grounded = true; //if GC detect GL set parameter true

        else grounded = false;
                       //·parameter ·variable
        myAnim.setBool("grounded",grounded); 

    }

}  




