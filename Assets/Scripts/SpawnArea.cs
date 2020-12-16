using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject[] nSpawn;
    public int enemiesInMap;
    public PlayerController playerControllerScript;
    public Coin coinScript;
    public O2 o2Script;


    //public GameObject DestroyAllEnemies;

    private void Start()
    {

        playerControllerScript = GameObject.Find("PlayerController").GetComponent<PlayerController>(); ;
        //playerControllerScript.RunGame = false;

    }
    private void FixedUpdate()
    {


        if (enemiesInMap < 10 && playerControllerScript.RunGame == true)
        {
            Instantiate(EnemyPrefab, nSpawn[Random.Range(0, 12)].transform.position, nSpawn[0].transform.rotation); //your dropped sword
            enemiesInMap = enemiesInMap + 1;
        }
        if (playerControllerScript.RunGame == false)
        {
            GameObject DestroyAllEnemies = GameObject.Find("Enemy(Clone)");
            GameObject DestroAllCoins = GameObject.Find("Coins(Clone)");
            GameObject DestroyAllO2 = GameObject.Find("O2(Clone)");
            GameObject DestroAllAllyLaser = GameObject.Find("LasersPrefab(Clone)");
            GameObject DestroAllEnemyLaser = GameObject.Find("EnemyLasersPrefab(Clone)");
            if (DestroyAllEnemies)
            {
                Destroy(DestroyAllEnemies.gameObject);
            }
            if (DestroAllCoins)
            {
                Destroy(DestroAllCoins.gameObject);
            }
            if (DestroyAllO2)
            {
                Destroy(DestroyAllO2.gameObject);
            }
            if (DestroAllAllyLaser)
            {
                Destroy(DestroAllAllyLaser.gameObject);
            }
            if (DestroAllEnemyLaser)
            {
                Destroy(DestroAllEnemyLaser.gameObject);
            }


        }
    }
}
