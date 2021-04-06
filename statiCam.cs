using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statiCam : MonoBehaviour
{
    public GameObject bgControler;
    public float bgSpeed;
    private float bgXoffset;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bgXoffset=bgControler.transform.position.x;
        bgControler.transform.position=new Vector3(bgXoffset+bgSpeed,527,-650);
    }
}
