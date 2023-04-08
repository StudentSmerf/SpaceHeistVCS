using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;


public class NManager : MonoBehaviour
{

    public SpawnPointsT[] spawnpointsT;
    public SpawnPointsS[] spawnpointsS;
    public SpawnStart[] spawnStart;
    public GameObject PlayerGO;
    public static NManager instance;
    private int PlayersReady = 0;
    
    void Awake()
    {
        
        instance = this;
        Hashtable propertyChanges = new Hashtable(); 
		propertyChanges["Deaths"] = 0;
        propertyChanges["Kills"] = 0;
        propertyChanges["SavedPoints"] = 0;
        propertyChanges["Points"] = 0;
        propertyChanges["Ready"] = 0;
        //AmmoCount.instance.ChangeAmmo(5);
		PhotonNetwork.LocalPlayer.SetCustomProperties(propertyChanges);
        GameObject Player = PhotonNetwork.Instantiate("Player", spawnStart[Random.Range(0, spawnStart.Length)].transform.position, Quaternion.identity);
        PlayerGO = Player;
    }
    //spawnpoints[Random.Range(0, spawnpoints.Length)].transform.position
    public void SpawnStart(){
        // Hashtable propertyChanges = new Hashtable(); 
        // propertyChanges["Ready"] = 0;
        // PhotonNetwork.LocalPlayer.SetCustomProperties(propertyChanges);
        PlayerGO.transform.position = spawnStart[Random.Range(0, spawnStart.Length)].transform.position;
        StartCoroutine("CheckIfReady");
    }
    IEnumerator CheckIfReady(){
        while(true){
            if(PhotonNetwork.LocalPlayer.CustomProperties["Ready"]!=null){
                if((int)PhotonNetwork.LocalPlayer.CustomProperties["Ready"] == 1){
                    StartCoroutine("CheckIfEveryoneIsReady");
                    StopCoroutine("CheckIfReady");
                }
            }
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator CheckIfEveryoneIsReady(){
        //TODO display waiting for players
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
                            StartCoroutine("Respawn");
                            StopCoroutine("CheckIfEveryoneIsReady");
                        }
                    }
                }
            }
            yield return new WaitForSeconds(2);
        }
    }
    IEnumerator Respawn(){
        yield return new WaitForSeconds(1);
        if((string)PhotonNetwork.LocalPlayer.CustomProperties["Side"] == "Smugglers"){
            Hashtable propertyChanges = new Hashtable(); 
            propertyChanges["Ready"] = 0;
            PhotonNetwork.LocalPlayer.SetCustomProperties(propertyChanges);
            SpawnS();
        }
        else if((string)PhotonNetwork.LocalPlayer.CustomProperties["Side"] == "Transporters"){
            Hashtable propertyChanges = new Hashtable(); 
            propertyChanges["Ready"] = 0;
            PhotonNetwork.LocalPlayer.SetCustomProperties(propertyChanges);
            SpawnT();
        }
        else {
            Debug.Log("Not Spawning");
        }
    }
    public void SpawnS(){
        AmmoCount.instance.ChangeAmmo(5);
        PlayerGO.transform.position = spawnpointsS[Random.Range(0, spawnpointsS.Length)].transform.position;
        PickSideActivator.instance.Disactivate();
    }
    public void SpawnT(){
        AmmoCount.instance.ChangeAmmo(5);
        PlayerGO.transform.position = spawnpointsT[Random.Range(0, spawnpointsT.Length)].transform.position;
        PickSideActivator.instance.Disactivate();
    }

    

}
