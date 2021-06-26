using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BGcotrol : MonoBehaviour
{
    //=================PUBLIC VARIABLES=================================
    public Sprite[] trains;
    public GameObject train;
    public Transform spawner;
    public GameObject[] objs;
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
        if(GameObject.FindGameObjectsWithTag("OB").Length<=1){
            obAInstance=Instantiate(objs[Random.Range(0,objs.Length)],spawner.position,Quaternion.identity);
        }
    }
    if(other.CompareTag("train")){
        int i=0;
        other.transform.Translate(3000,0,0);
        other.GetComponent<SpriteRenderer>().sprite=trains[i];
        i++;
    }
  }
}
