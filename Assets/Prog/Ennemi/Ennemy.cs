using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public float speed = 3f;
    private Transform target;
    public Animator animator;
    private Vector3 orientation;




    private void Update()
    {
        if(target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);

            orientation = target.position - transform.position ;


            animator.SetFloat("Horizontal", orientation.x);
            animator.SetFloat("Vertical", orientation.y);
            animator.SetFloat("Magnitude", orientation.magnitude);
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
