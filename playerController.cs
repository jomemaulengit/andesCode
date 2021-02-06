using UnityEngine;
using System.Collections;
public class playerController : MonoBehaviour {
    //for jump
    //create empty object "checkGroundLocation" and add it to rufus feets(make a tag)
    bool grounded=false; 
    Collider[] groundCollision; //adding a collision detect
    float groundCheckRadius = 0,2f;
    public LayerMask groundLayer; //select ground layer in the inspector
    public Transform groundCheck; // drop "checkGorundLocation" here
    public float jumpHeight;


    void Start() {
        
    }
    void FixedUpdate() {
        //for jump           ·add circle       ·call the check position ·have a radius  ·check is it grounded.
        groundCollision = Physics.OverlapSphere(groundCheck.position,groundCheckRadius,groundLayer);
        if(groundCollision>0) grounded

    }

}