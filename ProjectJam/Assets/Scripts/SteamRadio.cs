using UnityEngine.SceneManagement;
using UnityEngine;

public class SteamRadio : MonoBehaviour
{
    public void Call ()
    {
        if (GameObject.FindGameObjectsWithTag("Objective").Length <= 0)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            // Notify
        }
    }
}
