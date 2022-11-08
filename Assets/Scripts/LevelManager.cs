using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{


    private int selectedLvl;
    private GameObject currentLevel;
    public GameObject MyArmy;
    public TextMeshProUGUI victoryText;

    public GameObject finalUI;
    

    private GameSetUp gameSetUp;
    // Start is called before the first frame update
    void Start()
    {
        selectedLvl = PlayerPrefs.GetInt("Selected_Level");
        currentLevel = GameObject.Find("Level" + selectedLvl.ToString());
        gameSetUp = GameObject.Find("GameSetUpController").GetComponent<GameSetUp>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameSetUp.isStarted)
        {
            if(MyArmy.transform.childCount == 0)
            {
                finalUI.SetActive(true);

                victoryText.text = "Défaite !";
            }

            else if(currentLevel.transform.childCount == 0)
            {
                finalUI.SetActive(true);
                victoryText.text = "Victoire !";
            }
        }
    }

    public void restartLevel()
    {
        SceneManager.LoadScene("GameSetUp");
    }


    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
