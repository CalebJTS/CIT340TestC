using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    GameObject collection;
    // Start is called before the first frame update
    void Awake()
    {
        collection = GameObject.Find("objectCollection");
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(collection.GetComponent<objectCollection>().returnCoinsRemaining() == 0)
            {
                LevelChange.SwitchLevel(false, "worldMap");
            }
            else
            {
                Debug.Log("Not done yet");
            }
        }
    }
}
