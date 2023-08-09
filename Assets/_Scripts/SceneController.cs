using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Animator sceneTransitionAnim;

    public static SceneController instance;
    private void Awake()
    {
        instance = this;
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadLevelCoroutine());
    }

    IEnumerator LoadLevelCoroutine()
    {
        sceneTransitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        sceneTransitionAnim.SetTrigger("Start");
    }
}
