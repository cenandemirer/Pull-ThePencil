using UnityEngine;

public class BigBall : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    int ballAmount;
    [SerializeField] GameManager gameManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Active"))
        {
            gameManager.soundManager.PlaySound("ballonBurst");
            Destroy(gameObject);
            ballAmount = Random.Range(10, 20);
            for (int i = 0; i < ballAmount; i++)
            {
                GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity) as GameObject;
                ball.GetComponent<Balls>().gameManager = gameManager;
                Vector3 ballPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                ball.transform.position = ballPos;
            }
        }
    }
}
