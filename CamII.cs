using UnityEngine;
using System.Collections;

public class CamII : MonoBehaviour {
	//falta agregar condicionales para que la camara se aleje con la velocidad y lo siga
	//al caer fuera del rango de la camara

	//target variables
	public Transform target;
	public Rigidbody targetRB;
	//follow speed
	public float smoothness;
	//X,Y,Z offset
	private float xOffset=10f;
	private float yCamPos;
	public float zoom=-10f;
	private float yFollowSpeed=0.4f;
	//camera target Lerp point B
	Vector3 targetCamPos;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// y camera offset position dinamics with the zoom
		yCamPos = (-zoom)*0.4f;
		//camera position equal to target position plus respective offset
		targetCamPos = new Vector3 (target.position.x+xOffset,(target.position.y*yFollowSpeed)+yCamPos,zoom);
		//camera follow from point A (actual position) to point B (target position)        / follow speed
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothness * Time.deltaTime);
	}
}
