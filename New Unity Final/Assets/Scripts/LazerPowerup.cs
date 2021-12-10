using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LazerPowerup : MonoBehaviour
{
    // Start is called before the first frame update
    public Text obtainedMessage;
    void Start()
    {
        
        //obtainedMessage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

        col.gameObject.GetComponent<PlayerControls>().laserUnlocked(true);
        //gameObject.GetComponent<Player>().laserUnlockedShip(true);
        Destroy(gameObject);
        //obtainedMessage.enabled = true;
        

    }

   
}
