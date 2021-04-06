using UnityEngine;
using System.Collections;

public class CamII : MonoBehaviour {
	//falta agregar condicionales para que la camara se aleje con la velocidad y lo siga
	//al caer fuera del rango de la camara
	//inputFloat pasao/presente

	
	//target variables
	public Transform target;
	public GameObject targetGO;
	//follow speed
	public float smoothness;
	private float yFollowSpeed=0.2f;
	public float inputfloat=0f;
	//X,Y,Z offset
	private float xOffset=10f;
	private float yCamPos;
	public float zoom=-35f;

	private float targetSpeed;
	
	//camera target Lerp point B
	Vector3 targetCamPos;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		zoom=(-targetGO.GetComponent<playerControl>().speed*0.3f)-10f;
		xOffset=Mathf.Abs(zoom+4*1.5f);
		// y camera offset position dinamics with the zoom
		yCamPos = inputfloat+(-zoom)*0.5f;
		//camera position equal to target position plus respective offset
		targetCamPos = new Vector3 (target.position.x+xOffset,(target.position.y*yFollowSpeed)+yCamPos,zoom);
		//camera follow from point A (actual position) to point B (target position)        / follow speed
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothness * Time.deltaTime);
	}
}