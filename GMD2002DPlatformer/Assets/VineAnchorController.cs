using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineAnchorController : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    void OnCollision2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Solids")
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }
    }
}
