using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject laserPrefab;
    public float speedUPerSecond = 2;
    public float anglePerSecond = 60;
    public float fireDelay = .25f;
    public int power = 25;
    public Text scoreText;
    int remain = 7;
    public bool unlocked = false;
    

    int score = 0;
    bool canFire = true;
    Rigidbody2D rb = null;

    public void ChangeScore(int changeInScore)
    {
        
        score += changeInScore;
        scoreText.text = score.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("hasLazer"))
        {
            if(PlayerPrefs.GetInt("hasLazer") == 1)
            {
                unlocked = true;
            }
            else
            {
                unlocked = false;
            }
        }
        if(PlayerPrefs.HasKey("Crystals"))
        {
            switch (PlayerPrefs.GetInt("Crystals"))
            {
                case 1:
                    scoreText.text = "Crystals: " + 1;
                    break;
                case 2:
                    scoreText.text = "Crystals: " + 2;
                    break;
                case 3:
                    scoreText.text = "Crystals: " + 3;
                    break;
                case 4:
                    scoreText.text = "Crystals: " + 4;
                    break;
                case 5:
                    scoreText.text = "Crystals: " + 5;
                    break;


            }
            
        }
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            Debug.Log("The Player object should have a RigidBody2D component!");
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void laserUnlockedShip(bool check)
    {
        unlocked = check;
    }

    public int getUnlockedLazer(bool check)
    {
        if (check == true)
        {
            return 1;
        }
        else
            return 0;
    }



    //FixedUpdate is synchronized with the physics engine
    //Use FixedUpdate to avoid jitter when objects are moving into each other.
    void FixedUpdate()
    {
        //Hardcoded input - bad except for quick testing
        //if (Input.GetKey(KeyCode.D))
            //transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

        //The original sprite is made with the ship facing to the right, so 
        //movement X will move the ship forward/backward,
        //and movement Y will be left and right.
        float rotation = -Input.GetAxis("Horizontal");//A D 
        float thrust = Input.GetAxis("Vertical");//W S

        //Movement method 1: 
        //Movement like this will use the World's X and Y axis
        //so the ship won't go the right direction if it ever turns.
        //transform.position += new Vector3(movementY * speedUPerSecond * Time.deltaTime, 0, 0);

        //Movement method 2: 
        //Moving like this does take into account the object's current direction.
        //It still isn't true 'physical' movement though, more like a teleportation.
        //transform.Translate(new Vector3(movementY * speedUPerSecond * Time.deltaTime, 0, 0));
        //transform.Rotate(new Vector3(0, 0, anglePerSecond * movementX * Time.deltaTime));

        //Movement method 3: 
        //Physical based movement, will have momentum and apply force to objects it hits
        //also doesn't require factoring in Time.deltaTime because physics updating does that for us.
        rb.AddForce(transform.right * thrust * speedUPerSecond, 0);
        rb.AddTorque(rotation * anglePerSecond * Mathf.Deg2Rad);

        //For finer control over physically based movement, we can directly set 
        //the velocity this way:
        //rb.velocity = new Vector2(0, 0);
        //rb.angularVelocity = 0;
    if(unlocked == true)
        {
            if (canFire && Input.GetAxis("Fire1") == 1)//more efficient, avoids checking Input.GetAxis whenever canFire is false
                                                       //if (Input.GetAxis("Fire1") == 1 && canFire)
            {
                GameObject laser = Instantiate(laserPrefab, transform.GetChild(1).position, transform.rotation);
                laser.GetComponent<Laser>().damage = -power;
                canFire = false;
                Invoke("Reload", fireDelay);
            }
        }
       
    }

    void Reload()
    {
        canFire = true;
    }
}
