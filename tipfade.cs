using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tipfade : MonoBehaviour
{
    public Text tip;
    float inc = 0.1f;

    // Update is called once per frame
    void FixedUpdate()
    {
     tip.color = new Color(255,255,255,inc);
     inc+=0.01f;
     if(inc>7){
         tip.color = new Color(255,255,255,0);
         this.enabled=false;
     }
    }
}
