using UnityEngine;

public class SpringSystem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Entered");
    }
}
