using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float minRandForce = 5, maxRandForce = 10;
    public int pointValue = 10;
    public int splits = 2;

    Rigidbody2D rb = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Random.insideUnitCircle * Random.Range(minRandForce, maxRandForce));
        rb.AddTorque(Random.Range(-500, 500) * Mathf.Deg2Rad);
    }
}
