using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menucamera : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {  
        transform.position= new Vector3(transform.position.x+speed,transform.position.y,transform.position.z);

    }
}
