using UnityEngine;

public class GunHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject gun;
    [SerializeField]
    private GameObject hitMarker;
    [SerializeField]
    private Animator animator; 

    private bool using_gun = false;

    [SerializeField]
    private GameObject player;

    public void PlayGunAnimation ()
    {
        animator.SetTrigger("Shot");
    }
	
	public void Update ()
    {
        player.GetComponent<ItemHandler>().Gun = using_gun;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gun.SetActive((using_gun = !using_gun));
        }

        if (Input.GetMouseButtonDown(0) && using_gun)
        {
            PlayGunAnimation();
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
            {
                if (hit.transform.tag == "Mouse")
                {
                    hit.transform.GetComponent<Mouse>().ApplyDamage(10);
                }
                else
                {
                    Instantiate(hitMarker, hit.point + hit.normal * Physics.defaultContactOffset, Quaternion.LookRotation(hit.normal)).transform.parent = hit.transform;
                }
            }
        }
	}
}
