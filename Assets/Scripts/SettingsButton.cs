using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public GameObject SettingsPanel;
    public void OnClick(){
        SettingsPanel.SetActive(true);
        Pause.instance.Disactivate();
    }
}
