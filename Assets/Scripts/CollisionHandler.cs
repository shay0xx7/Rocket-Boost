using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Hi");
                break;

            case "Finish":
                Debug.Log("Welcome");
                break;

            case "Fuel":
                Debug.Log("Why did you pick me up");
                break;

            default:
                reloadLevel();
                break;

        }

        void reloadLevel()
        {   
                int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }
    }

    
}
