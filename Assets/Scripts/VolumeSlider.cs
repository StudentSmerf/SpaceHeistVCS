using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeSlider : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI text;
    public void VolumeChanged(){
        PlayerPrefs.SetFloat("volume", slider.value);
        text.text = "Volume: " + slider.value;
    }
}
