using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static bool isPaused = false;

    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject credits;

    private void Start()
    {
        if(menu!=null)
        isPaused = menu.activeInHierarchy;
    }

    public void Update()
    {
        if (menu != null)
        {
            CheckPause();
        }
        else
        {
            Time.timeScale = 1;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        menu.SetActive((isPaused = !isPaused));
    }

    public void StartGame()
    {
        int curScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.UnloadSceneAsync(curScene);
        SceneManager.LoadScene(curScene + 1);
    }

    public void MainMenu()
    {
        int curScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.UnloadSceneAsync(curScene);
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowCredits()
    {
        bool MM = mainMenu.activeInHierarchy;
        bool C = credits.activeInHierarchy;

        mainMenu.SetActive(!MM);
        credits.SetActive(!C);

    }

    private void CheckPause()
    {
        Time.timeScale = isPaused ? 0 : 1;
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isPaused;
    }

}

