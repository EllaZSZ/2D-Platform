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
    private GameObject vineAnchor;
    private Vector3 vineDir = Vector3.zero;
    private Vector3 vineEnd = Vector3.zero;
    private bool vineOut = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vine = GameObject.Find("Vine");
        vineAnchor = GameObject.Find("Anchor");
        vine.SetActive(false);
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
                vine.SetActive(true);
                vineDir = vineEnd - transform.position;
                vineDir.Normalize();
                vine.transform.position = new Vector3(0, 1, 0);
                vineAnchor.transform.position = new Vector3(0, 1, 0);
                vineAnchor.GetComponent<Rigidbody2D>().AddForce(vineDir * 3 * speed);
            }
            if (Input.GetMouseButton(1))
            {
                Vector3 vel = vineAnchor.transform.position - transform.position;
                vel.Normalize();
                rb.AddForce(vel * 2 * speed);
            }
        } else
        {
            vineOut = false;
            vine.SetActive(false);
        }
    }
    private void Update()
    {
        
    }
}
