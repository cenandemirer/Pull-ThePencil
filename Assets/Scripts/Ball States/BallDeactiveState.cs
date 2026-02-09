using UnityEngine;

public class BallDeactiveState : BallBaseState
{
    public override void EnterState(Balls ball)
    {
        ball.GetComponent<Renderer>().material.color = Color.white;
    }

    public override void OnCollisionEnter(Balls ball, Collision collision)
    {
        if (collision.gameObject.CompareTag("Active"))
        {
            ball.TransitionToState(ball.activeState);
        }
    }
}
