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
    public bool CanRestart;
    void Awake()
    {
        CanRestart = true;
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
        Hashtable propertyChanges = new Hashtable(); 
        propertyChanges["Ready"] = 0;
        PhotonNetwork.LocalPlayer.SetCustomProperties(propertyChanges);
        PlayerGO.transform.position = spawnStart[Random.Range(0, spawnStart.Length)].transform.position;
        if(CanRestart){
            StartCoroutine("Respawn");
        }
    }
    IEnumerator Respawn(){
        yield return new WaitForSeconds(3);
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
    }
    public void SpawnT(){
        AmmoCount.instance.ChangeAmmo(5);
        PlayerGO.transform.position = spawnpointsT[Random.Range(0, spawnpointsT.Length)].transform.position;
    }

    public void Restart(){
        PlayerGO.transform.position = spawnStart[Random.Range(0, spawnStart.Length)].transform.position;
        CanRestart = false;
        StartCoroutine("CanRestartC");
    }
    IEnumerator CanRestartC(){
        yield return new WaitForSeconds(6);
        CanRestart = true;
    }
}
