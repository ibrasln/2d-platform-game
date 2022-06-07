using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int collectedGem;
    PlayerController playerController;
    UIController uI;
    public string sceneName;

    private void Awake()
    {
        instance = this;
        playerController = Object.FindObjectOfType<PlayerController>();
        uI = Object.FindObjectOfType<UIController>();
    }

    public void SceneOver()
    {
        StartCoroutine(SceneOverRoutine());
    }

    IEnumerator SceneOverRoutine()
    {
        yield return new WaitForSeconds(.1f);
        playerController.isMove = false;

        yield return new WaitForSeconds(1.5f);
        uI.OpenFadeScreen();

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);

        
    }

}
