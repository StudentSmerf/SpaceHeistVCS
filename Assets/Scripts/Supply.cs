using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supply : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider){
        if(collider.tag == "Player"){
            collider.gameObject.GetComponent<PlayerPoints>().StartCoroutine("AddPointsS");
        }
    }
    public void OnTriggerExit(Collider collider){
        if(collider.tag == "Player"){
            collider.gameObject.GetComponent<PlayerPoints>().StopCoroutine("AddPointsS");
        }
    }
}
