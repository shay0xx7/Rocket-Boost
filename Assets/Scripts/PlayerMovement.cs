using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;


    [SerializeField] float thruststrength = 1000f;
    [SerializeField] float rotationstrength = 100f;

    Rigidbody rb;
    AudioSource Audio;


    void Start()
    {
        rb = GetComponent<Rigidbody>(); // refrance the rigidbody in the object
        Audio = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        thrust.Enable(); // enable the inputs
        rotation.Enable();
    }

    void FixedUpdate()
    {   //calling functions
        movingup(); 
        rocketrotating();

        
    }

    void movingup()
    {
        if(thrust.IsPressed())
        {   //adding force to the rigidbody verticely with speed and frame depencicy
            rb.AddRelativeForce(Vector3.up * thruststrength * Time.fixedDeltaTime); 
            if(!Audio.isPlaying)
            {
                Audio.Play();
            }
           
        }
        else
        {
            Audio.Stop();
        }
    }

    void rocketrotating()
    {
        float rotationInput = rotation.ReadValue<float>();
        if(rotationInput < 0)
        {
           ApplyRotation(rotationstrength);
        }

        else if(rotationInput > 0)
        {
            ApplyRotation(-rotationstrength);
        }
    }

   void ApplyRotation(float rotatethisframe)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotatethisframe * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
}


