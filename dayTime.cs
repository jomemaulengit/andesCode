using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayTime : MonoBehaviour
{
    public float speed;
    public float intsty;
    Light myL;
    public Light ambientL;
    public float ambientY;

void Start(){
    myL=GetComponent<Light>();
}
void FixedUpdate(){
    Debug.Log(transform.localRotation.x);
    Vector3 rotor= new Vector3(speed,0,0);
    transform.Rotate(rotor);
    if(transform.localRotation.x>=-0.09f){
        myL.intensity=intsty;
        ambientL.intensity=ambientY; 
        speed=0.008f;
        if (intsty<=1.2f){
            intsty=1.2f;
        }else
        {
        intsty-=0.008f;
        ambientL.color+=(Color.white*1)*speed;
        }
    }
    if(transform.localRotation.x>=0.7f)
    {
        transform.localEulerAngles= new Vector3(-260,0,0);
        speed=0.4f;
        intsty=5f;
        ambientY=0.7f;
    }
  }
}