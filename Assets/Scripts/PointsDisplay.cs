using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class PointsDisplay : MonoBehaviour
{
    public TextMeshProUGUI PointsText;
    void Update()
    {
        if(PhotonNetwork.LocalPlayer.CustomProperties["Points"] != null){
            PointsText.text = ((int)PhotonNetwork.LocalPlayer.CustomProperties["Points"]).ToString();
        }
    }
}
