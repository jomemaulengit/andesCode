using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayTime : MonoBehaviour
{
    public float speed;
    public float intensity;
    Light myL;
void Start(){
    myL=GetComponent<Light>();
}
void FixedUpdate(){
    myL.intensity=intensity; 
    Vector3 rotor= new Vector3(speed,0,0);
    transform.Rotate(rotor);
}
}
