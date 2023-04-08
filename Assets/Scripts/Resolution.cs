using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Resolution : MonoBehaviour
{
    
    public TMP_Dropdown dropdown;
    private int value;
    public void OnValueChanged(){
        value = dropdown.value;
        if(value == 0){
            Screen.SetResolution(1920,1080, Screen.fullScreen);
        }
        if(value == 1){
            Screen.SetResolution(3840,2160, Screen.fullScreen);
        }
        if(value == 2){
            Screen.SetResolution(1440,2560, Screen.fullScreen);
        }
    }
}
