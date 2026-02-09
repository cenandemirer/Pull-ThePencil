using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public float isDone = 3f;
    public GameObject IntroVideo;
    public GameObject StartMenu;
    
    void Awake()
    {
        StartCoroutine(Wait());
    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(isDone);

        IntroVideo.SetActive(false);
        StartMenu.SetActive(true);

    }

    public void StartTheGame() {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex + 1);
    }
    public void Level1()
    {
        SceneManager.LoadScene(1);
    }
}
