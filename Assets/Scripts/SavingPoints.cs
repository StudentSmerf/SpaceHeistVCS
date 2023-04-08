using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingPoints : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider){
        if(collider.tag == "Player"){
            collider.gameObject.GetComponent<PlayerPoints>().StartCoroutine("SavePointsS");
        }
    }
    public void OnTriggerExit(Collider collider){
        if(collider.tag == "Player"){
            collider.gameObject.GetComponent<PlayerPoints>().StopCoroutine("SavePointsS");
        }
    }
}
