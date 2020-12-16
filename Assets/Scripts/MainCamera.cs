using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject playerController;
    public PlayerController playerControllerScript;
    Transform target;
    Vector2 velocity;
    float TX2, TY2, BX2, BY2;
    float smoothTime = 0.1f;
    void Awake()
    {
        playerController = GameObject.Find("SpaceShip");
        target = playerController.transform;

    }
    // Update is called once per frame
    void Update()
    {
        MainCameraMovement();
    }
    public void MainCameraMovement()
    {
        target = playerController.transform;
        
        TX2 = playerControllerScript.spaceShip.transform.position.x ;
        TY2 = playerControllerScript.spaceShip.transform.position.y ;
        BX2 = playerControllerScript.spaceShip.transform.position.x ;
        BY2 = playerControllerScript.spaceShip.transform.position.y ;
        //calcula la posision de la camara con un ligero retraso, lo que nos da el efecto de seguimiento al personaje 
        float posX = Mathf.Round(Mathf.SmoothDamp(Camera.main.transform.position.x, target.position.x, ref velocity.x, smoothTime) * 100) / 100;

        float posY = Mathf.Round(Mathf.SmoothDamp(Camera.main.transform.position.y, target.position.y, ref velocity.y, smoothTime) * 100) / 100;
        
        transform.position = new Vector3(
           Mathf.Clamp(posX, TX2, BX2),
            Mathf.Clamp(posY, BY2, TY2),
            transform.position.z
        );
    }
}
