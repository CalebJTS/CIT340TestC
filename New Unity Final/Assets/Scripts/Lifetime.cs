using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public float timeToExpire = 3;

    void Start()
    {
        Invoke("Die", timeToExpire);       
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
