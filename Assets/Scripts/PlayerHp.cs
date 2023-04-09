using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class PlayerHp : MonoBehaviour
{
    PhotonView view;
    public int Hp;
    public string LastHitPlayer;
    public string LastHitPlayerName;
    public GameObject KDsystem;
    public static PlayerHp instance;
    void Start(){
        Hp = 1;
        instance = this;
        view = GetComponent<PhotonView>();
        KDsystem = GameObject.Find("KDsystem");
    }
    public void TakeDamage(string Name){
        LastHitPlayer = Name;
        view.RPC("RPC_TakeDamage", RpcTarget.All, LastHitPlayer);
    }
    [PunRPC]
    public void RPC_TakeDamage(string PName){
        if(view.IsMine){
            LastHitPlayerName = PName;
            Hp--;
            Debug.Log(Hp);
        }
    }
    

    void Update(){
        if(view.IsMine){
            if(Hp == 0){
                KDsystem.GetComponent<KDmanager>().RegisterKill(LastHitPlayerName, PhotonNetwork.LocalPlayer.NickName);
                Hashtable propertyChanges = new Hashtable(); 
		        propertyChanges["Deaths"] = 1 + (int)PhotonNetwork.LocalPlayer.CustomProperties["Deaths"];
		        PhotonNetwork.LocalPlayer.SetCustomProperties(propertyChanges);
                
                NManager.instance.SpawnStart();
                //PickSideActivator.instance.Activate();
                Hp = 1;
            }
        }
    }
}
