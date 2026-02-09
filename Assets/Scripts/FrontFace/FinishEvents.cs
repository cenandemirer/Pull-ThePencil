using UnityEngine;

public class FinishEvents : MonoBehaviour
{
    public int completedBallCount;
    SoundManager soundManager;

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Active"))
        {
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            if (completedBallCount % 7 == 0)
            {
                soundManager.PlaySound("intoTheBox");
            }
            completedBallCount++;
        }
    }
}
