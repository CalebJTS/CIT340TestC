using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject objectToFollow;
    public float lerpPerFrame = .01f;
    public bool lockYAxis = false;

    void Update()
    {
        Vector3 objPos = objectToFollow.transform.position;
        //objPos = Vector3.Lerp(transform.position, objPos, .01f);
        //transform.position = new Vector3(objPos.x, objPos.y, transform.position.z);

        //(a little) Less Code:
        objPos.z = transform.position.z;
        if (lockYAxis)
            objPos.y = transform.position.y;

        transform.position = Vector3.Lerp(transform.position, objPos, lerpPerFrame);
    }
}
