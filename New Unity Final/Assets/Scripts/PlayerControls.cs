using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    public Text CyrsText;
    int crystals = 0;
    public float speed = 3;
    public float jumpPower = 10;
    public float fireDelay = 8f;
    public int power = 25;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer spriteRenderer;
    AudioSource jumpSound;
    public GameObject laserPrefab;
    public GameObject laser2;
   Vector3 respawn;
    
    
    bool canJump = false;
    bool wasJumping = false;
    bool canFire = true;
    public bool unlocked = false;
    public bool unlocked2 = false;
    public bool unlocked3 = false;
    bool flipped = false;
     


    public int getCrystals()
    {
        return crystals;
    }

    public Vector3 getVector()
    {
        return respawn;
    }
    public void changeCrystals(int changeCrystals)
    {
        crystals += changeCrystals;
        CyrsText.text = "Crystals: " + crystals;

        
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        jumpSound = GetComponent<AudioSource>();
        respawn = transform.position;

        if (PlayerPrefs.HasKey("Crystals"))
        {
            changeCrystals(PlayerPrefs.GetInt("Crystals"));
        }

        if (PlayerPrefs.HasKey("hasLazer"))
        {
            unlocked = true;
        }
        else
        {
            unlocked = false;
        }

       

    }

    public void laserUnlocked(bool check)
    {
        unlocked = check;

    }

    public void laser2Unlocked(bool check)
    {
        unlocked2 = check;
    }

    public int getLazer(bool check)
    {
        if(check == true)
        {
            return 1;
        }
        else
        {
            return 0;
        }
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

        if(unlocked3 == true)
        {
            if (canFire && Input.GetAxis("Fire1") == 1)//more efficient, avoids checking Input.GetAxis whenever canFire is false
                                                       //if (Input.GetAxis("Fire1") == 1 && canFire)
            {
                if (flipped == false)
                {
                    GameObject laser = Instantiate(laser2, transform.GetChild(1).position, transform.rotation);
                    laser.GetComponent<HyperLazer>().damage = -power;
                    canFire = false;
                    Invoke("Reload", fireDelay);
                }
                else if (flipped == true)
                {
                    Vector3 flippedSpawn = transform.position + Vector3.Reflect(transform.GetChild(1).localPosition, Vector3.right);
                    //UnityEngine.Quaternion transformed = Quaternion.Inverse(transform.rotation);

                    Quaternion flippedspawnRotate = transform.rotation * Quaternion.Euler(0, 0, 180);
                    GameObject laser = Instantiate(laser2, flippedSpawn, flippedspawnRotate);
                    laser.GetComponent<HyperLazer>().damage = -power;
                    canFire = false;
                    Invoke("Reload", fireDelay);
                }

            }
        }

        if(unlocked2 == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && unlocked == true)
            {
                unlocked3 = true;
                unlocked = false;
            }
            else if(Input.GetKeyDown(KeyCode.E) && unlocked3 == true)
            {
                unlocked3 = false;
                unlocked = true; 
            }
        }





        //Jump Method 3: Correct way.
        if (isJumping)//if pressing the spacebar/trying to jump
        {
            //jumpSound.Play();
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Checkpoint":
                respawn = col.gameObject.transform.position;
                Debug.Log("TOuched");
                gameObject.GetComponent<Health>().heal();
                Debug.Log(respawn);
                break;
            case "Crystals":
                changeCrystals(1);
                Destroy(col.gameObject);
                break;
            case "Death":
                transform.position = respawn;
                gameObject.GetComponent<Health>().heal();
                break;
                /*case "Enemy":

                    if(gameObject.GetComponent<Health>().checkCurrentHealth() <= 0)
                    {
                        Debug.Log("What the");
                        transform.position = respawn;
                        gameObject.GetComponent<Health>().heal();
                        break;
                    }
                    else
                    {
                        Debug.Log("What the he");
                        break;
                    }*/


            }
        }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            int damage = collision.gameObject.GetComponent<SimpleEnemy1>().damage;
            if (gameObject.GetComponent<Health>().checkCurrentHealth(damage) <= 0)
            {
                Debug.Log(gameObject.GetComponent<Health>().checkCurrentHealth(damage));
                transform.position = respawn;
                gameObject.GetComponent<Health>().heal();
                
            }
            else
            {
                Debug.Log("What the h");
                Debug.Log(gameObject.GetComponent<Health>().checkCurrentHealth(damage));


            }
        }
        else if(collision.gameObject.tag == "Enemy1")
        {
            int damage = collision.gameObject.GetComponent<SimpleEnemy1>().damage;
            if (gameObject.GetComponent<Health>().checkCurrentHealth(damage) <= 0)
            {
                Debug.Log(gameObject.GetComponent<Health>().checkCurrentHealth(damage));
                transform.position = respawn;
                gameObject.GetComponent<Health>().heal();

            }
            else
            {
                Debug.Log("What the h");
                Debug.Log(gameObject.GetComponent<Health>().checkCurrentHealth(damage));


            }
        }
    }






    void Reload()
    {
        canFire = true;
    }

    

     
}
