using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GunRotation : MonoBehaviour
{
    public GameObject Gun;
    public GameObject GunEnd;
    public GameObject GunUp;
    public GameObject GunDown;
    public GameObject CameraG;
    public Vector3 screenPosition;
    public Vector3 worldPosition;
    public Vector3 direction;
    public int playerHit;
    public int playerNum;
    public LineRenderer lr;
    PhotonView view;
    public string Name;
    public AudioSource GunShotAudioSource;
    [SerializeField] private ParticleSystem GunParticleSystem;
    
    
    void Start()
    {
        view = GetComponent<PhotonView>();
        Name = PhotonNetwork.LocalPlayer.NickName;

        if(!view.IsMine){
            Destroy(CameraG);
            //Destroy(this);
        }
    }

    
    void Update()
    {
        if(view.IsMine){
            if(!Input.GetKey(KeyCode.LeftShift)){
                screenPosition = Input.mousePosition;
                screenPosition.z = Camera.main.nearClipPlane;
                worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
                direction = worldPosition - CameraG.transform.position;
            }
            if(Input.GetKey(KeyCode.LeftShift)){
                screenPosition = Screen.safeArea.center;
                screenPosition.z = Camera.main.nearClipPlane;
                worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
                direction = worldPosition - CameraG.transform.position;
            }
        }
        //playerNum = this.gameObject.GetComponent<PlayerNum>().NumberOfPlayer;
        GunShotAudioSource.volume = PlayerPrefs.GetFloat("volume", 0.4f);
    }

    void FixedUpdate(){
        if(view.IsMine){
            
            RaycastHit hit;
            if(Physics.Raycast(GunEnd.transform.position, direction, out hit)){
                
                Vector3 distanceFromWall = hit.point - Gun.transform.position;
                if(distanceFromWall.magnitude > 0.8f){
                    if(view.IsMine){
                        Gun.transform.LookAt(hit.point, GunUp.transform.position - GunDown.transform.position);
                    }
                }
                
                if(Input.GetButtonDown("Fire1")){
                    if(AmmoCount.instance.CanUseAmmo()){
                        if(this.transform.position.y < 15f){
                        
                            view.RPC("DrawLine", RpcTarget.All, hit.point);
                            Debug.Log(hit.transform.gameObject.tag);
                            if(hit.transform.gameObject.tag == "Player"){
                                hit.transform.gameObject.GetComponent<PlayerHp>().TakeDamage(Name);
                            }
                        }
                    }
                    
                }
            }
        }


    }
    [PunRPC]
    void DrawLine(Vector3 HitPos){
        
        GunParticleSystem.Play(false);
        Debug.Log("GunParticles");
        
        
        lr.enabled = true;
        GunShotAudioSource.Play();
        lr.SetPosition(0, GunEnd.transform.position);
        lr.SetPosition(1, HitPos);
        StartCoroutine("DestroyLine");
        
    }

    IEnumerator DestroyLine(){
        yield return new WaitForSeconds(0.2f);
        lr.enabled = false;
        GunParticleSystem.Stop();
    }
}
