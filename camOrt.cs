using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class camOrt : MonoBehaviour {
	public Rigidbody myRB;
	void Start () {
		myRB=GetComponent<Rigidbody>();	
	}
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.U)){
			myRB.AddForce(0,0,10);
		}
		if (Input.GetKey(KeyCode.J))
		{
			transform.position= new Vector3(transform.position.x,transform.position.y,transform.position.z-0.5f);
		}
	}
}