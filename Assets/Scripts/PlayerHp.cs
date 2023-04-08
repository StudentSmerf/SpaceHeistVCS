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
    [SerializeField] private ParticleSystem BoostParticleSystem;
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
    public void ShowBoost(){
        view.RPC("Boost", RpcTarget.All);
    }
    [PunRPC]
    void Boost(){
        BoostParticleSystem.Play(false);
        StartCoroutine("DestroyBoost");
    }

    IEnumerator DestroyBoost(){
        yield return new WaitForSeconds(0.2f);
        BoostParticleSystem.Stop();
    }

    void Update(){
        int canSpawn = 0;
        if(view.IsMine){
            if(Input.GetKey("space")){
                ShowBoost();
            }
            if(Hp == 0){
                KDsystem.GetComponent<KDmanager>().RegisterKill(LastHitPlayerName, PhotonNetwork.LocalPlayer.NickName);
                Hashtable propertyChanges = new Hashtable(); 
		        propertyChanges["Deaths"] = 1 + (int)PhotonNetwork.LocalPlayer.CustomProperties["Deaths"];
		        PhotonNetwork.LocalPlayer.SetCustomProperties(propertyChanges);
                for (int j = 0; j < PhotonNetwork.CurrentRoom.PlayerCount; j++){
                    if((int)PhotonNetwork.PlayerList[j].CustomProperties["SavedPoints"]>=15){
                        canSpawn++; 
                    }
                }
                if(canSpawn <1){
                    NManager.instance.SpawnStart();
                }
                Hp = 1;
            }
        }
    }
}
