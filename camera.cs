using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
//===================PUBLIC VARIABLES===================================================================
public transformBehavior moves;
public intro canvasControl;
public bool flag = false;
//===================LERP VARIABLES================================================================
public Vector3 offsetVectors;
public float Ytest;
public float smoothness;

playerControl playerC;
Transform playerT;
Vector3 targetXYZ;
//===================COROUTINES=====================================================================
IEnumerator ZoomIn(){
        if(flag==false){
          targetXYZ= Vector3.Lerp(targetXYZ,offsetVectors,1);
          offsetVectors.z=-(playerC.speed)-100;
          offsetVectors.y=-Ytest;
        }
        else if(flag==true){
          StartCoroutine("ZoomOut");
          StopCoroutine("ZoomIn");
        }
        yield return new WaitForSeconds(1);
    }    
IEnumerator ZoomOut(){
        if(flag==true){
          targetXYZ= Vector3.Lerp(targetXYZ,offsetVectors,1);
          offsetVectors.z=-(playerC.speed)-300;
          offsetVectors.y=-22f;
        }
        else if(flag==false){
          StartCoroutine("ZoomIn");
          StopCoroutine("ZoomIn");
        }
        yield return new WaitForSeconds(1);
    }    
void FixedUpdate(){
//==========================SET CAMERA TARGET ON GAME START=================================================
    if(moves.enabled==false){
        playerT=canvasControl.instancePlayer.transform;
        playerC=canvasControl.instancePlayer.GetComponent<playerControl>();
        offsetVectors.x=playerC.speed/1.3f;
        targetXYZ=new Vector3(playerT.position.x+offsetVectors.x,playerT.position.y+offsetVectors.y,playerT.position.z+offsetVectors.z);
        transform.position= Vector3.Lerp(transform.position,targetXYZ,smoothness);
        StartCoroutine("ZoomIn");
    }
  }
}
