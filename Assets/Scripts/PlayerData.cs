using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[CreateAssetMenu(fileName = "SaveData", menuName = "ScriptableObjects/SaveData")]
public class PlayerData : ScriptableObject
{
    //user
    public float speed;
    public float Hp;//20f
    public float O2;//0.07f
    public float Turbo;//0.6f
    
    public int SumCoins;
    //menu
    public int CoinsNow;
    public int BestScore;
    public int bestofscores;
    //upgrades 
    public int UpgradeSpeedPrice;
    public int SpeedLvl;
    public int O2Price;
    public int O2Lvl;
    public int HpPrice;
    public int HpLvl;
    public int TurboPrice;
    public int TurboLvl;
    //Upgrades
    private const string FILENAME = "SaveData.dat";
    


    public void SaveToFile()
    {
        //var filePath = Path.Combine(Application.dataPath, FILENAME);
        var filePath = Path.Combine(Application.dataPath, FILENAME);
        
        if (!File.Exists(filePath))
        {
            File.Create(filePath);
        }

        var json = JsonUtility.ToJson(this);
        File.WriteAllText(filePath, json);
    }
    public void LoadDataFromFile()
    {
        //var filePath = Path.Combine(Application.dataPath, FILENAME);
        
        var filePath = Path.Combine(Application.dataPath, FILENAME);
        if (!File.Exists(filePath))
        {
            Debug.LogWarning($"File /{filePath}/ not found!", this);
            Debug.LogWarning($"File /"+filePath+" not found!", this);
            return;
        }
        else
        {
            //JsonUtility.FromJsonOverwrite(filePath,this); Debug.Log("SE CARGO EL ARCHIVO");
            var json = File.ReadAllText(filePath);
           JsonUtility.FromJsonOverwrite(json, this); Debug.Log("Se cargó bien el archivo");
        }

        
    }


public void upgrades(int Upgrade1, int Upgrade2, int Upgrade3, int Upgrade4, int Upgrade5, int Upgrade6, int Upgrade7, int Upgrade8)
    {//for the Upgrades 
        UpgradeSpeedPrice = Upgrade1;
        SpeedLvl = Upgrade2;
        O2Price = Upgrade3;
        O2Lvl = Upgrade4;
        HpPrice = Upgrade5;
        HpLvl = Upgrade6;
        TurboPrice = Upgrade7;
        TurboLvl = Upgrade8;

    }

    public void suma(int coinsData)
    {//using to stock the sum of the coins batained during the game
        SumCoins = coinsData;//20
    }
    public void TotalCoins()//llamar en Gamer Over para sumar las monedas
    {
        CoinsNow = CoinsNow + SumCoins;//0=0+10
    }
    public void bestscore(int lastscore)
    {
        BestScore = lastscore;
    }
    public void Bscore()
    {
        if (bestofscores <= BestScore)
        {
            bestofscores = BestScore;
        }
    }
    /*public void getspeed(float Sp)
    {
        speed = Sp;
    }*/

}
