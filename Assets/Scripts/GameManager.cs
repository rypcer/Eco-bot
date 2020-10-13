using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Animator animator;
    public void LoadLevel(int sceneID)
    {
        StartCoroutine(LoadLevelCoroutine(sceneID));
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevelCoroutine(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void RestartLevel()
    {
        StartCoroutine(LoadLevelCoroutine(SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadLevelCoroutine(0));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //fade out/fade in animation between levels
    IEnumerator LoadLevelCoroutine(int buildIndex)
    {
        animator.SetTrigger("changeScene");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(buildIndex);
        yield return null;
    }
}
