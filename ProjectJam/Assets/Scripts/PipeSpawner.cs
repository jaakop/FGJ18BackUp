using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public Transform Spawnpoint;
    public GameObject Pipe;

    public void Spawn ()
    {
        var pipe = Instantiate(Pipe, Spawnpoint.position + Random.insideUnitSphere * 0.5f, Random.rotation);
        pipe.name = "Pipe";
    }
}
