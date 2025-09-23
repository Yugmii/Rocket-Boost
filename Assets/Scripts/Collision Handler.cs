using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Everything is looking good!");
                break;

            case "Finish":
                Debug.Log("You landed! WOHOOO, Welcome to our country buddy!! ");
                break;

            default:
                ReloadLevel();
                break;
        }
    }

    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    

}
