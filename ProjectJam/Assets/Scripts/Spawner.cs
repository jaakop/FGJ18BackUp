using UnityEngine;

public class Spawner : MonoBehaviour
{
    public const int MaxMice = 10;

    public GameObject Mouse;
    
	public void Start ()
    {
        Invoke("Spawn", 0);
	}
	
	public void Spawn ()
    {
        Instantiate(Mouse, transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(10, 30));
    }
}
