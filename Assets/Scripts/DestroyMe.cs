using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DestroyMeNow");
    }

    IEnumerator DestroyMeNow(){
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
