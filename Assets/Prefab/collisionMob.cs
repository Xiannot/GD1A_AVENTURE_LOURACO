using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionMob : MonoBehaviour
{


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag ("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(25);
        }
    }
}