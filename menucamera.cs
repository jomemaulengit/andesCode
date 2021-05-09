using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menucamera : MonoBehaviour
{
    float speed=1;
    public bool isInstantiated=false;
    Vector3 spawnPoint;
    public bool yFollow;
    public bool zFollow;
    
    float yoffset;
    public float ypos;
    public float offset;
    public GameObject target;
    public GameObject train;
    GameObject instantiatedTarget;

    void Start(){
        Camera cam=GetComponent<Camera>();
    }
    void FixedUpdate()
    { 
        //Debug.Log(20000f*Mathf.Tan(cam.fieldOfView*Mathf.Deg2Rad));
        if (yFollow==true)
        {
            //spawn player but no camera set
            if (isInstantiated==false)
            {
                spawnPoint=new Vector3(train.transform.position.x,target.transform.position.y,target.transform.position.z);
                // Instantiate(target,spawnPoint,Quaternion.identity);
                instantiatedTarget=Instantiate(target,spawnPoint,Quaternion.identity);
                isInstantiated=true;
            }
            yoffset=instantiatedTarget.transform.position.y;        
            speed=instantiatedTarget.transform.position.x; 
            transform.position= new Vector3(speed+offset,ypos+yoffset*0.2f,transform.position.z);  

        }
        else{ 
            ypos-=0.3f;      
            transform.position= new Vector3(train.transform.position.x+offset,ypos,transform.position.z);
            if (ypos<=1f)
            {
                yFollow=true;
            }
        }

    }
}
 
