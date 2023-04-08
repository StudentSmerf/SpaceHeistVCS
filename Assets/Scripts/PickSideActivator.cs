using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSideActivator : MonoBehaviour
{
    public GameObject PickSidePanel;
    public GameObject SettingsPanel;
    public static PickSideActivator instance;
    
    void Start()
    {
        instance = this;
    }
    
    public void Activate(){
        PickSidePanel.SetActive(true);
    }
    public void Disactivate(){
        PickSidePanel.SetActive(false);
    }
    void Update(){
        if(Input.GetKeyUp(KeyCode.Tab)){
            SettingsPanel.SetActive(false);
        }
    }

}
