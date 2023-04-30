using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIButtonManager : MonoBehaviour
{
    bool isPause = false;
    public Transform canvas;

    public void PauseClick()
    {
        if (false == isPause)
        {
            isPause = true;
            canvas.Find("Stop").gameObject.SetActive(false);
            canvas.Find("Play").gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void RestartClick()
    {
        if (true == isPause)
        {
            isPause = false;
            canvas.Find("Stop").gameObject.SetActive(true);
            canvas.Find("Play").gameObject.SetActive(false);
            Time.timeScale = 1.0f;
            canvas.Find("Clear").gameObject.SetActive(false);
            canvas.Find("TimeOut").gameObject.SetActive(false);
        }
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
    public void PlayClick()
    {
        if (true == isPause)
        {
            isPause = false;
            canvas.Find("Stop").gameObject.SetActive(true);
            canvas.Find("Play").gameObject.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    public void CreateMap()
    {
        canvas.Find("CreateMap").gameObject.SetActive(false);
    }

    public void GameWin()
    {
        canvas.Find("Clear").gameObject.SetActive(true);
    }

    public void GameLose()
    {
        canvas.Find("TimeOut").gameObject.SetActive(true);
    }

    public void ExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }
}
