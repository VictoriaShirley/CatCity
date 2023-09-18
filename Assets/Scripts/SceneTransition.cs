using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void LoadStorieScene()
    {
        SceneManager.LoadScene("Storie"); 
    }
    
    public void LoadGameScene()
    {
        SceneManager.LoadScene("SampleScene"); 
    }

     public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu"); 
    }
}

