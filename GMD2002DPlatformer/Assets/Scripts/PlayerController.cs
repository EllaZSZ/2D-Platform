//written by: Ella Speer
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    [SerializeField] private GameObject vinePrefab;
    [SerializeField] private float horizontalDrag;
    private GameObject vine;
    private GameObject vineAnchor;
    private Vector3 vineDir = Vector3.zero;
    private Vector3 vineEnd = Vector3.zero;
    private bool vineOut = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A)) {
            rb.AddForce(new Vector3(-speed*rb.mass, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(speed*rb.mass, 0, 0));
        }

        if (Input.GetMouseButton(0))
        {
            if (vineOut) {

            } else {
                vineEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                vineEnd.z = transform.position.z;
                vineOut = true;
                vineDir = vineEnd - transform.position;
                vineDir.Normalize();
                vine = Instantiate(vinePrefab, transform.position + new Vector3(0, 1, 0), Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(vineDir.y, vineDir.x) * Mathf.Rad2Deg)) );//, transform);
                vine.transform.GetChild(6).GetComponent<HingeJoint2D>().connectedBody = rb;
                vineAnchor = vine.transform.GetChild(0).gameObject;
                vineAnchor.GetComponent<Rigidbody2D>().AddForce(vineDir * 2000);
            }
            if (Input.GetMouseButton(1) && vineAnchor.GetComponent<VineAnchorController>().attached)
            {
                Vector3 vel = vineAnchor.transform.position - transform.position;
                vel.Normalize();
                rb.AddForce(vel * 2 * speed * rb.mass);
            }
        } else
        {
            vineOut = false;
            Destroy(vine);
        }
        rb.totalForce = new Vector2(rb.totalForce.x * horizontalDrag, rb.totalForce.y);
    }


    // Written by Arija for Moving Platforms
    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("MovingPlatform"))
    //    {
    //        transform.SetParent(other.transform, true);
    //    }
    //}
    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("MovingPlatform"))
    //    {
    //        transform.SetParent(null, true);
    //    }
    //}
}
