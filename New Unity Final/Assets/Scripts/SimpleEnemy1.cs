using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy1 : MonoBehaviour
{
    public int damage;
    public Laser laser;
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.GetComponent<Health>().ChangePlayerHealth(-damage);
        }
        else if (collision.gameObject.tag == "Laser")
        {
            gameObject.GetComponent<Health>().ChangeHealth(laser.damage);
        }


    }
    // Update is called once per frame
    void Update()
    {

    }
}
