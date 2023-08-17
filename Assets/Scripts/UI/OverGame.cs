using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverGame : MonoBehaviour
{

    public GameObject GameOverpanel;
    public GameObject PlayScreen;
    public void GameOver(bool isDead)
    {
        if (isDead)
        {
            SoundManager.instance.audioTheme.Stop();
            GameOverpanel.SetActive(true);
            PlayScreen.SetActive(false);
        }

    }

}
