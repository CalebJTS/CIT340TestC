using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public float timeToExpire = 3;
    public bool start = true;

    void Start()
    {
        if(start)
        Invoke("Die", timeToExpire);       
    }

    public void startTimer()
    {
        Invoke("Die", timeToExpire);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
