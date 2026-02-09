using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] float power;
    [SerializeField] float radius;
    [SerializeField] float upForce;
    [SerializeField] GameObject explosionParticle;
    bool explosionStarted;
    [SerializeField] Animator animator;
    SoundManager soundManager;

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Active") || collision.gameObject.CompareTag("Bomb") || collision.gameObject.CompareTag("Deactive"))
        {
            StartCoroutine(BombExplosion());
        }
    }
    IEnumerator BombExplosion()
    {
        animator.SetTrigger("canPlayTrigger");
        explosionStarted = true;
        yield return new WaitForSeconds(0.8f);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, transform.position, radius, upForce, ForceMode.Impulse);
                Instantiate(explosionParticle, transform.position, Quaternion.identity);
                soundManager.PlaySound("bomb");
                Destroy(gameObject);
                Destroy(collider.gameObject, 0.1f);
            }
        }
    }
    private void Update()
    {
        if (explosionStarted)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.22f, 0.22f, 0.22f), Time.deltaTime);
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
