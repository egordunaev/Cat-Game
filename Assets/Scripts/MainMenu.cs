using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame()
    {
        if (SceneManager.GetActiveScene().name != "FinalScore")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else
        {
            SceneManager.LoadScene("Level1");
        }

    }
    public void QuitGame()
    {
        Debug.Log("Qutting...");
        Application.Quit();
    }
}
