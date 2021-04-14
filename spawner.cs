using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] coins;
    Vector3 thisPos;

 void FixedUpdate(){
     thisPos=transform.position;
     if (Input.GetKeyDown(KeyCode.S))
     {
      Instantiate(coins[0],thisPos, Quaternion.identity);
     }
 }

}
