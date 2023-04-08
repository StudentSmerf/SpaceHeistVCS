using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    
    public GameObject PausePanel;
    public static Pause instance;
    void Awake(){
        instance = this;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            Activate();
        }
        if(Input.GetKeyUp(KeyCode.Tab)){
            Disactivate();
        }
    }
    public void Disactivate(){
        PausePanel.SetActive(false);
    }
    public void Activate(){
        PausePanel.SetActive(true);
    }
}
