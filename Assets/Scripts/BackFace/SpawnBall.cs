using System.Collections;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] GameObject bigBallPrefab;
    [SerializeField] ThrowPen throwPen;
    public SoundManager soundManager;
    [SerializeField] GameObject blueBackground;
    float boundariesX = 2.3f;
    float boundariesY = 3.35f;
    float posZ = 0.4f;
    float bigBallPosZ = 2.148419f;
    [SerializeField]
    int ballAmount;
    public bool canSpawnSmallBall;
    public bool spawnCompleted;
    public bool startCoroutine;

    private void Start()
    {
        BigBallSpawner();
    }

    public void BigBallSpawner()
    {
        float randomPosX = Random.Range(-boundariesX + 2, boundariesX - 2);
        float randomPosY = Random.Range(-boundariesY + 2, boundariesY - 2);
        Vector3 randomSpawnPos = new Vector3(randomPosX, randomPosY, bigBallPosZ);
        GameObject ball = Instantiate(bigBallPrefab, randomSpawnPos, Quaternion.identity) as GameObject;
        ball.GetComponent<BigBallBack>().spawnBall = GetComponent<SpawnBall>();
    }
    public void SmallBallSpawner()
    {
        ballAmount = Random.Range(5, 10);
        canSpawnSmallBall = true;

        for (int i = 0; i < ballAmount; i++)
        {
            float randomPosX = Random.Range(-boundariesX, boundariesX);
            float randomPosY = Random.Range(-boundariesY, boundariesY);
            Vector3 randomSpawnPos = new Vector3(randomPosX, randomPosY, posZ);
            GameObject ball = Instantiate(ballPrefab, randomSpawnPos, Quaternion.identity) as GameObject;
            Color randomColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            ball.GetComponent<Renderer>().material.color = randomColor;
            ball.transform.parent = transform;
            throwPen.ballAmount = transform.childCount;
        }
    }
}
