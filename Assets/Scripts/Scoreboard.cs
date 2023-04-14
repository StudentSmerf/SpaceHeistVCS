using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class Scoreboard : MonoBehaviourPunCallbacks
{
    public static Scoreboard instance;
    public GameObject score;
    public GameObject scoreParent;
    object sideStr;
    void Start()
    {
        instance = this;
    }
    public void GetScores(){

        for (int i = 0; i < scoreParent.transform.childCount; i++)
        {
            if(scoreParent.transform.GetChild(i).gameObject.tag != "DontDestroy"){
                Destroy(scoreParent.transform.GetChild(i).gameObject);
            }
            
        }
        
        

        for (int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; i++)
        {
            GameObject ScoreObj = Instantiate(score, scoreParent.transform.position, Quaternion.identity);
            ScoreObj.transform.SetParent(scoreParent.transform);
            ScoreObj.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 100);
            ScoreObj.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            ScoreObj.GetComponent<Scores>().numberText.text = i.ToString();
            ScoreObj.GetComponent<Scores>().PlayerNameText.text = PhotonNetwork.PlayerList[i].NickName;
            //The working way to read CustomProperties
            ScoreObj.GetComponent<Scores>().SideText.text = (string)PhotonNetwork.PlayerList[i].CustomProperties["Side"];
            ScoreObj.GetComponent<Scores>().KillsText.text = ((int)PhotonNetwork.PlayerList[i].CustomProperties["Kills"]).ToString();
            ScoreObj.GetComponent<Scores>().DeathsText.text = ((int)PhotonNetwork.PlayerList[i].CustomProperties["Deaths"]).ToString();
            ScoreObj.GetComponent<Scores>().PointsText.text = ((int)PhotonNetwork.PlayerList[i].CustomProperties["SavedPoints"]).ToString();
        }

        
    }
    //The working way to update scores -> tell the script to check for new entries
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable hash){
        GetScores();
        Debug.Log("PropertiesChanged");
        //CheckForWin.instance.Check();
    }
}
