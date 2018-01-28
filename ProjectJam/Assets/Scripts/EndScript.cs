using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScript : MonoBehaviour {

   public TextMeshProUGUI dialog;
    public GameObject thanks;
    [SerializeField]
    private float newTime = 10;
    private float timer = 0;
    private int dialogNo = 0;

	void Start () {
        dialog.GetComponent<TextMeshProUGUI>();
        timer = newTime;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(timer);
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (dialogNo == 0)
            {
                dialog.SetText("Hello, they call me BOB.");
                timer = 10f;
                dialogNo++;
            }else if(dialogNo == 1)
            {
                dialog.SetText("It seems that you have repaired this small factory.");
                timer = 10f;
                dialogNo++;
            }
            else if (dialogNo == 2)
            {
                dialog.SetText("You know, for a reason, it was never ment to be repaired?");
                timer = 10f;
                dialogNo++;
            }else if(dialogNo == 3)
            {
                dialog.SetText("");
                thanks.SetActive(true);
            }
        }
	}
}
