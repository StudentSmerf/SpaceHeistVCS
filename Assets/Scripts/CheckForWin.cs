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
    private bool canCheck;

    void Start(){
        view = GetComponent<PhotonView>();
        instance = this;
        canCheck = true;
        StartCoroutine("CheckC");
    }
    IEnumerator CheckC(){
        while(true){
            yield return new WaitForSeconds(1);
            Check();
        }
    }


    public void Check(){
        
        
            
            
            for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++){
                
                if((int)PhotonNetwork.PlayerList[i].CustomProperties["SavedPoints"] >= 15){
                    
                    
                    if((string)PhotonNetwork.PlayerList[i].CustomProperties["Side"] == "Smugglers"){
                        if(canCheck){
                            canCheck = false;
                            view.RPC("SmugglersWin", RpcTarget.All);
                            SWins++;
                            PointsSText.text = SWins.ToString();
                            
                        }
                        
                    }
                    if((string)PhotonNetwork.PlayerList[i].CustomProperties["Side"] == "Transporters"){
                        if(canCheck){
                            canCheck = false;
                            view.RPC("TransportersWin", RpcTarget.All);
                            TWins++;
                            PointsTText.text = TWins.ToString();
                        }
                        
                    }
                }      
            }
            canCheck = true;
        
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
            PhotonNetwork.PlayerList[i].SetCustomProperties(propertyChanges);
        }
        
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
            PhotonNetwork.PlayerList[i].SetCustomProperties(propertyChanges);
        }
        
    }
}
