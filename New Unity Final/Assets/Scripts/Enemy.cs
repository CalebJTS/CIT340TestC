using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject laserPrefab;
    public int power = 25;
    public float fireDelay = .25f;
    Rigidbody2D rb = null;
    bool canFire = true;
    public Text remainText;

    int remain = 7;
    // Start is called before the first frame update

    public void ChangeRemain(int remained)
    {
        remain -= remained;
        remainText.text = "Enemy remaining: " + remain.ToString();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            Debug.Log("The Player object should have a RigidBody2D component!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (canFire == true)
        {
            transform.Rotate(new Vector3(0, 0, 20));
            GameObject laser = Instantiate(laserPrefab, transform.GetChild(0).position, transform.rotation * Quaternion.Euler(0,0,90));
            laser.GetComponent<EnemyLaser>().damage = -power;
            canFire = false;
            Invoke("Reload", fireDelay);
        }
    }

    void Reload()
    {
        canFire = true;
    }
}
