using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// needed when changing scenes
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        //SceneManager.LoadScene("TrialScene");
    }

    public void quitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
