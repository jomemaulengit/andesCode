using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayTime : MonoBehaviour
{
    //sunlight
    Light myL;
    public float speed;
    public float intsty;
    //ambientlight
    public GameObject ambientL;
    Light ambL;
    public float ambientY;
    private float rotationX;
    public bool[] dayState={true,false,false,false};

void Start(){
    myL=GetComponent<Light>();
    ambL=ambientL.GetComponent<Light>();
}
void FixedUpdate(){
    //console
    //Debug.Log(rotationX);
    //sunlight
    rotationX=transform.localRotation.x;
    myL.intensity=intsty;
    ambL.intensity=ambientY; 
    Vector3 rotor= new Vector3(speed,0,0);
    transform.Rotate(rotor);


    //Dawn---------------------------------||  -9f LEA
    if (rotationX>=-0.08f && dayState[0]==true)
    {
            speed=0.01f;
            dayState[1]=true;
            dayState[0]=false;       
    }

    //dayLigth-----------------------------||  7f LEA
    if (rotationX>=0.06f && dayState[1]==true)
    {
            dayState[2]=true;
            dayState[1]=false;
    }
    //nightFall----------------------------||  23f LEA
    if (rotationX>=0.2f && dayState[2]==true)
    {
            dayState[3]=true;
            dayState[2]=false;
    }


    //nightLiht-----------------------------|| 45f LEA
    if (rotationX>=0.37f && dayState[3]==true)
    {
            dayState[0]=true;
            dayState[3]=false;
            if (rotationX>=0.7)
            {
                transform.localEulerAngles=new Vector3(-90,0,0);
            }
    }
    //----------------------------------------dayeffects
    //------------------DAWN------------------------
    if (dayState[1]==true)
    {
        ambL.color+=(Color.white*1)*0.001f;
        ambientY+=0.00013f;
        intsty-=0.0017f;
    }
    //------------------DAY----------------------------------
        if (dayState[2]==true)
    {
        //ambL.color+=(Color.white*1)*0.001f;
        ambientY-=0.001f;
        intsty+=0.001f;
    }
   }
}