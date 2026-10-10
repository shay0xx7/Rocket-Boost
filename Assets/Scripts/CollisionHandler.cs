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
                LoadNextlevel();
                break;

            

            default:
                reloadLevel();
                break;

        }
        
        void LoadNextlevel()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex; //Get a refrence to the current active scene
            int nextSceneIndex = currentScene +1;   // increasing the index of our current scene

            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) // cheking the number of our total scenes
            {
                nextSceneIndex = 0; //then make it to Zero
            }

            SceneManager.LoadScene(nextSceneIndex);
        }

        //Loading The current Level
        void reloadLevel()
        {   
            int currentScene = SceneManager.GetActiveScene().buildIndex; 
            SceneManager.LoadScene(currentScene);
        }
    }

    
}
