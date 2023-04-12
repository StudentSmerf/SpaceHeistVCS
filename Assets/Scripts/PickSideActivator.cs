using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSideActivator : MonoBehaviour
{
    public GameObject PickSidePanel;
    public GameObject SettingsPanel;
    public GameObject ReadyButton;
    public GameObject RespawnButton;
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
    public void SetButton(bool FirstStart){
        if(FirstStart){
            ReadyButton.SetActive(true);
            RespawnButton.SetActive(false);
        }
        else{
            ReadyButton.SetActive(false);
            RespawnButton.SetActive(true);
        }
    }
    void Update(){
        if(Input.GetKeyUp(KeyCode.Tab)){
            SettingsPanel.SetActive(false);
        }
    }

}
