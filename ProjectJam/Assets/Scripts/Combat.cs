using UnityEngine;

public class Combat : MonoBehaviour
{
    public const float MaxHitDistance = 10;
    public Animator animator;
	
	public void Update ()
    {
		if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Hit");
            RaycastHit hit;
            
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit) && hit.distance <= MaxHitDistance && hit.transform.tag == "Mouse")
            {
                hit.transform.GetComponent<Mouse>().ApplyDamage(5);
            }
        }
	}
}
