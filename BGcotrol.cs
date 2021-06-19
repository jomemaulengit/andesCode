using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BGcotrol : MonoBehaviour
{
    //=================PUBLIC VARIABLES=================================
    public Transform spawner;
    public GameObject obA;
    public SpriteRenderer layer0;
    float layer0jump;
    public SpriteRenderer layerb4;
    float layerb4jump;
    //=================INSTANCES AND PRIVATES==========================
    GameObject obAInstance;
    //================COROUTINES========================================
    //================DEFINE VARIABLES==================================
    void Start(){
        layer0jump=layer0.bounds.size.x*7;
        layerb4jump=layerb4.bounds.size.x*4;
    }
    //===============TRIGGERS============================================
 void OnTriggerEnter(Collider other) {
    if(other.CompareTag("ground")){
        other.transform.Translate(layer0jump,0,0);
    }
    
    if(other.CompareTag("LayerB4")){
        other.transform.Translate(layerb4jump,0,0);
    }
    if(other.CompareTag("OB")){
        Destroy(other.gameObject);
        obAInstance=Instantiate(obA,spawner.position,Quaternion.identity);
    }
 }
}