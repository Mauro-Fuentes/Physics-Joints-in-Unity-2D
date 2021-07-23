using UnityEngine;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    public GameObject canvas;

    private bool isActive = false;

    private void OnPause()
    {
        ActivateCanvas(isActive);
    }

    private void ActivateCanvas(bool activate)
    {
        isActive = !isActive;
        canvas.gameObject.SetActive(activate);
    }
}
