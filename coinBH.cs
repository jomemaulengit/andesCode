using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinBH : MonoBehaviour
{
    public float angularSpeed;
    void FixedUpdate()
    {
        Vector3 rotation=new Vector3 (0,angularSpeed,0);
        transform.Rotate(rotation);
    }
}
