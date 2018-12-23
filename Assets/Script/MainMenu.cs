using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject mainMenuPanel;
    public GameObject levelSelectPanel;
    public GameObject aboutPanel;

    public Text totalCoinText;
    int totalCoin;
    // Use this for initialization
    void Start () {
        //PlayerPrefs.SetInt("LevelsCleared", 0);
        //PlayerPrefs.SetInt("TotalCoins", 0);
        totalCoin = PlayerPrefs.GetInt("TotalCoins");
        totalCoinText.text = "Total Coins : " + totalCoin.ToString();
    }
	
	public void Play() {
        SceneManager.LoadScene(2);
    }
    public void LevelSelect() {
        mainMenuPanel.SetActive(false);
        levelSelectPanel.SetActive(true);
    }
    public void About() {
        mainMenuPanel.SetActive(false);
        aboutPanel.SetActive(true);
    }
}
