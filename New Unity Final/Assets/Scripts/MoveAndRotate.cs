using UnityEngine;

public class MoveAndRotate : MonoBehaviour
{
    //Hook in a full gameobject
    public GameObject targetObject;
    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    //Hook in a gameobject's Transform component
    //Can get the gameobject itself using targetTransform.gameObject
    public Transform targetTransform;

    //Just a position, no reference to a specific gameObject
    public Vector3 targetPosition;

    public float activationRange = 2;
    public float speedPerSecond = 3;
    public float spriteAngleCompensation = 0;

    public bool useActivationRange = true;
    public bool shouldRotateTowardObject = false;
    public bool targetMouse = false;

    void Start()
    {
        //if (targetTransform == null)
            //targetTransform = FindObjectOfType<PlayerControls>().transform;
    }

    void Update()
    {
        if (targetMouse)
        {
            //This gives us where the mouse is in pixels on the screen (i.e. (400, 700))
            //NOT a position in the Unity world.
            //Input.mousePosition;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = 0;
            targetPosition = mouseWorldPosition;
        }
        else if (targetTransform != null)
            targetPosition = targetTransform.position;
        else if (targetObject != null)
            targetPosition = targetObject.transform.position;

        //Moving Toward a target object within a certain distance
        Vector3 directionVector =
            targetPosition - transform.position;

        //Distance = sqrt((x2-x1)+(y2-y1))
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
        float distanceToTarget2 = directionVector.magnitude;

        if (useActivationRange && distanceToTarget2 > activationRange)
        {
            
            return;
        }

        //Normalizing a vector = results in the same direction, but length = 1
        //length = magnitude
        //Effectively 'extracts' the direction from a vector without the magnitude
        directionVector.Normalize();
        
        transform.position += directionVector * speedPerSecond * Time.deltaTime;

        
        //Rotating toward a target object
        if (!shouldRotateTowardObject)
            return;

        //Atan returns an angle from 0 to 90, and you have to 
        //add extra if the x is negative, y is negative, etc.
        //float angle = Mathf.Atan;

        //most programming libraries fix that with a convenient 'Atan2' function
        //Rotate toward an object with Trigonometry
        //float angle = 
        //    Mathf.Atan2(directionVector.y, directionVector.x) * Mathf.Rad2Deg;
        //transform.rotation = 
        //   Quaternion.Euler(new Vector3(0, 0, angle + spriteAngleCompensation));

        //Rotate toward an object (shortcut)
        transform.right = directionVector;
        transform.Rotate(new Vector3(0, 0, spriteAngleCompensation));
    }
}
