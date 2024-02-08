using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    Vector3 vineDir = Vector3.zero;
    bool vineOut = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A)) {
            rb.AddForce(new Vector3(-speed, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(speed, 0, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            //rb.AddForce(new Vector3(0, speed, 0));
        }
        if (Input.GetMouseButton(0))
        {
            if (!vineOut)
            {
                vineDir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                vineDir.z = transform.position.z;
                vineDir = vineDir - transform.position;
                vineDir.Normalize();
                vineOut = true;
                transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(vineDir.x, vineDir.y));
                //add vine shoot
            }
        } else
        {
            vineOut = false;
        }
    }
}
