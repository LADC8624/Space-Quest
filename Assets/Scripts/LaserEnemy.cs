using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    public GameObject player;   // Recuperamos al objeto jugador
    Rigidbody2D rb2d;    // Recuperamos el componente de cuerpo rígido
    Vector3 target, dir; // Vectores para almacenar el objetivo y su dirección
    public float speed;
    public HealthBar healthBarScript;
    public Sounds soundsScript;
    //public EnemyController enemyControllerScript;
    private void Start()
    {
        soundsScript = GameObject.Find("MusicAndSounds").GetComponent<Sounds>();
        soundsScript.LaserEnemy();
        healthBarScript = GameObject.Find("HeathlBar").GetComponent<HealthBar>();
        rb2d = GetComponent<Rigidbody2D>();
        if (player != null)
        {
            target = player.transform.position;

        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
    private void FixedUpdate()
    {
        EnemyAttack();
    }
    public void EnemyAttack()
    {
        rb2d.velocity =(transform.up * speed);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        // Si chocamos contra el jugador o un ataque la borramos
        if (col.transform.tag == "Players" || col.transform.tag == "Attackaa" || col.gameObject.name == "SpaceShip")
        {
            healthBarScript.HitDamageEnemy();
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        // Si se sale de la pantalla borramos la roca
        Destroy(gameObject);
    }
}

