using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectCollection : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    GameObject[] collectables;
    public Text counter;
    void Start()
    {

    }

    public int returnCoinsRemaining()
    {
        return collectables.Length;
    }

    // Update is called once per frame
    void Update()
    {
        collectables = GameObject.FindGameObjectsWithTag("collect");

        counter.text = "Rosecoins Remaining: " + collectables.Length.ToString();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            if (collectables.Length == 0)
            {
                LevelChange.SwitchLevel(false, "Ending");
            }
        }
        
    }
}
