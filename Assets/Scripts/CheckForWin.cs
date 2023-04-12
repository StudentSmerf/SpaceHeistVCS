using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using TMPro;
using Photon.Realtime;


public class CheckForWin : MonoBehaviour
{
    
    private int SWins;
    private int TWins;
    PhotonView view;
    public TextMeshProUGUI PointsSText;
    public TextMeshProUGUI PointsTText;
    public static CheckForWin instance;
    void Start(){
        view = GetComponent<PhotonView>();
        instance = this;
    }


    public void Check(){
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++){
            if((int)PhotonNetwork.PlayerList[i].CustomProperties["SavedPoints"] >= 15){
                if((string)PhotonNetwork.PlayerList[i].CustomProperties["Side"] == "Smugglers"){
                    view.RPC("SmugglersWin", RpcTarget.All);
                }
                if((string)PhotonNetwork.PlayerList[i].CustomProperties["Side"] == "Transporters"){
                    view.RPC("TransportersWin", RpcTarget.All);
                }
            }      
        }
    }
    
    [PunRPC]
    public void SmugglersWin(){
        NManager.instance.SpawnStart();
        PickSide.instance.Reset();
        PickSideActivator.instance.Activate();
        PickSideActivator.instance.SetButton(true);
        for (int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; i++){
            Hashtable propertyChanges = new Hashtable(); 
            propertyChanges["Points"] = 0;
            propertyChanges["SavedPoints"] = 0;
            propertyChanges["Ready"] = 0;
            propertyChanges["Kills"] = 0;
            propertyChanges["Deaths"] = 0;
            PhotonNetwork.PlayerList[i].SetCustomProperties(propertyChanges);
        }
        SWins++;
        PointsSText.text = SWins.ToString();
    }
    [PunRPC]
    public void TransportersWin(){
        NManager.instance.SpawnStart();
        PickSide.instance.Reset();
        PickSideActivator.instance.Activate();
        PickSideActivator.instance.SetButton(true);

        for (int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; i++){
            Hashtable propertyChanges = new Hashtable(); 
            propertyChanges["Points"] = 0;
            propertyChanges["SavedPoints"] = 0;
            propertyChanges["Ready"] = 0;
            propertyChanges["Kills"] = 0;
            propertyChanges["Deaths"] = 0;
            PhotonNetwork.PlayerList[i].SetCustomProperties(propertyChanges);
        }
        TWins++;
        PointsTText.text = TWins.ToString();
    }
}
