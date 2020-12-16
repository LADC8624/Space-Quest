using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{   //player
    public float valorHP;
    public Scrollbar Bar;
    public float Health;
    //Turbo
    public float valortURBO;
    public Scrollbar TurboBar;
    public float Turbo;
    //O2
    public float valorO2;
    public Scrollbar O2Bar;
    public float O2;
    //PlayerController
    public PlayerController playerControllerScript;
    public PlayerData playerDataSO;


    public OutZone outZoneScript;
    private void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (playerControllerScript.RunGame == true)
        {
            OutZoneDamage();
            WasteO2();
            UseTurbo();
            BarUpdate();
        }


    }
    public void playagain()
    {
        Health = 100f;
        Turbo = 100f;
        O2 = 100f;
        Bar.size = 100f;
        TurboBar.size = 100f;
        O2Bar.size = 100f;
    }
    public void BarUpdate()
    {
        valorHP = playerDataSO.Hp;
        valortURBO = playerDataSO.Turbo;
        valorO2 = playerDataSO.O2;
    }
    public void OutZoneDamage()
    {
        if (outZoneScript.safeZone == false)
        {
            Health = Health - outZoneScript.damageZone;
            Bar.size = Health / 100f;
        }
    }
    public void HitDamageEnemy()//controlamos la barra al recibir daño de un enemigo normal
    {

        Health = Health - valorHP;//valorHP
        Bar.size = Health / 100f;

    }
    public void UseTurbo()
    {
        if (playerControllerScript.usingTurbo == true && Turbo >= 0)
        {
            Turbo = Turbo - 0.5f;
            TurboBar.size = Turbo / 100f;
        }
        else
        {
            if (Turbo <= 100)
            {
                Turbo = Turbo + valortURBO;//valortURBO

                TurboBar.size = Turbo / 100f;
            }


        }
    }
    public void WasteO2()
    {

        O2 = O2 - valorO2; //valorO2
        O2Bar.size = O2 / 100f;

    }
    public void MoreO2()
    {

        O2 = O2 + 20f;
        O2Bar.size = O2 / 100f;

    }


}
