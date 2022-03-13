using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinBH : MonoBehaviour
{
    public float angularSpeed;
    AudioSource coinSound;

    void Start()
    {
        coinSound = GetComponent<AudioSource>();
    }
    
    public void playCoinSound()
    {
        coinSound.Play();
    }

    void FixedUpdate()
    {
        Vector3 rotation=new Vector3 (0,angularSpeed,0);
        transform.Rotate(rotation);
    }
}
