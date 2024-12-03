using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float lerpSpeed = 15f;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, target.position, lerpSpeed * Time.deltaTime);
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }
}
