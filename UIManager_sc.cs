using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager_sc : MonoBehaviour
{
    public TMPro.TextMeshProUGUI gameovertext;
    public GameObject replaybutton;
    public TMPro.TextMeshProUGUI scoretext;
    public int score;

    public Sprite[] healthSprites;
    public Image healthImage;

    playerscript player;
    GameManager_sc gameManager_Sc;

    void Start()
    {
        
    }

    void Update()
    {
        scoretext.text = score.ToString();

        for (int i = 0; i < healthSprites.Length; i++)
        {
            if (i == player.health)
            {
                healthImage.sprite = healthSprites[i];
            }

        }
    }

    public void Score()
    {
        score += 100;
    }


    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    void GameOverSequence()
    {
        gameManager_Sc.GameOver();
        gameovertext.gameObject.SetActive(true);
        replaybutton.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            gameovertext.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            gameovertext.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
