using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PickSide : MonoBehaviour
{
    
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
        
    }
    void Start(){
        instance = this;
    }
    
    
    public void Ready(){
        Hashtable propertyChanges = new Hashtable(); 
		propertyChanges["Ready"] = 1;
		PhotonNetwork.LocalPlayer.SetCustomProperties(propertyChanges);
        
        RSel.SetActive(true);
        NManager.instance.SpawnStart();
        
    }
    
        
    


}
