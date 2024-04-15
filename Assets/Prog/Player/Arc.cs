using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arc : MonoBehaviour
{

    public PlayerController player;
    public bool ArcOn;

    void Update()
    {
        ArcOn = false;
        

        if (ArcOn == true)
        {



            if (Input.GetKeyDown("1"))
            {

                player.arcbool = true;

            }
        }

    }

}
