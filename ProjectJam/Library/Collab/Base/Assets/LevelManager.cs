using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        BreakRandomPipes();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void BreakRandomPipes()
    {
        float amount = 0;
        float brokenPipes = 0;
        foreach (var gameObj in GameObject.FindGameObjectsWithTag("Solid"))
        {
            amount++;
        }

        while (brokenPipes <= amount / 2)
        {
            foreach (var gameObj in GameObject.FindGameObjectsWithTag("Solid"))
            {
                var r = Random.Range(0, 100);

                if (r == 1 && brokenPipes <= amount/2)
                {
                    gameObj.tag = "Objective";
                    gameObj.GetComponent<MeshRenderer>().enabled = false;
                    brokenPipes++;
                }
            }
        }
    }

}
