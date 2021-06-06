using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    //===================PUBLIC VARIABLES===================================
    //===================PRIVATE VARIABLES==================================
    transformBehavior component;
    void Start(){
        component=GetComponent<transformBehavior>();
    }

    void FixedUpdate()
    {
        Debug.Log(component.target);
    }
}
