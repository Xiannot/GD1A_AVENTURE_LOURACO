using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionPlayer : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag ("Ennemi"))
        {
            EnnemiHeal ennemiHeal = collision.transform.GetComponent<EnnemiHeal>();
            ennemiHeal.TakeDamage(25);
        }
    }
}