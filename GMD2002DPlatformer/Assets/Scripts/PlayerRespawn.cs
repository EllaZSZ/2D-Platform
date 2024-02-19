// Programmed By Arija

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform respawn;
    [SerializeField] DeathDisplay DeathDisplayScript;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hazards"))
        {
            //Respawn
            DeathDisplayScript.AddDeath();
            transform.position = respawn.transform.position;
        }
        else if (other.gameObject.CompareTag("Checkpoints"))
        {
            respawn = other.transform;
        }
    }
}
