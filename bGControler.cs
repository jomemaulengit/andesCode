using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class bGControler : MonoBehaviour
{
    public SpriteRenderer length;
    public SpriteRenderer length2;
    float layern2jump;
    float layern1jump;
    float layer0jump;
    float layer1jump;
    float layer2jump;
    float layer3jump;

    void Start(){
        layern2jump=length.bounds.size.x;
        layern1jump=length.bounds.size.x*4;
        layer0jump=length.bounds.size.x*7;
        layer1jump=length.bounds.size.x*10;
        layer2jump=length.bounds.size.x*12;
        layer3jump=length2.bounds.size.x*3;
    }

 void OnTriggerEnter(Collider other) {
    if(other.CompareTag("ground")){
        other.transform.Translate(layer0jump,0,0);
    }
    if (other.CompareTag("coin")){
        Destroy(other.gameObject);
    }
    if (other.CompareTag("periferic")){
    other.transform.Translate(layer1jump,0,0);
    }
    if (other.CompareTag("periferic4")){
     other.transform.Translate(layer3jump,0,0);
    }
    }
} 
