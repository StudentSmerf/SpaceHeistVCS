using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AmmoCount : MonoBehaviour
{
    private int Ammo;
    public static AmmoCount instance;
    public Vector3 AmmoPosition;
    PhotonView view;
    void Start(){
        instance = this;
        view = GetComponent<PhotonView>();
        if(!view.IsMine){
            Destroy(this);
        }
        AmmoPosition = new Vector3(-3, 3,-15);
        Debug.Log("SpawnAmmo");
        PhotonNetwork.Instantiate("AmmoCollector", AmmoPosition, Quaternion.identity);
    }

    public bool CanUseAmmo(){
        if(Ammo > 0){
            Ammo--;
            UpdateAmmoCount();
            return true;
        }
        else{
            return false;
        }
        
    }
    public void ChangeAmmo(int AmmoToChange){
        Ammo = AmmoToChange;
        UpdateAmmoCount();
    }
    public void AddAmmo(int AmmoToAdd){
        Ammo += AmmoToAdd;
        UpdateAmmoCount();
    }
    private void UpdateAmmoCount(){
        AmmoDisplay.instance.ChangeText(Ammo);
    }
}
