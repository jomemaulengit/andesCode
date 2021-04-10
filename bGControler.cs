using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class bGControler : MonoBehaviour
{
    public SpriteRenderer length;
    float paralaxJump;

    void Start(){
        paralaxJump=length.bounds.size.x;
    }

 void OnTriggerEnter(Collider other) {
 if(other.CompareTag("ground")){
     other.transform.Translate(paralaxJump*7,0,0);
  }
 }
} 
