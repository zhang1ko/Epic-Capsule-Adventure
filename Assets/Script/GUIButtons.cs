using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIButtons : MonoBehaviour {

    public Text totalCoinText;
    int totalCoin;
    public GameObject pausePanel;
    bool active = false;

    void Start () {
        totalCoin = PlayerPrefs.GetInt("TotalCoins");
        totalCoinText.text = "Total Coins : " + totalCoin.ToString();
    }
	public void BackButton () {
        SceneManager.LoadScene(1);
    }

    public void TogglePause() {
        Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.0f : 0.0f;
        active = !active;
        pausePanel.SetActive(active);
    }
}
