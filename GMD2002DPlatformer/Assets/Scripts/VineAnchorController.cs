using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineAnchorController : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool attached = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Solids")
        {
            rb.bodyType = RigidbodyType2D.Static;
            attached = true;
        }
    }
    
}
