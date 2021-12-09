using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeChange1 : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (rb.velocity.magnitude > .01f)
        {
            anim.SetBool("isSpotted", true);
        }
        else
        {
            anim.SetBool("isSpotted", false);
        }

        if (rb.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (rb.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
