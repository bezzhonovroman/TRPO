using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Text textBox; 
    public MenuPage mainMenu;
    private MenuPage activePage;

    void Start()
    {
        activePage = mainMenu;
    }
    public void ShowPage(MenuPage page)
    {
        activePage.Hide();
        page.Show();
        activePage = page;
    }

    public void StartGame()
    {
        if (textBox.text == "")
        {
            return;
        }
        PlayerPrefs.SetString("CurrentName", textBox.text);
        SceneManager.LoadScene("SampleScene");

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
