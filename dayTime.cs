using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayTime : MonoBehaviour
{
//============PUBLIC BACKGRAOUND OBJ's========================
    public Transform stars;
    public Vector3 epicicle;
    public GameObject sky;
    SpriteRenderer skyParalax;
    public float dayToDay;
    public GameObject sun;
    public Vector3 sunRotation;
    public GameObject moon;
    public Vector3 moonRotation;
    void Start(){
        skyParalax=sky.GetComponent<SpriteRenderer>();
        }

    void FixedUpdate(){
        //===============STARS ROTATIONS=================================
        stars.Rotate(epicicle);    
        sun.transform.Rotate(sunRotation);    
        moon.transform.Rotate(moonRotation);    
        //===============DAY AND SEASONS=================================
        Debug.Log(sun.transform.rotation.z);
        if(sky.transform.position.y >7200){
            sky.transform.Translate((Vector3.up*skyParalax.bounds.size.y)*-1.8f,Space.World);
        }
        sky.transform.Translate(Vector3.up * Time.deltaTime*dayToDay, Space.World);
    }
}
