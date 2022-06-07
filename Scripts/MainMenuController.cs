using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenuController : MonoBehaviour
{

    public GameObject imageObject;
    public GameObject startButton, exitButton;
    public string sceneName;

    public GameObject fadeScreen;

    private void Start()
    {
        StartCoroutine(OpenInOrderRoutine());
    }

    IEnumerator OpenInOrderRoutine() // Coroutine fonksiyon
    {
        yield return new WaitForSeconds(.1f);

        imageObject.GetComponent<CanvasGroup>().DOFade(1, 0.5f);

        yield return new WaitForSeconds(.4f);

        startButton.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        startButton.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack); // Elastiklik verdik.

        yield return new WaitForSeconds(.4f);

        exitButton.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        exitButton.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);

    }

    public void StartGame()
    {
        StartCoroutine(StartGameRoutine());
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator StartGameRoutine()
    {
        yield return new WaitForSeconds(.1f);

        fadeScreen.GetComponent<CanvasGroup>().DOFade(1, 1f);

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneName);
    }

}
