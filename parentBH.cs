using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentBH : MonoBehaviour
{
    void FixedUpdate()
    {
        if(this.transform.childCount<1){
            Destroy(this.gameObject);
        }
    }
}
