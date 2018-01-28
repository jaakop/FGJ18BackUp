using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public void Start ()
    {
        BreakRandomPipes();
	}

    public void BreakRandomPipes()
    {
        var Pipes = new List<GameObject>(GameObject.FindGameObjectsWithTag("Solid"));
        var Indices = new List<int>();
        var Available = new List<int>();

        for (var i = 0; i < Pipes.Count; i++)
            Available.Add(i);

        for (var i = 0; i < Pipes.Count / 12; i++)
            Indices.Add(Available[Random.Range(0, Available.Count)]);

        foreach (var Index in Indices)
        {
            Pipes[Index].GetComponent<Pipe>().SetBroken();
        }
    }
}
