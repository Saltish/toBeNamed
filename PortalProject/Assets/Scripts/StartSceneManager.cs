using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{
    private AsyncOperation asyn;
    private bool canClick = true;

    public GameObject black;
    public GameObject slider;
    public GameObject loading;
    public GameObject creditBoard;

    // Update is called once per frame
    void Update()
    {
        if (asyn != null)
        {
            slider.GetComponent<Slider>().value = asyn.progress;
        }
    }

    public void startGame()
    {
        if (canClick)
        {
            StartCoroutine("IEStartGame");
            canClick = false;
        }
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void creditUp()
    {
        if (canClick)
        {
            StartCoroutine("IECreditBoardUp");
            canClick = false;
        }
    }

    public void creditDown()
    {
        if (canClick)
        {
            StartCoroutine("IECreditBoardDown");
            canClick = false;
        }
    }

    IEnumerator IEStartGame()
    {
        yield return new WaitForSeconds(0.5f);
        Image img = black.GetComponent<Image>();
        //开始渐暗
        for (float i = 0; i < 1; i += 0.02f)
        {
            img.color = new Color(0, 0, 0, i);
            yield return null;
        }

        loading.SetActive(true);

        //~~~修改 要跳转到的界面
        asyn = SceneManager.LoadSceneAsync("EndScene");
        yield return asyn;
    }

    IEnumerator IECreditBoardUp()
    {
        RectTransform rb = creditBoard.GetComponent<RectTransform>();
        //开始升起
        for (int i = -450; i <= 0; i += 30)
        {
            rb.localPosition = new Vector3(0, i, 0);
            yield return null;
        }
        canClick = true;
    }
    IEnumerator IECreditBoardDown()
    {
        RectTransform rb = creditBoard.GetComponent<RectTransform>();
        //开始降下
        for (int i = 0; i >= -450; i -= 30)
        {
            rb.localPosition = new Vector3(0, i, 0);
            yield return null;
        }
        canClick = true;
    }
}
