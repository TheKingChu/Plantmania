using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnExitLevel : MonoBehaviour
{
    public string sceneName;
    public bool isNextScene = true;

    [SerializeField] public SceneInfo_SO sceneInfo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sceneInfo.isNextScene = isNextScene;
            SceneManager.LoadScene(sceneName);
        }
    }
}
