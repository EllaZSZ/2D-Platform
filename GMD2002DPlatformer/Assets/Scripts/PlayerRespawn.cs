// Programmed By Arija

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform respawn;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hazards"))
        {
            //Respawn
            transform.position = respawn.transform.position;
        }
        else if (other.gameObject.CompareTag("Checkpoints"))
        {
            respawn = other.transform;
        }
    }
}
