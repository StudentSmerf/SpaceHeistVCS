using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayersNumber : MonoBehaviour
{
    public Text text;
    void Update()
    {   
        if(PhotonNetwork.InRoom){
            text.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString();
        }
        
    }
    
    
}
