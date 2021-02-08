using UnityEngine;
using System.Collections;

public class runing : MonoBehaviour {
	Rigidbody myRB;
	public float speed;
	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		myRB.velocity = new Vector3 (speed, myRB.velocity.y,0);
	}
}
