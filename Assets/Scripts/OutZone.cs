using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutZone : MonoBehaviour
{
    public GameObject player;
    public bool safeZone;
    public float damageZone;
    public float DPS;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "SpaceShip")
        {
            safeZone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "SpaceShip")
        {
            safeZone = false;
        }
    }
    private void Update()
    {

        StartCoroutine(DamageSec(DPS));
    }
    IEnumerator DamageSec(float sec)
    {

        damageZone = 0.1f;
        yield return new WaitForSeconds(sec);
    }
}
