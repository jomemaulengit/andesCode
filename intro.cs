using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class intro : MonoBehaviour
{
    // =========================PUBLIC VARIABLES===================================
    public bool introIsOver=false;
    public new transformBehavior camera;
    public Image image;
    public Sprite title;
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
     StartCoroutine("IntroPos");   
     StartCoroutine("FadeIn");   
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
     if(camera.yOff>=-0.0001f){
         StopCoroutine("IntroPos");
         camera.yOff=0f;
         text.color= new Color(0,0,0,text.color.a+0.06f);
     }
    }
}
