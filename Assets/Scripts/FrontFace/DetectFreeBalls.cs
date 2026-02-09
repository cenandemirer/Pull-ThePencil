using UnityEngine;

public class DetectFreeBalls : MonoBehaviour
{
    public GameManager gameManager;
    bool startTimer;
    float timer;
    public int freeBallCount;

    private void Update()
    {
        if (freeBallCount >= 15)
        {
            if (!gameManager.levelFailed || !gameManager.levelCompleted)
            {
                startTimer = true;
            }
            if (gameManager.levelFailed || gameManager.levelCompleted)
            {
                startTimer = false;
            }

        }
        if (startTimer)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                gameManager.levelFailed = true;
                gameManager.LevelFailedEvents();
                startTimer = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Active"))
        {
            freeBallCount++;
        }
    }

}
