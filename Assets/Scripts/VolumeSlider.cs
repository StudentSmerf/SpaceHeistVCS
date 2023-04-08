using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider slider;
    public void VolumeChanged(){
        PlayerPrefs.SetFloat("volume", slider.value);
    }
}
