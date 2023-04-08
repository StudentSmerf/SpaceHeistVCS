using UnityEngine;
using Photon.Pun;

public class Quit : MonoBehaviourPunCallbacks
{
    public void OnClick(){
        LeaveRoom();
    }
    public void LeaveRoom(){
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("LobbyScene");
    }
}
