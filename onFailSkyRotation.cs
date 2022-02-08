using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onFailSkyRotation : MonoBehaviour
{
    void FixedUpdate()
    {
        this.gameObject.transform.Rotate(new Vector3(0, 0, 0.02f));
    }
}
