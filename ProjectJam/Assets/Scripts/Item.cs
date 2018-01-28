using UnityEngine;

public class Item : MonoBehaviour
{
    public void SetMoveState (bool on)
    {
        GetComponent<Rigidbody>().useGravity = !on;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        gameObject.layer = LayerMask.NameToLayer(on ? "Ignore Raycast" : "Default");

        for (var i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.layer = LayerMask.NameToLayer(on ? "Ignore Raycast" : "Default");
        }
    }

    public void SetVisible (bool visible)
    {
        transform.Find("Mesh").GetComponent<MeshRenderer>().enabled = visible;
    }

    public bool isVisible ()
    {
        return transform.Find("Mesh").GetComponent<MeshRenderer>().enabled;
    }
}
