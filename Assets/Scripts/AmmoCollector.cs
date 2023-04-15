using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AmmoCollector : MonoBehaviour
{
    PhotonView view;
    void Start(){
        view = GetComponent<PhotonView>();
        if(!view.IsMine){
            Destroy(this);
        }
    }

    void OnCollisionEnter(Collision collision){
        AmmoCount.instance.AddAmmo(3);
        PhotonNetwork.Destroy(this.gameObject);
    }
}
