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

        //Loading The current Level
        void reloadLevel()
        {   
            int currentScene = SceneManager.GetActiveScene().buildIndex; //Get a refrence to the current active scene
            SceneManager.LoadScene(currentScene); //loading the current scene
        }
    }

    
}
