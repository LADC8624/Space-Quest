using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPlayer : MonoBehaviour
{
    public float WaitBeforeDestroy;
    private Rigidbody2D Rb2d;
    private float laserSpeed;
    public PlayerData playerDataScript;
    public Sounds soundsScript;

    private void Start()
    {
        soundsScript = GameObject.Find("MusicAndSounds").GetComponent<Sounds>();
        soundsScript.Laser();
        laserSpeed = 20;
        Rb2d = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {
        Rb2d.velocity = transform.up * laserSpeed;/////
    }


    IEnumerator OnTriggerEnter2D(Collider2D collition)
    {

        if (collition.tag == "Object")
        {
            yield return new WaitForSeconds(WaitBeforeDestroy);
            Destroy(gameObject);
        }
        else if (collition.tag == "Limitshot")
        {
            Destroy(gameObject);
        }
    }


}