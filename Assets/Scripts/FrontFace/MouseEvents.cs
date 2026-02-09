using UnityEngine;

public class MouseEvents : MonoBehaviour
{
    Camera cam;
    RaycastHit hit;
    SoundManager soundManager;
    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        cam = GetComponent<Camera>();
    }
    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Pencil"))
            {
                PencilMove pencilMove = hit.collider.gameObject.GetComponent<PencilMove>();
                pencilMove.pencilCanMove = true;
                pencilMove.hit = hit;
                soundManager.PlaySound("pencilMove");
            }
        }
    }

}
