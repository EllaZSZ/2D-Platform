//wrought by ella
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineAnchorController : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool attached = false;
    public bool stoppedPlatform = false;
    public bool stoppedSpin = false;
    public GameObject platform;
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
        if (collision.gameObject.tag == "MovingPlatform")
        {
            rb.bodyType = RigidbodyType2D.Static;
            attached = true;
            platform = collision.gameObject;
            stoppedPlatform = true;
            platform.GetComponent<MovingPlatform>().moving = false;
        }
        if (collision.gameObject.tag == "SpinningPlatform")
        {
            rb.bodyType = RigidbodyType2D.Static;
            attached = true;
            platform = collision.gameObject;
            stoppedSpin = true;
            platform.GetComponent<Spin>().moving = false;
        }
    }
}
