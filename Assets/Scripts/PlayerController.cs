using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject spaceShip;
    //DataPlayer
    public PlayerData playerDataScript;
    private float speed;
    public GameObject laserproyectile;
    //DataPlayer
    public Rigidbody2D Rb2d;
    public Transform mouseTraget;
    public Camera mainCamera;
    public Animator anim;
    public float turbospeed;
    public Vector3 mouseWorldPosition;
    public Vector3 lookAtDirection;
    public bool shooting = false;
    public Vector3 mov;
    public bool usingTurbo = false;
    public HealthBar healthBarScript;
    public Windows windowsScript;
    public bool RunGame = false;
    public Sounds soundsScript;
    Vector3 initposition;


    // Start is called before the first frame update
    void Start()
    {


        speed = playerDataScript.speed;//obtenemos la velocidad de la nave actual guardada en ScriptableObject PlayerData
        //comprobamos que esten asiganos los componentes necesarios
        if (mouseTraget == null)
        {
            mouseTraget = transform;
        }
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (RunGame == true)
        {
            Movemment();
            MouseLook();
            Turbo();
            LaserAttack();
            Dead();
        }

    }

    public void Movemment()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            
            mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = 0;

            transform.position = Vector3.MoveTowards(transform.position, mouseWorldPosition, speed * Time.deltaTime);

        }
        
    }

    public void MouseLook()//esta clase se utiliza para cambiar la direccion de nuestra nave
    {
        mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);//para saber la posision de nuestro mouse
        mouseWorldPosition.z = 0;

        lookAtDirection = mouseWorldPosition - mouseTraget.position;//para saber a que objeto debe mirar nuestra nave
        mouseTraget.up = lookAtDirection;//Para que la parte delantera de la nave sea la que voltee al cursor o mouse

    }
    public void Turbo()
    {
        if (Input.GetKey(KeyCode.LeftShift) && healthBarScript.TurboBar.size >= 0.1f)
        {

            anim.SetBool("Moving", true);
            mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = 0;

            turbospeed = playerDataScript.speed + 1f;
            transform.position = Vector3.MoveTowards(transform.position, mouseWorldPosition, turbospeed * Time.deltaTime);
            usingTurbo = true;

        }
        else
        {
            usingTurbo = false;
            anim.SetBool("Moving", false);
        }
    }

    public void LaserAttack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shooting = true;

            GameObject proyectile = Instantiate(laserproyectile, transform.position, mouseTraget.rotation);

        }
        shooting = false;
    }
    public void Dead()
    {
        if (healthBarScript.Bar.size <= 0 || healthBarScript.O2Bar.size <= 0)
        {
            //parar juego
            soundsScript.ExplosionPlay();
            windowsScript.GameOverScreen();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "O2")
        {
            Debug.Log("More O2");
        }
    }

}
