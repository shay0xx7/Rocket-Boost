using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip winSound;
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem winParticles;
    AudioSource Audio;

    bool isControllable = true;
    bool iscolliadable = true;


   private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
         RespondToDebugKeys();
        
    }

    void RespondToDebugKeys()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            LoadNextlevel();
        }

        else if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            iscolliadable = !iscolliadable;
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (!isControllable || !iscolliadable)
        {
            return;
        }
        
        switch (collision.gameObject.tag)
        {   
            
             case "Friendly":
                Debug.Log("hey");
                break;
                
             case "Finish":
                StartSuccessSequence();
                break;
                
            default:
                StartCrashSequence();
                break;
        }
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
    
    
    void StartSuccessSequence()
    {   
        isControllable = false;
        Audio.Stop();
        Audio.PlayOneShot(winSound);
        winParticles.Play(winParticles);
        GetComponent<PlayerMovement>().enabled = false;
        Invoke("LoadNextlevel",levelLoadDelay); //adding a delay    
    }


    void StartCrashSequence()
    {   
        Audio.Stop();
        isControllable = false;
        Audio.PlayOneShot(crashSound);
        winParticles.Play(crashParticles);
        GetComponent<PlayerMovement>().enabled = false;
        Invoke("reloadLevel",levelLoadDelay);
    }
    
}
