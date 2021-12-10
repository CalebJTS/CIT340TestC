using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEnabled : MonoBehaviour
{
    public Text Text;
    // Start is called before the first frame update
    void Start()
    {
        Text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Text.enabled = true;
            Destroy(gameObject);
        }
    }
}
