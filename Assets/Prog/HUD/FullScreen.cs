using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public void FullScreentoggle(bool is_fullscene)
           {
                Screen.fullScreen = is_fullscene;
                Screen.fullScreen = !Screen.fullScreen;
           }
}
