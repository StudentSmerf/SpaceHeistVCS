using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AmmoDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    public static AmmoDisplay instance;
    void Start()
    {
        instance = this;
    }

    public void ChangeText(int AmmoText){
        text.text = AmmoText.ToString();
    }
    
}
