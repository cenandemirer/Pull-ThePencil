using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Balls[] startBalls;

    public List<Balls> activeBalls;

    public FinishEvents finishEvents;

    float requiredBallPercentage;
    float requiredTimerPercentage;
    public int completePercentage;
    public bool levelCompleted;
    public bool levelFailed;
    float timer = 4;
    bool startTimer;
    int second;
    int splitSecond;
    public bool gameSetted;
    public bool levelCompleteEvents;
    public bool levelFailedEvents;

    //UI
    public TextMeshProUGUI completePercentageText;
    public GameObject fireWork;
    public GameObject blackBackground;
    public GameObject levelCompletedText;
    public GameObject levelFailedText;
    public GameObject tapToContinueButton;
    public GameObject tapToRestart;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI levelNumber;

    public SoundManager soundManager;
    [SerializeField] ThrowPen throwPen;
    [SerializeField] GameObject blueBackground;
    bool startShootEvent;
    bool completedShootEvent;
    bool closeBlueBackground;

    //New Camera Position&Rotation
    [SerializeField] Camera cam;
    Vector3 oldCameraPos = new Vector3(0, 1, -8);
    Vector3 newCameraPos = new Vector3(0, 1, 9.5f);
    Quaternion newCameraRot = new Quaternion(0f, 180f, 0f, 0f);


    private void Start()
    {
        requiredBallPercentage = 0.9f;
        soundManager = FindObjectOfType<SoundManager>();
        levelNumber.text = "Level " + SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (startBalls[startBalls.Length - 1].startProcessCompleted && !gameSetted)
        {
            foreach (Balls ball in startBalls)
            {
                ball.TransitionToState(ball.activeState);
            }
            gameSetted = true;
        }

        if (finishEvents.completedBallCount == 0)
            return;
        if (!levelCompleted && !levelFailed)
        {
            completePercentage = Mathf.Abs((finishEvents.completedBallCount * 100) / activeBalls.Count);
            completePercentageText.text = "%" + completePercentage.ToString();
            startTimer = true;
        }

        if (finishEvents.completedBallCount >= activeBalls.Count * requiredBallPercentage && !levelFailed)
        {
            startShootEvent = true;
            StartShootEvents();
            //levelCompleted = true;
            //LevelCompleteEvents();
            startTimer = false;
        }
        if (startTimer && !levelCompleted && !levelFailed)
        {
            SetTime();
        }
        if (completedShootEvent && !closeBlueBackground)
        {
            StartCoroutine(CloseBlueBackground());
        }
    }

    public void LevelCompleteEvents()
    {
        if (levelCompleted && !levelCompleteEvents)
        {
            soundManager.PlaySound("win");
            Instantiate(fireWork, fireWork.transform.position, Quaternion.identity);
            blackBackground.SetActive(true);
            levelCompletedText.SetActive(true);
            tapToContinueButton.SetActive(true);
            levelCompleteEvents = true;

        }
    }

    void StartShootEvents()
    {
        if (startShootEvent)
        {
            cam.transform.position = Vector3.Slerp(cam.transform.position, newCameraPos, Time.deltaTime * 1f);
            cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, newCameraRot, Time.deltaTime * 0.4f);
            throwPen.enabled = true;
            startShootEvent = false;
            completedShootEvent = true;
        }
    }

    IEnumerator CloseBlueBackground()
    {
        blueBackground.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        blueBackground.SetActive(false);
        closeBlueBackground = true;
    }
    public void LevelFailedEvents()
    {
        if (levelFailed && !levelFailedEvents && !startShootEvent)
        {
            soundManager.PlaySound("lose");
            blackBackground.SetActive(true);
            levelFailedText.SetActive(true);
            tapToRestart.SetActive(true);
            levelFailedEvents = true;
        }
    }

    public void NextLevel()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex + 1);
    }

    public void RestartLevel()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void SetTime()
    {
        timer -= Time.deltaTime;
        second = (int)(timer % 60);
        splitSecond = (int)(timer * 60) % 60;
        timerText.text = string.Format("{00:00}:{1:00}", second, splitSecond);
        if (timer <= 0 && !levelCompleted && !startShootEvent && !closeBlueBackground)
        {
            timer = 0;
            levelFailed = true;
            startTimer = false;
            LevelFailedEvents();
        }
    }
}
