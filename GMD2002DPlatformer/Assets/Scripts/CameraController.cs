//ella writ this
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private int offset;
    float y;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        y += (player.transform.position.y - y) / speed * Time.deltaTime;
        transform.position = new Vector3(0, y + offset, -10);
    }
}
