using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class PlayerNum : MonoBehaviour
{
    public int NumberOfPlayer;
    public int Number;
    PhotonView view;
    
    void Start()
    {
        view = GetComponent<PhotonView>();
        if(view.IsMine){
            Number = PhotonNetwork.CountOfPlayers;
            view.RPC("SetNumber", RpcTarget.AllBuffered, Number);
        }
        
    }

    [PunRPC]
    void SetNumber(int num){
        NumberOfPlayer = num;
        Debug.Log(num);
    }
}
