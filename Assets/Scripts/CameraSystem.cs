using System.Collections;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
	public float interpVelocity;
    public Vector3 offset;

    public void MoveCamera(Transform newPosition)
    {
        StopAllCoroutines();

        Vector3 offsettedPosition = newPosition.position + offset;

        StartCoroutine(moveCamera(newPosition, offsettedPosition));
    }

    private IEnumerator moveCamera(Transform newPosition, Vector3 offsettedPosition)
    {
        while (transform.position != offsettedPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, offsettedPosition, interpVelocity);
            yield return null;
        }

    }
}
