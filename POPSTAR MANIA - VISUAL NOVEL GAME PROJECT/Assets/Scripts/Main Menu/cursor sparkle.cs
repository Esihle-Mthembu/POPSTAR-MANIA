using UnityEngine;

public class CursorSparkle : MonoBehaviour
{
    public float smoothSpeed = 10f;

    void Update()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            Input.mousePosition,
            smoothSpeed * Time.deltaTime
        );
    }
}