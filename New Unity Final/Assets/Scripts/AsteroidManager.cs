using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public static AsteroidManager asteroidManagerInstance;

    public int asteroidLimit = 10;
    public int currentAsteroidCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (asteroidManagerInstance == null)
            asteroidManagerInstance = this;
    }

    public bool AtLimit()
    {
        return currentAsteroidCount == asteroidLimit;
    }
}
