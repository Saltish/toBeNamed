using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSceneManager : MonoBehaviour
{
    private static LevelSceneManager _instance = null;
    private bool GUIVisible = false;
    private bool canClick = true;
    private bool isFinished = false;
    private bool activeFlag = true;
    private LevelManager levelManager;
    
    public GameObject escBoard;
    public GameObject nextLevelButton;

    public static LevelSceneManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new LevelSceneManager();
        }
        return _instance;
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void setNextLevelActive()
    {
        if (activeFlag)
        {
            string nextLevelName = levelManager.getNextLevel(SceneManager.GetActiveScene().name);
            if (nextLevelName == "") return;
            Button button = nextLevelButton.GetComponent<Button>();
            nextLevelButton.GetComponentInChildren<Text>().color = Color.black;
            button.onClick.AddListener(delegate () {
                Time.timeScale = 1;
                SceneManager.LoadScene(nextLevelName);
            });
        }
        activeFlag = false;
    }

    private void Start()
    {
        if (_instance == null)
        {
            levelManager = LevelManager.GetInstance();
            if (levelManager && levelManager.isSceneFinished(SceneManager.GetActiveScene()))
            {
                setNextLevelActive();
            }
            else
            {
                nextLevelButton.GetComponentInChildren<Text>().color = Color.gray;
            }
            _instance = this;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canClick && !isFinished)
        {
            if (!GUIVisible)
            {
                Time.timeScale = 0;
                canClick = false;
                StartCoroutine("IEEscBoardUp");
                GUIVisible = true;
            }
            else
            {
                Time.timeScale = 1;
                canClick = false;
                StartCoroutine("IEEscBoardDown");
                GUIVisible = false;
            }
        }
    }

    IEnumerator IEEscBoardUp()
    {
        RectTransform rb = escBoard.GetComponent<RectTransform>();
        canClick = false;

        for (int i = -450; i <= 0; i += 30)
        {
            rb.localPosition = new Vector3(0, i, 0);
            yield return null;
        }
        canClick = true;
    }

    IEnumerator IEEscBoardDown()
    {
        RectTransform rb = escBoard.GetComponent<RectTransform>();
        canClick = false;

        for (int i = 0; i >= -450; i -= 30)
        {
            rb.localPosition = new Vector3(0, i, 0);
            yield return null;
        }
        canClick = true;
    }

    public void finishLevel()
    {
        isFinished = true;
        Time.timeScale = 0;
        StartCoroutine("IEEscBoardUp");
        setNextLevelActive();
        levelManager.finishLevel(SceneManager.GetActiveScene().name);
    }
}
