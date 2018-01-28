using UnityEngine;
using TMPro;

public class EndScript : MonoBehaviour
{

    public TextMeshProUGUI dialog;
    public GameObject thanks;
    public AudioSource player;
    public AudioClip[] clips;

    [SerializeField]
    private float duration = 5;

    private float time = 0;
    private int index = 0;

	public void Start ()
    {
        time = 8;
	}
	
	public void Update ()
    {
        if ((time -= Time.deltaTime) <= 0)
        {
            switch (index++)
            {
                case 0:
                    dialog.SetText("Hello, they call me BOB.");
                    player.PlayOneShot(clips[0]);
                    break;
                case 1:
                    dialog.SetText("It seems that you have repaired this small factory.");
                    player.PlayOneShot(clips[1]);
                    break;
                case 2:
                    dialog.SetText("You know, for a reason, it was never ment to be repaired?");
                    player.PlayOneShot(clips[2]);
                    break;
                case 3:
                    dialog.SetText("");
                    thanks.SetActive(true);
                    return;
            }

            time = duration;
        }
	}
}
