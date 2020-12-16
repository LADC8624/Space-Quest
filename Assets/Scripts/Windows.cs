using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Windows : MonoBehaviour
{
    public GameObject[] screens;
    public Image BScreen;
    //monedas
    public int coinMenu;
    private int coinValue;
    public Text score;
    public PlayerData playerDataSO;
    public PlayerController playerControllerScript;
    public Sounds soundsScript;
    public Coin coinScript;
    public HealthBar healthBarScript;
    private void Start()
    {
        /*soundsScript.MenuSong();
        coinScript.DataMenu();
        coinScript.Upgrades();
        healthBarScript.BarUpdate();*/


    }

    private void FixedUpdate()
    {


    }


    public void StartScreen()
    {
        screens[0].SetActive(true);
    }
    public void MenuScreen()
    {
        screens[1].SetActive(true);
        soundsScript.MenuSong();
        coinScript.DataMenu();
        //coinScript.CleanScore();
        GameOverScreenoff();



    }

    public void GameOverScreen()
    {

        screens[2].SetActive(true);
        //coinScript.CleanScore();
        playerDataSO.TotalCoins();
        playerDataSO.Bscore();
        soundsScript.SurvivalMusicStop();
        playerControllerScript.RunGame = false;
        //soundsScript.SurvivalMusicStop();
    }
    public void SurvivalScreen()
    {

        screens[3].SetActive(true);
        //playerControllerScript.sendspeed();
        coinScript.CleanScore();
        healthBarScript.playagain();
        //healthBarScript.BarUpdate();
        playerControllerScript.RunGame = true;
        MenuScreenoff();
        soundsScript.MenuSongStop();
        soundsScript.SurvivalMusic();
    }
    public void playgameagain()
    {
        screens[2].SetActive(false);
        coinScript.CleanScore();
        healthBarScript.playagain();
        playerControllerScript.RunGame = true;
        MenuScreenoff();
         
        soundsScript.SurvivalMusicStop();
        soundsScript.SurvivalMusic();
    }
    public void AdventureScreen()
    {
        screens[6].SetActive(true);
    }
    public void OptionsScreen()
    {
        screens[4].SetActive(true);
    }
    public void StoreScreen()
    {
        screens[5].SetActive(true);
    }
    public void BlackScreen()
    {
        BScreen.CrossFadeAlpha(1f, 1f, false);
        // screens[7].SetActive(true);
    }

    //////////////////////////

    public void StartScreenoff()
    {

        screens[0].SetActive(false);
        BlackScreenoff();
    }
    public void MenuScreenoff()
    {
        BlackScreen();
        screens[1].SetActive(false);
        coinScript.CleanScore();
    }
    public void GameOverScreenoff()
    {
        screens[2].SetActive(false);
    }
    public void SurvivalScreenoff()
    {
       // coinScript.CleanScore();
        screens[3].SetActive(false);
    }
    public void AdventureScreenoff()
    {
        screens[6].SetActive(false);
    }
    public void OptionsScreenoff()
    {
        screens[4].SetActive(false);
    }
    public void StoreScreenoff()
    {
        screens[5].SetActive(false);
    }
    public void BlackScreenoff()
    {
        BScreen.CrossFadeAlpha(0f, 1f, false);
        StartCoroutine(CloseBscreen());
        // screens[7].SetActive(false);
    }
    IEnumerator CloseBscreen()
    {
        yield return new WaitForSeconds(1);
        screens[6].SetActive(false);
    }
    public void Upgrades()
    {

    }
    public void PlayAgain()
    {
        coinScript.CleanScore();
        playerControllerScript.RunGame = true;
        soundsScript.MenuSongStop();
        soundsScript.SurvivalMusic();
        SceneManager.LoadScene("PlayAgain");

    }
    public void Menu()
    {
        coinScript.CleanScore();
        playerControllerScript.RunGame = false;
        SceneManager.LoadScene("MenuGame");

    }
    public void CloseHowToPlay()
    {
        screens[7].SetActive(false);
    }
    public void OpenHowToPlay()
    {
        screens[7].SetActive(true);
    }
}
