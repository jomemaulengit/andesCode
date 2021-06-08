using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class intro : MonoBehaviour
{
    // =========================PUBLIC VARIABLES===================================
    public new transformBehavior camera;
    public Image image;
    public Text text;
    public float yoffsetSpeed;
    public float fadeRatio;
    //==========================COROUTINES=========================================
    IEnumerator IntroPos(){
        for(float g =150f; g>=0f; g-=yoffsetSpeed){
            camera.yOff+=yoffsetSpeed;
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator FadeIn(){
        for(float f =0.04f; f<=1f; f+=fadeRatio){
            image.color=new Color(255,255,255,f);
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator FadeOut(){
        for(float fo =0.9f; fo>0f; fo-=fadeRatio){
            image.color=new Color(255,255,255,fo);
            yield return new WaitForSeconds(0.01f);
        }
    }
    void Start()
    {
     StartCoroutine("IntroPos");   
     StartCoroutine("FadeIn");   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     if(image.color.a>=0.9f){
         StopCoroutine("FadeIn");
         StartCoroutine("FadeOut");
     }   
     if(camera.yOff>=-0.0001f){
         StopCoroutine("IntroPos");
         camera.yOff=0f;
        //  this.enabled=false;
     }
    }
}
