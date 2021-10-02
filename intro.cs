using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class intro : MonoBehaviour
{
    // =========================PUBLIC VARIABLES===================================
    public Transform spawner;
    public GameObject obA; // <<< obstacle A to start spawning routine. 
//========================================================================================
    public bool introIsOver=false;
    public bool isInstantiated=false;
    public new transformBehavior camera;
    public Image image;
    public Sprite title;
    public Text text;
    public GameObject tip; // <<< hint text at gamestart.
    public float yoffsetSpeed;
    public float fadeRatio;
    public GameObject limiter;
    //==========================PLAYER SPAWN========================================
    public GameObject player;
    public Vector3 spawnPoint;
    public GameObject train;
    [System.NonSerialized]
    public GameObject instancePlayer;
    Vector3 rotation;
    GameObject obAInstance;

    //==========================COROUTINES=========================================
    IEnumerator IntroPos(){
        for(float g =150f; g>=0f; g-=yoffsetSpeed){
            camera.yOff+=yoffsetSpeed*0.955f;// <<<0.955f is for margin camera offset.
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator FadeIn(){
        for(float f =0.04f; f<=1f; f+=fadeRatio){
            image.color=new Color(255,255,255,f);
            if(image.color.a>=0.9f && introIsOver==false){
                StartCoroutine("FadeOut");
                StopCoroutine("FadeIn");
            }  
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator FadeOut(){
        for(float fo =0.9f; fo>0f; fo-=fadeRatio){
            image.color=new Color(255,255,255,fo);
            if(image.color.a<=0.02f){
                StartCoroutine("FadeIn");
                image.sprite=title;
                fadeRatio=0.008f;
                introIsOver=true;
                StopCoroutine("FadeOut");
            }             
            yield return new WaitForSeconds(0.007f);
        }
    }
    void Start()
    {
     Application.targetFrameRate = 60;
     StartCoroutine("IntroPos");   
     StartCoroutine("FadeIn");   
     rotation=new Vector3 (0,90,0);
    }

    void FixedUpdate()
    { 
    //==========================ENABLE PLAYER TO SPAWN=================================================
     if(camera.yOff>=-0.006f){
         StopCoroutine("IntroPos");
         camera.yOff=0f;
         text.color= new Color(0,0,0,text.color.a+0.06f);
         spawnPoint=new Vector3(train.transform.position.x-200,player.transform.position.y,player.transform.position.z);
     }
    if(camera.yOff>=-0.006f && Input.GetKeyDown(KeyCode.S) && isInstantiated==false){
        obAInstance=Instantiate(obA,spawner.position,Quaternion.identity);
        instancePlayer=Instantiate(player,spawnPoint,Quaternion.identity);
        instancePlayer.transform.Rotate(rotation);
        instancePlayer.GetComponent<playerControl>().cam = this.transform.parent.gameObject;
        instancePlayer.GetComponent<playerControl>().limiter = limiter;
    //==========================MODIFIYNG CANVAS ON GAME START================================================
        camera.enabled=false;
        Destroy(image);
        Destroy(text);
        tip.GetComponent<tipfade>().enabled =true;
        isInstantiated=true;
        train.GetComponent<transformBehavior>().target=instancePlayer;
        train.GetComponent<transformBehavior>().speed=1.7f;
        this.enabled=false;
    }    
 }
}
