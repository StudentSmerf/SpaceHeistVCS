using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float RotationSpeed;
    public float speed;
    public Vector3 DirForward;
    public Vector3 DirUp;
    public Transform Front;
    public Transform Down;
    PhotonView view;

    

    public GameObject Eyes;

    void Start()
    {
        RotationSpeed = 100f;
        speed = 100f;
        view = GetComponent<PhotonView>();
        if(view.IsMine){
            Eyes.SetActive(false);
        }
        if(!view.IsMine){
            Destroy(rb);
            Destroy(this);
        }
    }




    void Update(){
        
            float _yRot = Input.GetAxisRaw("Mouse X");
            float _xRot = Input.GetAxisRaw("Mouse Y");

            //Vector3 _rotationX = new Vector3 (-_xRot, 0f, 0f);
            //Vector3 _rotationY = new Vector3 (0f, _yRot, 0f);

        
            //Find Directions:
            DirForward = Front.position - this.transform.position;
            DirUp = this.transform.position - Down.position;
        
            //Movement on input:
            if(Input.GetKey("space")){
                rb.AddForce(DirForward * speed * Time.deltaTime, ForceMode.Force);
            }
            // if(Input.GetKey(KeyCode.LeftShift)){
            //     rb.AddForce(DirUp * speed * Time.deltaTime, ForceMode.Force);
            // }
            if(Input.GetKey(KeyCode.LeftControl)){
                rb.AddForce(-DirUp * speed * Time.deltaTime, ForceMode.Force);
            }

            //StopNotWantedMovement:
            rb.angularVelocity = Vector3.zero;
        
            

            //Rotation Movement:
            if(Input.GetKey("e")){
                this.transform.Rotate(0, 0, -RotationSpeed * Time.deltaTime, Space.Self);
            }
            if(Input.GetKey("q")){
                this.transform.Rotate(0, 0, RotationSpeed * Time.deltaTime, Space.Self);
            }

            //Rotation based on mouse movement:
            if(!Input.GetKey(KeyCode.LeftShift)){
                this.transform.Rotate(-_xRot ,0, 0, Space.Self);
                this.transform.Rotate(0,_yRot, 0, Space.Self);
            }

            //Old rotation system:
            
            if(Input.GetKey("a")){
                this.transform.Rotate(0, -RotationSpeed * Time.deltaTime, 0, Space.Self);
            }
            if(Input.GetKey("d")){
                this.transform.Rotate(0, RotationSpeed * Time.deltaTime, 0, Space.Self);
            }
            if(Input.GetKey("w")){
                this.transform.Rotate(RotationSpeed * Time.deltaTime, 0, 0, Space.Self);
            }
            if(Input.GetKey("s")){
                this.transform.Rotate(-RotationSpeed * Time.deltaTime, 0, 0, Space.Self);
            }
            
        
    }

    
}
