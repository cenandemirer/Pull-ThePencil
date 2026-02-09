using UnityEngine;

public class BallActiveState : BallBaseState
{
    float ballScale = 0.2f;

    public override void EnterState(Balls ball)
    {
        Color colorRandom = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        ball.GetComponent<Renderer>().material.color = colorRandom;
        float randomValue = Random.Range(0.08f, ballScale);
        ball.GetComponent<Transform>().transform.localScale = new Vector3(randomValue, randomValue, randomValue);
        ball.tag = "Active";
        ball.gameManager.activeBalls.Add(ball);
    }

    public override void OnCollisionEnter(Balls ball, Collision collision)
    {

    }

}
