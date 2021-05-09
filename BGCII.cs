using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCII : MonoBehaviour
{
    float speed=1;
    public bool xFollow;
    public bool yFollow;
    public bool zFollow;
    
    float yoffset;
    public float ypos;
    public float offset;
    public GameObject target;

    // Update is called once per frame
    void FixedUpdate()
    { 
        yoffset=target.transform.position.y;        
        speed=target.transform.position.x; 
        transform.position= new Vector3(speed,ypos+yoffset*0.2f,transform.position.z);  


    }
}
 
