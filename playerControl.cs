using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerControl : MonoBehaviour
{
//==============================PUBLIC VARIABLES============================================
	public float speed;
	public float jumpHeight;
	public int coins;
	public GameObject cam;
	public GameObject limiter;
	public Image image;
//==============================COMPONENTS PRIVATES & INSTANCES===================================
    Animator myAnim;
    Rigidbody myRB;
	Vector3 pointA;
	Vector3 pointB;
	AudioSource footSteps;
	int counter;
//=============================JUMP VARIABLES========================================
	bool grounded=false; 
	Collider[] groundCollision; 
	public float groundCheckRadius = 3f; //modify 
	public LayerMask groundLayer; 
	public Transform groundCheck;
	private float timer=0;
//===========================COROUTINES====================================================
    IEnumerator FadeOut(){
        for(float fo =0f; fo<255f; fo+=0.1f){
            image.color=new Color(0,0,0,fo);
			if(image.color.a>=0.98f)
			SceneManager.LoadScene(2);
            yield return new WaitForSeconds(0.007f);
        }
    }
	//======================================================================================
    void Start()
    {
        myRB=GetComponent<Rigidbody>();
        myAnim=GetComponent<Animator>();
		this.footSteps=GetComponent<AudioSource>();
    }


//===========================TRIGGERS=====================================================
	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("coin")){
			other.gameObject.GetComponent<coinBH>().playCoinSound();
			coins+=1;
			if(speed<110){
				speed+=0.4f; //<<<< how speed increment for each coin collected
			}
			other.gameObject.GetComponent<MeshRenderer>().enabled=false;
			other.gameObject.GetComponent<BoxCollider>().enabled=false;
		}
		if(other.CompareTag("Zoom")){
			cam.GetComponent<camera>().flag = true; //<<< camera.flag activate zoom coroutine in camera script
		}
		if(other.CompareTag("zoomout")){
			cam.GetComponent<camera>().flag = false;
		}
		if(other.CompareTag("harmful")){
			speed=-60;
			jumpHeight=40;
			coins=0;
		}
		if(other.CompareTag("dead")){
			StartCoroutine("FadeOut");
		}
	}
//=========================================================================================
    void FixedUpdate()
    { 
		if(speed<40){
			speed+=1f;
		}
		else if(speed<60){
			limiter.GetComponent<BGcotrol>().counter = 1;
			jumpHeight=45;
		}else if(speed>=60 && speed<=80){
			limiter.GetComponent<BGcotrol>().counter = 2;
			jumpHeight=50;
		}else if(speed>80){
			limiter.GetComponent<BGcotrol>().counter = 3;
			jumpHeight=60;
		}

    //========================MOVE FORWARD=====================================
        myRB.velocity=new Vector3(speed,myRB.velocity.y,0);
		if (grounded==true)
		{
			myRB.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
		}else
		{
			footSteps.Play();
			transform.localEulerAngles= new Vector3(0,90,0);
			myRB.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ  | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
		}  
    //=======================COLLISION EVENTS=====================================
		pointA= groundCheck.position;
		pointB= new Vector3(groundCheck.position.x,groundCheck.position.y,groundCheck.position.z-9f);

    	groundCollision = Physics.OverlapCapsule(pointA,pointB,groundCheckRadius,groundLayer);
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
