using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class LobbyLauncher : MonoBehaviourPunCallbacks
{   public Canvas Loading;
    public Canvas Lobby;
    
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        Loading.enabled = true;
        Lobby.enabled = false;
        Cursor.visible = true;
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Loading.enabled = false;
        Lobby.enabled = true;
    }

}
