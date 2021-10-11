using UnityEngine;

public class MouseDragMovement : MonoBehaviour
{
    private Vector3 OffsetToObject;

    private float depthToObject;

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + OffsetToObject;
    }

    private void OnMouseDown()
    {
        depthToObject = Camera.main.WorldToScreenPoint( gameObject.transform.position).z;

        OffsetToObject = gameObject.transform.position - GetMouseWorldPosition();
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;

        mousePosition.z = depthToObject;

        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

}
