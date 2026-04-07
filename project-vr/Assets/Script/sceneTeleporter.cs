using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneTeleporter : MonoBehaviour
{
    public void GoToLevel1()
    {
        SceneManager.LoadScene("Level 1 House");
    }
}