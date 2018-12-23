using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour {

    public GameObject mainMenuPanel;
    public GameObject levelSelectPanel;

    public GameObject stage1Panel;

    public GameObject stage2Button;
    public GameObject stage2Panel;

    public GameObject stage3Button;
    public GameObject stage3Panel;
    // Use this for initialization
    void Start() {
        if (PlayerPrefs.GetInt("LevelsCleared") < 1) {
            stage2Button.SetActive(false);
        }
        if (PlayerPrefs.GetInt("LevelsCleared") < 2) {
            stage3Button.SetActive(false);
        }
    }

    public void stage1(){
        stage1Panel.SetActive(true);
        levelSelectPanel.SetActive(false);
    }
	public void loadStage1() {
        SceneManager.LoadScene(2);
    }
    public void stage2(){
        stage2Panel.SetActive(true);
        levelSelectPanel.SetActive(false);
    }
    public void loadStage2() {
        SceneManager.LoadScene(3);
    }
    public void stage3(){
        stage3Panel.SetActive(true);
        levelSelectPanel.SetActive(false);
    }
    public void loadStage3() {
        SceneManager.LoadScene(4);
    }

    public void BackToLevelSelect() {
        stage1Panel.SetActive(false);
        stage2Panel.SetActive(false);
        stage3Panel.SetActive(false);
        levelSelectPanel.SetActive(true);
    }
    public void backToMainMenu() {
        mainMenuPanel.SetActive(true);
        levelSelectPanel.SetActive(false);
    }
}
