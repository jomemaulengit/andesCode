using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BGcotrol : MonoBehaviour
{
    //=================PUBLIC VARIABLES=================================
    public Sprite[] trains;
    int i=0;                     //<<<<train sprites index
    public GameObject train;
    public Transform spawner;
    public GameObject[] objs;
    public GameObject[] mediumObjs;
    public GameObject[] fastObjs;
    public int counter = 1;
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
        if(GameObject.FindGameObjectsWithTag("OB").Length<=1 && counter==1){
            obAInstance=Instantiate(objs[Random.Range(0,objs.Length)],spawner.position,Quaternion.identity);
        }
        else if(GameObject.FindGameObjectsWithTag("OB").Length<=1 && counter==2){
            obAInstance=Instantiate(mediumObjs[Random.Range(0,mediumObjs.Length)],spawner.position,Quaternion.identity);
        }       
        else if(GameObject.FindGameObjectsWithTag("OB").Length<=1 && counter==3){
            obAInstance=Instantiate(fastObjs[Random.Range(0,fastObjs.Length)],spawner.position,Quaternion.identity);
        }
    }
    if(other.CompareTag("train")){
        other.transform.Translate(3000,0,0);
        other.GetComponent<SpriteRenderer>().sprite=trains[i];
        if(i<4){
        i++;
        }
        else{
        i=4;
        }
        Debug.Log(i);
    }
  }
}
