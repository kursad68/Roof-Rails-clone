using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ButtonCanvas;
    public bool isGameEnd;
    public bool isGameWin;
    
    private void OnEnable()
    {
        EventManager.getGameManager += GetGameManager;
    }
    private void OnDisable()
    {
        EventManager.getGameManager -= GetGameManager;

    }
    GameManager GetGameManager()
    {
        return GetComponent<GameManager>();
    }

    void Start()
    {
        Time.timeScale = 1;
        isGameEnd = false;
        isGameWin = false;
        ButtonCanvas.SetActive(false);
    }

    void Update()
    {

    }
    public void nextLevel()
    {
        SceneManager.LoadScene(0);
    }
    public void lost()
    {
        ButtonCanvas.SetActive(true);
        Time.timeScale = 0;
    }
    public void LevelWinner()
    {
        

        SceneWinControl();
        ButtonCanvas.SetActive(true);
    }
    private void SceneWinControl()
    {
        if (isGameWin == false)
        {
            int temp;
            temp = PlayerPrefs.GetInt("CurrentLevel");
            temp++;
            PlayerPrefs.SetInt("CurrentLevel", temp);
            Debug.Log("new level " + temp + " " + PlayerPrefs.GetInt("CurrentLevel"));
            isGameWin = true;
        }
    }
   
}
