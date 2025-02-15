using UnityEngine;

public class MalletController : MonoBehaviour
{
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        transform.position = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
    }
}