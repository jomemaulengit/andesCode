using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayTime : MonoBehaviour
{
//============PUBLIC BACKGRAOUND OBJ's========================
    public float globalSync=1f;
    public GameObject stars;
    public Renderer starsColor;
    public Vector3 epicicle;
    public GameObject sky;
    public float skyParalax;
    public float dayToDay;
    public GameObject sun;
    public Light sunLight;
    public float glowTop=1f;
    public float glowSpeed=0.01f;
    public Vector3 sunRotation;
    public GameObject moon;
    public Vector3 moonRotation;
    //===================Coroutines=========================================
    IEnumerator DawnShine(){
    for(float k = 0.1f; k<glowTop; k+=glowSpeed*globalSync)
      {
        sunLight.intensity=k;
        sunLight.color = Color.Lerp(Color.blue,Color.white,k);
        starsColor.material.color = Color.Lerp(Color.white,Color.clear,k);
        yield return new WaitForSeconds(0.01f);
      }
    }
    IEnumerator FallShine(){
    for(float k = glowTop; k>0.1f; k-=glowSpeed*globalSync)
      {
        sunLight.intensity=k;
        yield return new WaitForSeconds(0.01f);
      }
    }
    IEnumerator StarFade(){
    for(float k = 0.1f; k<glowTop; k+=glowSpeed*globalSync)
      {
        sunLight.color = Color.Lerp(Color.white,Color.blue,k);
        starsColor.material.color = Color.Lerp(Color.clear,Color.white,k);
        yield return new WaitForSeconds(0.01f);
      }
    }
    void FixedUpdate(){
        //===============FIXED VARIABLES=================================
        float absSunRot=Convert.ToSingle(Math.Abs(sun.transform.rotation.z));
        //===============STARS ROTATIONS=================================
        stars.transform.Rotate(epicicle*globalSync);    
        sun.transform.Rotate(sunRotation*globalSync);    
        moon.transform.Rotate(moonRotation*globalSync);    
        //===============DAY AND SEASONS=================================
        if(absSunRot <0.001f){
            sky.transform.position=new Vector3(sky.transform.position.x,skyParalax,sky.transform.position.z);
            StopCoroutine("StarFade");
            StartCoroutine("DawnShine");
        }
        sky.transform.Translate(Vector3.up * Time.deltaTime*dayToDay*globalSync, Space.World);        
        if(absSunRot>0.999999f){
            StopCoroutine("DawnShine");
            StartCoroutine("FallShine");
            StartCoroutine("StarFade");
        }
    }
}
