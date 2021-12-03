using UnityEngine;

public class WrapAroundEasy : MonoBehaviour
{
    public float xValue = 10.2f, yValue = 6.25f;
	
	void Update ()
    {
        Transform t = gameObject.transform;

        if (t.position.x <= -xValue)
            t.position = new Vector3(xValue - .1f, t.position.y, t.position.z);
        else if (t.position.x >= xValue)
            t.position = new Vector3(-xValue + .1f, t.position.y, t.position.z);

        if (t.position.y <= -yValue)
            t.position = new Vector3(t.position.x, yValue-.1f, t.position.z);
        else if (t.position.y >= yValue)
            t.position = new Vector3(t.position.x, -yValue+.1f, t.position.z);
    }
}
