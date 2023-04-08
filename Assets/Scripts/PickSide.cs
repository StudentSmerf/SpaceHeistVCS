using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PickSide : MonoBehaviour
{
    private int PlayersReady = 0;
    public GameObject TSel;
    public GameObject SSel;
    public GameObject RSel;
    public static PickSide instance;

    public void Transporters(){
        Hashtable propertyChanges = new Hashtable(); 
		propertyChanges["Side"] = "Transporters";
		PhotonNetwork.LocalPlayer.SetCustomProperties(propertyChanges);
        Scoreboard.instance.GetScores();
        TSel.SetActive(true);
        SSel.SetActive(false);
    }
    public void Smugglers(){
        Hashtable propertyChanges = new Hashtable(); 
		propertyChanges["Side"] = "Smugglers";
		PhotonNetwork.LocalPlayer.SetCustomProperties(propertyChanges);
        Scoreboard.instance.GetScores();
        TSel.SetActive(false);
        SSel.SetActive(true);
    }
    public void Reset(){
        Hashtable propertyChanges = new Hashtable(); 
		propertyChanges["Ready"] = 0;
		PhotonNetwork.LocalPlayer.SetCustomProperties(propertyChanges);
        TSel.SetActive(false);
        SSel.SetActive(false);
        RSel.SetActive(false);
        StartCoroutine("CheckIfEveryoneIsReady");
    }
    void Start(){
        
        //StartCoroutine("CheckIfEveryoneIsReady");
        instance = this;
        
    }
    
    IEnumerator CheckIfEveryoneIsReady(){
        while(true){
            if(PhotonNetwork.LocalPlayer.CustomProperties["Ready"]!=null){
                if(PhotonNetwork.LocalPlayer.CustomProperties["Side"]!=null){
                if((int)PhotonNetwork.LocalPlayer.CustomProperties["Ready"] == 1){
                    PlayersReady = 0;
                    Debug.Log("ilosc graczy " + PhotonNetwork.PlayerList.Length);
                    for (int i = 0 ;i < PhotonNetwork.PlayerList.Length; i++){
                        if((int)PhotonNetwork.PlayerList[i].CustomProperties["Ready"] == 1){
                            PlayersReady++;
                        }
            
                    }
                    Debug.Log("gracze gotowi " + PlayersReady);
                    if(PlayersReady == PhotonNetwork.PlayerList.Length){
                        Spawn();
                        StopCoroutine("CheckIfEveryoneIsReady");
                    }
                }
                }
            }
            yield return new WaitForSeconds(2);
        }
    }
    public void Ready(){
        Hashtable propertyChanges = new Hashtable(); 
		propertyChanges["Ready"] = 1;
		PhotonNetwork.LocalPlayer.SetCustomProperties(propertyChanges);
        
        RSel.SetActive(true);
        StartCoroutine("CheckIfEveryoneIsReady");
    }
    private void Spawn(){
        if((string)PhotonNetwork.LocalPlayer.CustomProperties["Side"] == "Smugglers"){
            NManager.instance.SpawnS();
        }
        if((string)PhotonNetwork.LocalPlayer.CustomProperties["Side"] == "Transporters"){
            NManager.instance.SpawnT();
        }
        //this.gameObject.SetActive(false);
        PickSideActivator.instance.Disactivate();
    }


}
