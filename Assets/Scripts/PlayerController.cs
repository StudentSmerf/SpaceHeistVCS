using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float RotationSpeed;
    public float speed;
    public float sensivity;
    public Vector3 DirForward;
    public Vector3 DirUp;
    public Vector3 DirRight;
    public Transform Front;
    public Transform Down;
    public Transform Right;
    PhotonView view;
    public static PlayerController instance;
    

    public GameObject Eyes;

    void Start()
    {
        instance = this;
        RotationSpeed = 100f;
        speed = 100f;
        sensivity = 2f;
        view = GetComponent<PhotonView>();
        if(view.IsMine){
            Eyes.SetActive(false);
        }
        if(!view.IsMine){
            Destroy(rb);
            Destroy(this);
        }

        
    }
    public void SetSensivity(float newSensivity){
        sensivity = newSensivity;
    }




    void Update(){
        
            float _yRot = Input.GetAxisRaw("Mouse X");
            float _xRot = Input.GetAxisRaw("Mouse Y");

            //Vector3 _rotationX = new Vector3 (-_xRot, 0f, 0f);
            //Vector3 _rotationY = new Vector3 (0f, _yRot, 0f);

        
            //Find Directions:
            DirForward = Front.position - this.transform.position;
            DirUp = this.transform.position - Down.position;
            DirRight = Right.transform.position - this.transform.position;
        
            //Movement on input:
            if(Input.GetKey("w")){
                rb.AddForce(DirForward * speed * Time.deltaTime, ForceMode.Force);
            }
            if(Input.GetKey("s")){
                rb.AddForce(-DirForward * speed * Time.deltaTime, ForceMode.Force);
            }
            if(Input.GetKey("a")){
                rb.AddForce(-DirRight * speed * Time.deltaTime, ForceMode.Force);
            }
            if(Input.GetKey("d")){
                rb.AddForce(DirRight * speed * Time.deltaTime, ForceMode.Force);
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
            if(Input.GetKey(KeyCode.LeftShift)){
                this.transform.Rotate(-_xRot * sensivity,0, 0, Space.Self);
                this.transform.Rotate(0,_yRot * sensivity, 0, Space.Self);
                //Vector2 warpPosition = Screen.safeArea.center;  // never let it move
                //Mouse.current.WarpCursorPosition(warpPosition);
                //InputState.Change(Mouse.current.position, warpPosition);
                Cursor.lockState = CursorLockMode.Locked;
            }

            if(Input.GetKeyUp(KeyCode.LeftShift)){
                Cursor.lockState = CursorLockMode.Confined;
            }
            if(Input.GetKeyDown(KeyCode.Escape)){
                Cursor.lockState = CursorLockMode.None;
            }
            


            //Old rotation system:
            /*
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
            */
        
    }

    
}
