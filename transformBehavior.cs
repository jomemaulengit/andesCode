using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformBehavior : MonoBehaviour
{
    //==================PUBLIC OBJECTS TO MOVE
    public float speed;
    public GameObject target;
    public float scape_limit;
    public float xOff;
    public float yOff;
    public bool selfMove=false;
    float distance;
    void FixedUpdate()
    {
        //====================FIXED VARIABLES=====================================
        distance = Vector3.Distance(transform.position,target.transform.position);
        float x=target.transform.position.x;
        float y=transform.position.y;
        float z=transform.position.z;
        //====================moves  
        if(selfMove==true){
            transform.position+= Vector3.right*speed;
        }
        else{
            transform.position= new Vector3(x+xOff,y+yOff,z);
        }
        if(distance>1000){
            transform.Translate(-400f,0,0);
        }
    }
}
