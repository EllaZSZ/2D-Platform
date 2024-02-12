//written by: Ella Speer
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private GameObject vine;
    private float vineLength = 0.25f;
    private Vector3 vineEnd;
    private bool vineEndFound = false;
    private Vector3 vineDir = Vector3.zero;
    private bool vineOut = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vine = transform.GetChild(0).gameObject;
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
        
        if (Input.GetMouseButton(0))
        {
            if (!vineOut)
            {
                vineEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                vineEnd.z = transform.position.z;
                vineOut = true;
            }
            vineDir = vineEnd - transform.position;
            vineDir.Normalize();
            vine.transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(vineDir.y, vineDir.x) + 90);
            if (Input.GetMouseButton(1) && vineEndFound)
            {
                rb.AddForce(vineDir * 2 * speed);
            }
        }
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!vineEndFound)
            {
                if (vineLength < 4.25f && !vine.GetComponent<BoxCollider2D>().IsTouchingLayers(3))
                {
                    vineLength += 0.01f;
                    vine.transform.position = transform.position + vineDir * vineLength;
                    vine.transform.localScale = new Vector3(0.25f, vineLength, 1);
                }
                else
                {
                    vineEnd = transform.position + vineDir * vineLength;
                    vineEndFound = true;
                }
            }
        } else
        {
            vineOut = false;
            vineEndFound = false;
            if (vineLength > 0.25f)
            {
                vineLength -= 0.05f;
                vine.transform.position = transform.position + vineDir * vineLength;
                vine.transform.localScale = new Vector3(0.25f, vineLength, 1);
            } else
            {
                vine.transform.localScale = new Vector3(0.25f, 0.25f, 1);
            }
        }
    }
}
