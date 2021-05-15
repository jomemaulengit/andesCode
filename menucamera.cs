using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menucamera : MonoBehaviour
{
    //================fade reference canvas==========================
    public Image image;
    public GameObject canvasImage;
    public Text text;
    //===============================================================
    float speed=1;
    public float zoom;
    public bool isInstantiated=false;
    Vector3 spawnPoint;
    public bool endIntro;
    
    float yoffset;
    public float ypos;
    public float offset;
    public GameObject target;
    public GameObject train;
    GameObject instantiatedTarget;
//===================offset zoom coroutine================================
//===================================================================
    IEnumerator AdjustOffset(){
        for(float g =150f; g>=0f; g-=0.7f){
            offset-=0.7f;
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator Zoom(){
        for(float j = 280; j>150; j-=0.5f){
            zoom+=0.5f;
            yield return new WaitForSeconds(0.01f);
        }
    }
//===================================================================================
    void Start(){
        Camera cam=GetComponent<Camera>();
    }
    void FixedUpdate()
    { 
        if (endIntro==true)
        {
            //spawn with x offset and zoom
            if (isInstantiated==false)
            {
                spawnPoint=new Vector3(train.transform.position.x-150,target.transform.position.y,target.transform.position.z);
                offset+=150;
                StartCoroutine("AdjustOffset");
                StartCoroutine("Zoom");
                instantiatedTarget=Instantiate(target,spawnPoint,Quaternion.identity);
                isInstantiated=true;
            }
            yoffset=instantiatedTarget.transform.position.y;        
            speed=instantiatedTarget.transform.position.x; 
            transform.position= new Vector3(speed+offset,ypos+yoffset*0.2f,zoom);  

        }
//============INTRO=======================================================
//=================================================================================        
        else{ 
            ypos-=0.6f;      
            transform.position= new Vector3(train.transform.position.x+offset,ypos,zoom);
            if (ypos<=1f)
            {
                ypos=1f;
                if(Input.GetKey(KeyCode.S)){
                    endIntro=true;
//modifying canvas element on play start 
                    text.GetComponent<Text>().text="";
                    canvasImage.GetComponent<fade>().enabled=false;  
                    Destroy(image);
//=======================================================
                }
            }
        }

    }
}
 
