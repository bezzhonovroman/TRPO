using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSceneScript : MonoBehaviour
{
    public Text nickname;
    public Text result;

    void Start()
    {
        nickname.text = PlayerPrefs.GetString("CurrentName");
        result.text = PlayerPrefs.GetInt("ScoreCount").ToString();

    }

    public void gotoMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
