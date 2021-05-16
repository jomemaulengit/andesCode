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
    float xPlayerPos=1;
    public float zoom;
    public bool isInstantiated=false;
    Vector3 spawnPoint;
    public bool endIntro;
    
    public float yoffset;
    public float ypos;
    float yPlayerPos;
    public float xoffset;
    public GameObject target;
    public GameObject train;
    GameObject instantiatedTarget;
//===================xoffset zoom coroutine================================
//===================================================================
    IEnumerator AdjustOffset(){
        for(float g =150f; g>=0f; g-=0.7f){
            xoffset-=0.7f;
            yoffset+=0.03f;
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator Zoom(){
        for(float j = 280; j>150; j-=0.7f){
            zoom+=0.7f;
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
            //spawn with x xoffset and zoom
            if (isInstantiated==false)
            {
                spawnPoint=new Vector3(train.transform.position.x-150,target.transform.position.y,target.transform.position.z);
                xoffset+=150;
                StartCoroutine("AdjustOffset");
                StartCoroutine("Zoom");
                instantiatedTarget=Instantiate(target,spawnPoint,Quaternion.identity);
                isInstantiated=true;
            }
            yPlayerPos=instantiatedTarget.transform.position.y;        
            xPlayerPos=instantiatedTarget.transform.position.x;
            Vector3 playerPos= new Vector3(xPlayerPos,yPlayerPos-yoffset,zoom); 
            transform.position= Vector3.Lerp(transform.position,playerPos,0.1f);  

        }
//============INTRO=======================================================
//=================================================================================        
        else{ 
            ypos-=0.6f;      
            transform.position= new Vector3(train.transform.position.x+xoffset,ypos,zoom);
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
 
