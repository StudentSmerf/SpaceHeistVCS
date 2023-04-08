using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    
    public TMP_InputField createInput;
    public TMP_InputField joinInput;
    public TMP_InputField nickName;

    public void CreateRoom(){
        PhotonNetwork.LocalPlayer.NickName = nickName.text;
        if(nickName.text != ""){
            PhotonNetwork.CreateRoom(createInput.text);
        }
    }

    public void JoinRoom(){
        PhotonNetwork.LocalPlayer.NickName = nickName.text;
        if(nickName.text != ""){
            PhotonNetwork.JoinRoom(joinInput.text);
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("SampleScene");
    }

    
}
