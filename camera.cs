using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    //===================PUBLIC VARIABLES===================================
    //===================PRIVATE VARIABLES==================================
    transformBehavior moves;
    void Start(){
        moves=GetComponent<transformBehavior>();
    }

    void FixedUpdate()
    {
    //===================INTRO===============================================

    }
}
