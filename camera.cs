using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
//===================PUBLIC VARIABLES===================================  
public transformBehavior moves;
public intro canvasControl;
Transform player;
//===================LERP VARIABLES=====================================
public float yOff;
public float xOff;
public float zoom;
public float smoothness;

Vector3 targetXYZ;
void FixedUpdate(){
//==========================SET CAMERA TARGET ON GAME START=================================================
    if(moves.enabled==false){
        player=canvasControl.instancePlayer.transform;
        targetXYZ=new Vector3(player.position.x+xOff,player.position.y+yOff,player.position.z+zoom);
        transform.position= Vector3.Lerp(transform.position,targetXYZ,smoothness);
    }
}
}
