using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_EndZone : MonoBehaviour
{
    public string lastZone;

    void Start()
    {
        if(lastZone == GameManager.instance.previousZone)
        {
            PlayerController.instance.transform.position = transform.position;
        }
    }
}
