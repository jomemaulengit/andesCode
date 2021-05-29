using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayTime : MonoBehaviour
{
//============PUBLIC BACKGRAOUND OBJ's========================
    public Transform stars;
    public Vector3 epicicle;
    public GameObject sky;
    public float skyParalax;
    public float dayToDay;
    public GameObject sun;
    public Vector3 sunRotation;
    public GameObject moon;
    public Vector3 moonRotation;

    void FixedUpdate(){
        //===============STARS ROTATIONS=================================
        stars.Rotate(epicicle);    
        sun.transform.Rotate(sunRotation);    
        moon.transform.Rotate(moonRotation);    
        //===============DAY AND SEASONS=================================
        if(System.Math.Abs(sun.transform.rotation.z) <0.001f){
            sky.transform.position=new Vector3(sky.transform.position.x,skyParalax,sky.transform.position.z);
        }
        sky.transform.Translate(Vector3.up * Time.deltaTime*dayToDay, Space.World);

    }
}
