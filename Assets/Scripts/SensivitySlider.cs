using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SensivitySlider : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI text;
    public void SensivityChanged(){
        PlayerController.instance.SetSensivity(slider.value);
        text.text = "Sensivity: " + slider.value;
    }
}
