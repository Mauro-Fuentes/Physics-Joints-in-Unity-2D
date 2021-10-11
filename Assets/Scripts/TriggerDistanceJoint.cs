using UnityEngine;

public class TriggerDistanceJoint : MonoBehaviour
{
    public bool activate;
    public GameObject target;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(activate)
        {
            var a = other.GetComponent<DistanceJoint2D>();
            a.enabled = true;
            a.connectedBody = target.GetComponent<Rigidbody2D>();
        }
        else
        {
            var a = other.GetComponent<DistanceJoint2D>();
            a.connectedBody = null; 
            a.enabled = false;
        }

    }
}
