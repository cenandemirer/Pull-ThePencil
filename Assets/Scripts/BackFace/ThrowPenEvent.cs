using UnityEngine;

public class ThrowPenEvent : MonoBehaviour
{
    bool canDestroyBall = true;
    public int ballAmount;
    public ThrowPen throwPen;
    private void Update()
    {
        Destroy(gameObject, 3f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Explose Ball") || collision.gameObject.CompareTag("Big Ball"))
        {
            DestroyBall(collision.gameObject);
        }
    }

    void DestroyBall(GameObject collision)
    {
        if (canDestroyBall)
        {
            Destroy(collision);
            throwPen.soundManager.PlaySound("bigBallPop");
            throwPen.ballAmount--;
            canDestroyBall = false;
        }
    }
}
