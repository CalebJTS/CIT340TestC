using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float speed = 10;
    public int damage = -1;

    static Player playerReference;

    private void Start()
    {
        if (playerReference == null)
            playerReference = FindObjectOfType<Player>();
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = Random.ColorHSV(0, 1, 1, 1, 1, 1);
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector3(Time.deltaTime * speed, 0, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //gameObject;//Refers to the object this script is on (the laser)
        //collision.gameObject;//Refers to the object it collided with

        if(collision.gameObject.tag == "enemy")
            Destroy(collision.gameObject);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            //In order to spawn baby asteroids by copying the parent asteroid, this just checks
            //if it is going to kill the asteroid, then copies, then destroys the parent.

            //Refactoring = reorganizing code to make it more efficient and/or readable
            //This code should be a function in the asteroid script, instead of here
            bool killedAsteroid = collision.gameObject.GetComponent<Health>().WillKill(damage);
           /* if(killedAsteroid)
            {
               // AsteroidManager.asteroidManagerInstance.currentAsteroidCount--;

                //GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().ChangeScore(10);
                //or
                //FindObjectOfType<Player>().ChangeScore(10);

                Enemy asteroid = collision.gameObject.GetComponent<Enemy>();
                playerReference.ChangeScore(asteroid.pointValue);
                if(asteroid.splits > 0)
                {
                    for (int i = 0; i < 2; ++i)
                    {
                        GameObject babyAsteroidObj = Instantiate(asteroid.gameObject, asteroid.gameObject.transform.position, asteroid.gameObject.transform.rotation);
                        Vector3 scale = babyAsteroidObj.transform.localScale;
                        Asteroid babyAsteroid = babyAsteroidObj.GetComponent<Asteroid>();
                        babyAsteroidObj.transform.localScale = new Vector3(scale.x / 2, scale.y / 2, scale.z / 2);
                        babyAsteroid.splits--;
                        babyAsteroid.pointValue /= 2;
                        babyAsteroid.transform.position += (Vector3)Random.insideUnitCircle;
                    }
                }
            }*/
            collision.gameObject.GetComponent<Health>().ChangeHealth(damage);
        }
        GameObject explosion = Instantiate(explosionPrefab, transform.position,
                Quaternion.Euler(0, 0, Random.Range(0, 360.0f)));
        //explosion.transform.localScale = new Vector3(1, 1, 1) * Random.Range(.2f, .6f);
        explosion.transform.localScale = Vector3.one * Random.Range(.2f, .6f);
        Destroy(gameObject);
    }
}
