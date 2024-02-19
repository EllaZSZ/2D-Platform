using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    [SerializeField] private float speed; 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, transform.position.y + (player.transform.position.y - transform.position.y)/speed*Time.deltaTime, -10);
    }
}
