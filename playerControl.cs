using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour {
    //global variables
    Animator myAnim;
    Rigidbody myRB;
	public float speed;
	public float jumpHeight;

	//jump
	bool grounded=false; 
	Collider[] groundCollision; 
	float groundCheckRadius = 0.2f;
	public LayerMask groundLayer; 
	public Transform groundCheck;
	private float timer=0;


	void Start() {
		myAnim=GetComponent<Animator>();
		myRB=GetComponent<Rigidbody>();
	}
	void FixedUpdate() {
		//for move forward
		Debug.Log(timer);
		myRB.velocity = new Vector3 (speed, myRB.velocity.y, 0);

		//for collision
		groundCollision = Physics.OverlapSphere(groundCheck.position,groundCheckRadius,groundLayer);
		if (groundCollision.Length > 0) {
			grounded = true;
			timer=0;
		}
		else grounded = false;
		timer += Time.deltaTime;
		myAnim.SetBool("grounded",grounded);


		//jump
		if (timer<0.4f&& Input.GetKey (KeyCode.S)) {
			myRB.velocity=new Vector3(myRB.velocity.x,jumpHeight,0);
				}
		if (grounded == false && myRB.velocity.y < 0) {
			timer=2;
				}
   }

}

