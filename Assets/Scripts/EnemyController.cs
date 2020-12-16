using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public float visionRadius;
    public float attackRadius;
    public float speed;
    Vector3 initialPosition;
    public Rigidbody2D Rb2d;//enemy
    public GameObject enemyLaserproyectile;
    public GameObject target;
    public float attackspeed;
    public bool attacking = true;
    public GameObject[] drop;
    public Animator Anim;
    public PlayerController playerControllerScript;
    public Coin coinScript;
    public SpawnArea spawnAreaScript;
    // Start is called before the first frame update
    void Start()
    {
        coinScript = GameObject.FindGameObjectWithTag("Scores").GetComponent<Coin>();
        initialPosition = transform.position;
        playerControllerScript = GameObject.Find("PlayerController").GetComponent<PlayerController>();
        coinScript = GameObject.Find("Coins").GetComponent<Coin>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.RunGame == true)
        {
            EnemyMovement();
        }
    }

    public void EnemyMovement()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 target = initialPosition;
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            player.transform.position - transform.position,
            visionRadius,
            1 << LayerMask.NameToLayer("Default")
        );
        float distance = Vector3.Distance(target, transform.position);//Distancia del Jugador
        float playerDistance = Vector3.Distance(player.transform.position, transform.position);
        if (hit.collider.tag == "Player")
        {
            target = player.transform.position;
            transform.up = target;


        }
        if (playerDistance > visionRadius)
        {

            target = initialPosition;

            transform.up = target;

        }

        distance = Vector3.Distance(target, transform.position);//Distancia del Jugador
        Vector3 dir = (target - transform.position).normalized;//dirección actual hasta el target

        Vector3 forward = transform.TransformDirection(player.transform.position - transform.position);
        Debug.DrawRay(transform.position, forward, Color.red);


        if (target != initialPosition && distance < attackRadius)
        {
            dir.z = 0;
            transform.up = dir;

            if (!attacking) StartCoroutine(attack(attackspeed));


        }
        // En caso contrario nos movemos hacia él
        else
        {

            Rb2d.transform.position += dir * speed * Time.deltaTime;

        }
        if (target == initialPosition && distance < 0.02f)
        {
            transform.position = initialPosition;

        }
        Debug.DrawLine(transform.position, target, Color.green);
    }

    IEnumerator attack(float sec)
    {
        attacking = true;
        if (enemyLaserproyectile != null)
        {
            Instantiate(enemyLaserproyectile, transform.position, transform.rotation);
            yield return new WaitForSeconds(sec);
        }

        attacking = false;

    }

    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            Anim.SetBool("Dead", true);
            coinScript.EnemyDestroy();
            StartCoroutine(DestroyShip());

        }

    }
    IEnumerator DestroyShip()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }

    public void OnDestroy() //called, when enemy will be destroyed
    {

        
        //coinScript.enemy = coinScript.enemyValue + 1;
        spawnAreaScript.enemiesInMap = spawnAreaScript.enemiesInMap - 1;
        Instantiate(drop[Random.Range(0, 2)], transform.position, drop[0].transform.rotation); //your dropped sword
    }


}
