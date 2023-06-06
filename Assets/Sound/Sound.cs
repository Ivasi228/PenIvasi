using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    public AudioSource sound;

    void OnTriggerEnter2D(Collider2D collider)
    {
            sound.Play();
    }
}
