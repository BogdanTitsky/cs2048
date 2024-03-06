using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigateTo : MonoBehaviour
{
    public void LoadTo(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
