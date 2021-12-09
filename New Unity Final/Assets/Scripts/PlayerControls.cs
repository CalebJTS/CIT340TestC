using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 3;
    public float jumpPower = 10;
    public float fireDelay = 8f;
    public int power = 25;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer spriteRenderer;
    AudioSource jumpSound;
    public GameObject laserPrefab;
    bool canJump = false;
    bool wasJumping = false;
    bool canFire = true;
    bool unlocked = false;
    bool flipped = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        jumpSound = GetComponent<AudioSource>();
    }

    public void laserUnlocked(bool check)
    {
        unlocked = check;
    }
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        //rb.velocity.x = speed * horizontalMovement;//not allowed
        rb.velocity = new Vector2(speed * horizontalMovement, rb.velocity.y);

        bool isJumping = Input.GetAxis("Jump") > 0;

        //Jump Method 1: Jetpack
        /*
            if (isJumping)
                rb.AddForce(Vector2.up * jumpPower);
        */

        //Jump Method 2: Saving your jump (BAD implementation, common rookie mistake)
        /*if(isJumping && canJump)
        {
            rb.AddForce(Vector2.up * jumpPower);
            canJump = false;
        }*/
        if (unlocked == true)
        {
            if (canFire && Input.GetAxis("Fire1") == 1)//more efficient, avoids checking Input.GetAxis whenever canFire is false
                                                       //if (Input.GetAxis("Fire1") == 1 && canFire)
            {
                if (flipped == false)
                {
                    GameObject laser = Instantiate(laserPrefab, transform.GetChild(1).position, transform.rotation);
                    laser.GetComponent<Laser>().damage = -power;
                    canFire = false;
                    Invoke("Reload", fireDelay);
                }
                else if(flipped == true)
                {
                    Vector3 flippedSpawn = transform.position + Vector3.Reflect(transform.GetChild(1).localPosition, Vector3.right);
                    //UnityEngine.Quaternion transformed = Quaternion.Inverse(transform.rotation);

                    Quaternion flippedspawnRotate = transform.rotation * Quaternion.Euler(0, 0, 180);
                    GameObject laser = Instantiate(laserPrefab, flippedSpawn, flippedspawnRotate);
                    laser.GetComponent<Laser>().damage = -power;
                    canFire = false;
                    Invoke("Reload", fireDelay);
                }
                
            }
        }




        //Jump Method 3: Correct way.
        if (isJumping)//if pressing the spacebar/trying to jump
        {
            jumpSound.Play();
            //Check if the feet are colliding with something right now
            Vector3 feetPosition = transform.GetChild(0).position;

            //C++: Collider2D colliders[];
            Collider2D[] colliders = Physics2D.OverlapCircleAll(feetPosition, .25f);
            for (int i = 0; i < colliders.Length; ++i)
            {
                if (colliders[i].gameObject == gameObject)
                    continue;

                //make each jump consistently the same speed/height
                rb.velocity = new Vector2(rb.velocity.x, 0);


                rb.AddForce(Vector2.up * jumpPower);
                break;
            }
        }


        if (rb.velocity.magnitude > .01f)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (rb.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
            flipped = true;
            

        }
        else if (rb.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
            flipped =false;
           
        }
    }

    void Reload()
    {
        canFire = true;
    }

     
}
