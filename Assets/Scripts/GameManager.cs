using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject EndingScreen;
    public static GameManager GM;
    public int enemyCount;
    int startingCount;
    public Image star1;
    public Image star2;
    public Image star3;
    public Sprite goldenStar;

    public bool GameOver;

    // Start is called before the first frame update
    void Start()
    {
        GM = this;
        enemyCount = Enemy.EnemiesAlive;
        startingCount = enemyCount;
        GameOver = false;
    }

    private void SetStarsAmount(int stars, int levelIndex) {
        string levelStarPrefs = "level" + levelIndex + "stars";
        if (PlayerPrefs.GetInt(levelStarPrefs, 0) < stars) {
            PlayerPrefs.SetInt(levelStarPrefs, stars);
        }
    } 

    // Update is called once per frame
    void Update()
    {
        if (GameOver) {
            enemyCount = Enemy.EnemiesAlive;
            EndingScreen.SetActive(true);

            int currentLevel = SceneManager.GetActiveScene().buildIndex;
            int countStars = 0;
            if (enemyCount <= 2) {
                star1.sprite = goldenStar;
                countStars ++;
            }

            if (enemyCount <= 1) {
                star2.sprite = goldenStar;
                countStars ++;
            }

            if (enemyCount <= 0) {
                star3.sprite = goldenStar;
                countStars ++;
            }

            SetStarsAmount(countStars, currentLevel);
        }
    }

    public void OnClickMenuButton() {
        SceneManager.LoadScene(0);
    }

    public void OnClickReplayButton() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
