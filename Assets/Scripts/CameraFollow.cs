using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;

    private void Start()
    {

    }

    private void Update()
    {
        Vector3 transformPosition = transform.position;
        transformPosition.z = Target.position.z - 10;
        transform.position = transformPosition;
    }
}
