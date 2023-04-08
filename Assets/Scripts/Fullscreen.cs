using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fullscreen : MonoBehaviour
{
    public Toggle toggle;
    public void Changed(){
        Screen.fullScreen = toggle.isOn;
    }
}
