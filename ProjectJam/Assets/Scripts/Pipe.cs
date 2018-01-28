using UnityEngine;

public class Pipe : MonoBehaviour
{
    public const int FullHealth = 50;

    private float Health = FullHealth;

    public void SetBroken ()
    {
        tag = "Objective";
        GetComponent<MeshRenderer>().enabled = false;
        transform.parent.Find("Highlight").gameObject.SetActive(false);

        Camera.main.transform.GetComponent<ItemHandler>().SetSteamPlaying(true);
    }

    public bool isBroken ()
    {
        return tag == "Objective";
    }

	public void SetPreviewVisible (bool on)
    {
        GetComponent<MeshRenderer>().enabled = false;
        transform.parent.Find("Highlight").gameObject.SetActive(on);
    }

    public void SetFixed ()
    {
        tag = "Solid";
        Health = FullHealth;
        GetComponent<MeshRenderer>().enabled = true;
        transform.parent.Find("Highlight").gameObject.SetActive(false);
    }

    public void ApplyDamage (float damage)
    {
        if ((Health -= damage) <= 0)
        {
            Health = 0;
            SetBroken();
        }
    }
}
