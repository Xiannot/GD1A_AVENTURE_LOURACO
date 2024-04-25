using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot: MonoBehaviour
{

    public Animator anim;

    public float speed = 3f;
    private Transform target;
    private Vector3 orientation;

    public float shootingRange;
    public GameObject bullet;
    public GameObject bulletParent;
    public float fireRate = 1f;
    private float nextFireTime;



    void Start()
    {
        anim = GetComponent<Animator>();
    }



    private void Update()
    {
        if (target != null && nextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
            anim.Play("PierreOpenG");
            
            

        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            target = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;
        }
    }
}
