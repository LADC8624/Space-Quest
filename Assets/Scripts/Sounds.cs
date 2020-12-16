using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource[] sounds;

    public void ExplosionPlay()
    {
        sounds[2].Play();
    }
    public void ExplosionStop()
    {
        sounds[2].Stop();
    }
    public void CoinPlay()
    {
        sounds[1].Play();
    }
    public void CoinStop()
    {
        sounds[1].Stop();
    }
    public void SurvivalMusic()
    {
        sounds[0].Play();
    }
    public void SurvivalMusicStop()
    {
        sounds[0].Stop();
    }
    public void MenuSong()
    {
        sounds[3].Play();
    }
    public void MenuSongStop()
    {
        sounds[3].Stop();
    }
    public void Laser()
    {
        sounds[4].Play();
    }
    public void LaserStop()
    {
        sounds[4].Stop();
    }
    public void LaserEnemy()
    {
        sounds[5].Play();
    }
    public void LaserEnemyStop()
    {
        sounds[5].Stop();
    }
}
