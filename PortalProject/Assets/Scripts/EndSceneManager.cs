using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndSceneManager : MonoBehaviour
{
    private AsyncOperation asyn;

    public GameObject slider;
    public GameObject loading;

    // Update is called once per frame
    void Update()
    {
        if (asyn != null)
        {
            slider.GetComponent<Slider>().value = asyn.progress;
        }
    }

    public void menu()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void restart()
    {
        StartCoroutine("IERestartGame");
    }

    IEnumerator IERestartGame()
    {
        loading.SetActive(true);

        //~~~修改 要跳转到的界面
        asyn = SceneManager.LoadSceneAsync("StartScene");
        yield return asyn;
    }
}
