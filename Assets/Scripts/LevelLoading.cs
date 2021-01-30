using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoading : MonoBehaviour
{

    //public Scene playArea;
    // Start is called before the first frame update

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Robin_Greybox");
        
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void LoadMenu() { 
        SceneManager.LoadScene("Main_Menu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
