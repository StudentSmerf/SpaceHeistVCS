using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PlayerPoints : MonoBehaviour
{
    public int Points;
    public int SavedPoints;
    /*
    void Start(){
        StartCoroutine("CheckPoints");
    }
    IEnumerator CheckPoints(){
        
        while(true){
            Hashtable propertyChanges = new Hashtable(); 
            propertyChanges["Points"] = Points;
		    PhotonNetwork.LocalPlayer.SetCustomProperties(propertyChanges);
            //Scoreboard.instance.GetScores();
            Debug.Log("Check");
            yield return new WaitForSeconds(5);
        }
        
		
    }
    */
    IEnumerator AddPointsS(){
        if((string)PhotonNetwork.LocalPlayer.CustomProperties["Side"] == "Smugglers"){
            while((int)PhotonNetwork.LocalPlayer.CustomProperties["Points"] < 9){
                
                yield return new WaitForSeconds(1);
                //Points++;
                Hashtable propertyChanges = new Hashtable(); 
		        propertyChanges["Points"] =  1 + (int)PhotonNetwork.LocalPlayer.CustomProperties["Points"];
		        PhotonNetwork.LocalPlayer.SetCustomProperties(propertyChanges);
                //Scoreboard.instance.GetScores();
            }

        }
        yield return new WaitForSeconds(0);
    }

    IEnumerator SavePointsS(){
        if((string)PhotonNetwork.LocalPlayer.CustomProperties["Side"] == "Smugglers"){
            while((int)PhotonNetwork.LocalPlayer.CustomProperties["Points"] > 1){
                
                yield return new WaitForSeconds(1);
                //Points--;
                //SavedPoints++;
                Hashtable propertyChanges = new Hashtable(); 
		        propertyChanges["Points"] = (int)PhotonNetwork.LocalPlayer.CustomProperties["Points"] - 1;
                propertyChanges["SavedPoints"] = 1 + (int)PhotonNetwork.LocalPlayer.CustomProperties["SavedPoints"];
		        PhotonNetwork.LocalPlayer.SetCustomProperties(propertyChanges);
                //Scoreboard.instance.GetScores();
            }
        }
        yield return new WaitForSeconds(0);
    }

}
