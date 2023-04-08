using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class KDmanager : MonoBehaviour
{
    PhotonView view;
    //public string K;
    //public string D;
    public GameObject textObj;
    void Start(){
        view = GetComponent<PhotonView>();
    }

    public void RegisterKill(string Killer, string Killed){
        //K = Killer;
        //D = Killed;
        view.RPC("ShowMessage", RpcTarget.All, Killer, Killed);

        for (int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; i++){
            if(Killer == PhotonNetwork.PlayerList[i].NickName){
                for (int j = 0; j < PhotonNetwork.CurrentRoom.PlayerCount; j++){
                    if(Killed == PhotonNetwork.PlayerList[j].NickName){
                        if((string)PhotonNetwork.PlayerList[i].CustomProperties["Side"] != (string)PhotonNetwork.PlayerList[j].CustomProperties["Side"]){
                            if((string)PhotonNetwork.PlayerList[i].CustomProperties["Side"] == "Smugglers"){
                                Hashtable propertyChanges2 = new Hashtable(); 
		                        propertyChanges2["Kills"] = 1 + (int)PhotonNetwork.PlayerList[i].CustomProperties["Kills"];
                                propertyChanges2["SavedPoints"] = 1 + (int)PhotonNetwork.PlayerList[i].CustomProperties["SavedPoints"];
		                        PhotonNetwork.PlayerList[i].SetCustomProperties(propertyChanges2);
                            }
                            if((string)PhotonNetwork.PlayerList[i].CustomProperties["Side"] == "Transporters"){
                                Hashtable propertyChanges2 = new Hashtable(); 
		                        propertyChanges2["Kills"] = 1 + (int)PhotonNetwork.PlayerList[i].CustomProperties["Kills"];
                                propertyChanges2["SavedPoints"] = 5 + (int)PhotonNetwork.PlayerList[i].CustomProperties["SavedPoints"];
		                        PhotonNetwork.PlayerList[i].SetCustomProperties(propertyChanges2);
                            }
                        }
                    }
                }
                
            }
        }
    }
    [PunRPC]
    void ShowMessage(string K, string D){
        GameObject KDtextOBJ = Instantiate(textObj, this.transform.position, Quaternion.identity);
        KDtextOBJ.GetComponent<Text>().text = K + "    |;==     " + D;
        KDtextOBJ.transform.SetParent(this.gameObject.transform, false);
    }
}
