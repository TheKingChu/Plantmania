using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private Scene currentScene;
    private int sceneBuildIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sceneBuildIndex = currentScene.buildIndex;

        if (collision.gameObject.CompareTag("Player"))
        {
            switch (sceneBuildIndex)
            {
                case 1:
                    SceneManager.LoadScene(2);
                    break;
                case 2:
                    if(gameObject.CompareTag("Back"))
                        SceneManager.LoadScene(1);
                    else

                        Debug.Log("no more scenes");

                    break;
                default:
                    SceneManager.LoadScene(0);
                    break;
            }
        }
    }
}
