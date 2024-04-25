using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject target;
    public float speed;
    public float time;
    Rigidbody2D BouleDeFeu;

    void Start()
    {
        BouleDeFeu = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        BouleDeFeu.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, time);
    }
}
