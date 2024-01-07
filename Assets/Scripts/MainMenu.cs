using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject[] lockButton;
    public Image[] level1Stars;
    public Image[] level2Stars;
    
    public Sprite goldenStar;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("levelunlocked", 0) == 1) {
            lockButton.SetActive(false);
        }

        int i = 0;
        while (PlayerPrefs.GetInt("level1Stars", 0) != i) {
            level1Stars[i].sprite = goldenStar;
            i++;
        }

        i = 0;
        while (PlayerPrefs.GetInt("level2Stars", 0) != i) {
            level2Stars[i].sprite = goldenStar;
            i++;
        }
    }

    private void DeactivateLockButtons() {
        int levelBeaten = PlayerPrefs.GetInt("levelbeaten", 0);
        for (int i = 0; i < levelBeaten; i++) {
            if (levelBeaten > 0) {
                lockButton[i -1].SetActive(false);
            }
        }
    }

    public void OnClickLevelOne() {
        SceneManager.LoadScene(1);
    }

    public void OnClickLevelTwo() {
        SceneManager.LoadScene(2);
    }
}
