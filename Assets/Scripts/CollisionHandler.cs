using UnityEngine;

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
                Debug.Log("You crashed");
                break;

        }
    }
}
