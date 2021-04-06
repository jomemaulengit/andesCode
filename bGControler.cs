using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class bGControler : MonoBehaviour
{
    public Transform cam;
    public float length,dis;
    public float limitDis;
    float layerDraw;
    // Start is called before the first frame update
    void Start()
    {
        layerDraw=GetComponent<SpriteRenderer>().sortingOrder;
        length=GetComponent<SpriteRenderer>().bounds.size.x;
        limitDis=length*4;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dis=cam.position.x-transform.position.x;
        if(dis>limitDis){
            transform.position= new Vector3(transform.position.x+length*7,transform.position.y,transform.position.z);
        }
    }
}
