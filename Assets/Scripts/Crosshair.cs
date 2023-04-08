using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public CanvasRenderer CRenderer;
    void Start()
    {
        StartCoroutine("DisableCursor");
    }
    IEnumerator DisableCursor(){
        yield return new WaitForSeconds(0.3f);
        Cursor.visible = false;
    }

    
    void Update()
    {
        transform.position = Input.mousePosition;

        if(Input.GetKeyDown(KeyCode.Escape)){
            CRenderer.SetAlpha(0f);
            Cursor.visible = true;
        }
        if(Input.GetKeyUp(KeyCode.Escape)){
            CRenderer.SetAlpha(255f);
            StartCoroutine("DisableCursor");      
        }
    }
}
