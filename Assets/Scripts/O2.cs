using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2 : MonoBehaviour
{
    public HealthBar healthBarScript;
    // Start is called before the first frame update
    private void Start()
    {
        healthBarScript = GameObject.Find("HeathlBar").GetComponent<HealthBar>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "SpaceShip")
        {
            Debug.Log("More O2");
            healthBarScript.MoreO2();
            Destroy(gameObject);
        }
    }
}
