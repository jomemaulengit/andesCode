using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class fade : MonoBehaviour
{
    public Image image;
    public Sprite target;
    public Text text;
    public float textAlpha;
    public float fadeSpeed=0.02f;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        // text =GetComponent<Text>();
        textAlpha=text.color.a;
    }
    IEnumerator FadeIn(){
        for(float f = 0.04f; f <= 1f; f+=fadeSpeed){
            image.color=new Color(255,255,255,f);
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator FadeOut(){
        for(float g =0.9f; g>=0f; g-=fadeSpeed){
            image.color=new Color(255,255,255,g);
            if(image.color.a<=0.01f){
                image.GetComponent<Image>().sprite=target;
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
    void FixedUpdate(){
        if(image.color.a<=0.005f){
            StartCoroutine("FadeIn");
        }
        if(image.color.a>=0.9f){
            StopCoroutine("FadeIn");
            StartCoroutine("FadeOut");
        }
        if(image.color.a>=0.8f && image.GetComponent<Image>().sprite==target){
            StopCoroutine("FadeOut");
            if(image.color.a>0.8f){
                text.color= new Color(0,0,0,text.color.a+0.03f); 
            }
        }
    }
}
