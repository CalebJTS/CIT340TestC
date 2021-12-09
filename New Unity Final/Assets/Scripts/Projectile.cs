using UnityEngine;

public class Projectile : MonoBehaviour
{
    float speed = 3;

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;    
    }
}
