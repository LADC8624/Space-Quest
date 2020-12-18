using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Coin : MonoBehaviour
{
    public int coin;
    private int coinValue;
    public Text score;
    public Sounds enemySoundsScript;
    public EnemyController enemyControllerScript;
    //Total Score
    public int ScorePoints;
    public Text Totalscore;
    //enemyscore
    public int enemy;
    public int enemyValue;
    public Text enemyScore;
    //ScriptableObject
    public PlayerData playerDataSO;
    //Menu
    public Text Totalscoremenu;
    public Text BestScoretext;
    public Text Cmenu;
    //Upgrades
    //speedupgrade
    public Button SpeedButton;
    public Text TextButtonSpeed;
    public Text upgradespeed;
    public Text lvlText;
    public int spU;
    public int spLVL;
    //O2upgrade  
    public Button O2Button;
    public Text TextButtonO2;
    public Text O2upgrade;
    public Text lvlO2;
    public int O2U;
    public int O2LVL;
    //HPUpgrade  
    public Button HpButton;
    public Text TextButtonHp;
    public Text Hpupgrade;
    public Text lvlHp;
    public int HPU;
    public int HPLVL;
    //turboUpgrade
    public Button TurboButton;
    public Text TextButtonTurbo;
    public Text TurboUpgrade;
    public Text lvlTurbo;
    public Text CoinUpgrades;
    public int TurboU;
    public int TurboLVL;
    //HealthBarScript
    public HealthBar healthBarScript;
    //player
    public PlayerController playerControllerScript;
    private void Start()
    {
        
        enemySoundsScript = GameObject.FindGameObjectWithTag("Sounds").GetComponent<Sounds>();
        DataMenu();
        playerDataSO.SumCoins = 0;
    }
    public void Upgrades()
    {
        upgradespeed.text = playerDataSO.UpgradeSpeedPrice.ToString();
        lvlText.text = playerDataSO.SpeedLvl.ToString();
        O2upgrade.text = playerDataSO.O2Price.ToString();
        lvlO2.text = playerDataSO.O2Lvl.ToString();
        Hpupgrade.text = playerDataSO.HpPrice.ToString();
        lvlHp.text = playerDataSO.HpLvl.ToString();
        TurboUpgrade.text = playerDataSO.TurboPrice.ToString();
        lvlTurbo.text = playerDataSO.TurboLvl.ToString();
        //to change
        spU = playerDataSO.UpgradeSpeedPrice;
        O2U = playerDataSO.O2Price;
        HPU = playerDataSO.HpPrice;
        TurboU = playerDataSO.TurboPrice;
        spLVL = playerDataSO.SpeedLvl;
        O2LVL = playerDataSO.O2Lvl;
        HPLVL = playerDataSO.HpLvl;
        TurboLVL = playerDataSO.TurboLvl;
    }
    public void CleanScore()
    {
        coin = 0;
            ScorePoints = 0;
            enemy = 0;
            //coins
            score.text = coin.ToString();
           
            //score
            Totalscore.text = ScorePoints.ToString();
          
            //enemies
            enemyScore.text = enemy.ToString();
           
        
     
    }
    public void Bspeed()
    {

        if (spU <= coin && spLVL <= 5)
        {
            coin = coin - spU;
            playerDataSO.CoinsNow = coin;
            spU = spU * 2;
            playerDataSO.UpgradeSpeedPrice = spU;
            spLVL = spLVL + 1;
            playerDataSO.SpeedLvl = spLVL;
            playerDataSO.speed += 1;
            DataMenu();
            Upgrades();
            


        }
        if (spLVL == 6)
        {
            TextButtonSpeed.text = "MAX";
        }

    }
    public void BO2()
    {
        if (O2U <= coin && O2LVL <= 5)
        {
            coin = coin - O2U;
            playerDataSO.CoinsNow = coin;
            O2U = O2U * 2;
            playerDataSO.O2Price = O2U;
            O2LVL = O2LVL + 1;
            playerDataSO.O2Lvl = O2LVL;
            playerDataSO.O2 = playerDataSO.O2 - 0.01f;
            DataMenu();
            Upgrades();

        }
        if (O2LVL == 6)
        {
            TextButtonO2.text = "MAX";
        }

    }
    public void BHp()
    {
        if (HPU <= coin && HPLVL <= 5)
        {
            coin = coin - HPU;
            playerDataSO.CoinsNow = coin;
            HPU = HPU * 2;
            playerDataSO.HpPrice = HPU;
            HPLVL = HPLVL + 1;
            playerDataSO.HpLvl = HPLVL;
            playerDataSO.Hp = playerDataSO.Hp - 2f;
            DataMenu();
            Upgrades();
        }
        if (HPLVL == 6)
        {
            TextButtonHp.text = "MAX";
        }

    }
    public void BTurbo()
    {
        if (TurboU <= coin && TurboLVL <= 5)
        {
            coin = coin - TurboU;
            playerDataSO.CoinsNow = coin;
            TurboU = TurboU * 2;
            playerDataSO.TurboPrice = TurboU;
            TurboLVL = TurboLVL + 1;
            playerDataSO.TurboLvl = TurboLVL;
            playerDataSO.Turbo = playerDataSO.Turbo + 0.1f;

            DataMenu();
            Upgrades();
        }
        if (TurboLVL == 6)
        {
            TextButtonTurbo.text = "MAX";
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "SpaceShip")
        {
            enemySoundsScript.CoinPlay();

            coinValue = int.Parse(score.GetComponent<Text>().text);
            coin = coinValue + 10;//20
            score.text = coin.ToString();
            // Totalscore.text = ScorePoints.ToString();
            playerDataSO.suma(int.Parse(score.GetComponent<Text>().text));//20
            //playerDataSO.TotalCoins();
            Destroy(gameObject);

        }


    }
    
    public void EnemyDestroy()
    {
        //
        
        enemyValue = int.Parse(enemyScore.GetComponent<Text>().text);
        enemy = enemyValue + 1;
        enemyValue = enemy;

        enemySoundsScript.ExplosionPlay();
        enemyScore.text = enemyValue.ToString();
        TotalScore();
    }
    public void TotalScore()
    {

        ScorePoints = enemyValue * 100;
        Totalscore.text = ScorePoints.ToString();
        playerDataSO.bestscore(int.Parse(Totalscore.GetComponent<Text>().text));
    
    }
    public void DataMenu()
    {
        coin = playerDataSO.CoinsNow;
        Totalscoremenu.text = playerDataSO.BestScore.ToString();
        BestScoretext.text = playerDataSO.bestofscores.ToString();
        Cmenu.text = playerDataSO.CoinsNow.ToString();
        CoinUpgrades.text = playerDataSO.CoinsNow.ToString();
    }


}
