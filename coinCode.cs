using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCode : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 rotation=new Vector3 (0,3,0);
        transform.Rotate(rotation);
      
    }
}
