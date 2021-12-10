using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{


    public AudioClip SoundEffect;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Buff(collision);
        }

    }

    void Buff(Collider2D col)
    {
        
        Debug.Log("Picked up!");
        AudioSource.PlayClipAtPoint(SoundEffect, transform.position);
        Destroy(gameObject);
        
    }
}
