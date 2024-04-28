using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  //  public GameObject[] objects;
    public static GameManager instance;

    [HideInInspector]
    public string previousZone;

    private void Awake()
    {

     //   foreach (var element in objects)
       // {
      //      DontDestroyOnLoad(element);
     //   }

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }


    }
}
