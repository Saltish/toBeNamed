using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance = null;
    private bool[] selectable; //该关卡可否选择
    private GameObject[] levelButtons;
    private int levelCount;

    public Scene startScene;
    public string[] levelNames;
    public GameObject levelObj;  // 要生成的level样品


    public static LevelManager GetInstance()
    {
        /*if (_instance == null)
        {
            _instance = new LevelManager();
        }*/
        return _instance;
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);

            levelCount = levelNames.Length;
            

            levelButtons = new GameObject[levelCount];
            selectable = new bool[levelCount];
            if (levelCount != 0) selectable[0] = true;
            for (int i = 1; i < levelCount; i++)
            {
                selectable[i] = false;
            }
        }
    }

    public void GenerateButtons()
    {
        float startX = 345;
        float startY = -210;
        float dX = 130;  // 两个level之间x坐标的间隔
        float dY = -50;  // 两个level之间y坐标的间隔
        for (int i = 0; i < levelCount; i++)
        {
            levelButtons[i] = Instantiate(levelObj);

            RectTransform rb = levelButtons[i].GetComponent<RectTransform>();
            rb.position = new Vector3(startX + dX * (i % 3), startY + dY * (i / 3), 0);
            Text t = levelButtons[i].GetComponentInChildren<Text>();
            t.text = levelNames[i];


            if (!selectable[i])
            {
                t.color = Color.gray;
            }
            else
            {
                activeOnClick(i);
            }

            levelButtons[i].transform.parent = GameObject.Find("Levels").transform;
        }
    }

    public bool isSceneFinished(Scene scene)
    {
        bool result = false;
        for (int i = 0; i < levelCount - 1; i++)
        {
            if (SceneManager.GetSceneByBuildIndex(i + 1).Equals(scene))
            {
                return selectable[i + 1];
            }
        }
        return result;
    }

    public string getNextLevel(string sceneName)
    {
        string result = "";
        for (int i = 0; i < levelCount - 1; i++)
        {
            if (sceneName.Equals(levelNames[i]))
            {
                return levelNames[i + 1];
            }
        }
        return result;
    }

    public void finishLevel(string sceneName)
    {
        for (int i = 0; i < levelCount - 1; i++)
        {
            if (levelNames[i].Equals(sceneName))
            {
                selectable[i + 1] = true;
            }
        }
    }

    private void activeOnClick(int index)
    {
        levelButtons[index].GetComponentInChildren<Text>().color = Color.black;
        Button button = levelButtons[index].GetComponentInChildren<Button>();
        button.onClick.AddListener(delegate () { SceneManager.LoadScene(index + 1); });
    }
}
