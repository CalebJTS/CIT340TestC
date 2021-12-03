using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{


    public GameObject effect;
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
        Instantiate(effect, transform.position, transform.rotation);
        Debug.Log("Picked up!");
        col.gameObject.GetComponent<Health>().heal();
        Destroy(gameObject);
    }
}
