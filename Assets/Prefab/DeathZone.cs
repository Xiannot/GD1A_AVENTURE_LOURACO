using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public string nextZone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag ("Player"))
        {
            SceneManager.LoadScene(nextZone);
            
        }
    }
}