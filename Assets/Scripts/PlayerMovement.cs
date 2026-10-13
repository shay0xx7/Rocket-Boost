using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thruststrength = 1000f;
    [SerializeField] float rotationstrength = 100f;
    [SerializeField] AudioClip engineSound;
    [SerializeField] ParticleSystem mainBooster;
    [SerializeField] ParticleSystem RightParticle;
    [SerializeField] ParticleSystem LeftParticle;
    

    Rigidbody rb;
    AudioSource Audio;


    private void Start()
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
        {
            StartThrusting();

        }
        else
        {
            StopThrusting();

        }
    }

    private void StartThrusting()
    {
        //adding force to the rigidbody verticely with speed and frame depencicy
        rb.AddRelativeForce(Vector3.up * thruststrength * Time.fixedDeltaTime);
        if (!Audio.isPlaying)
        {
            Audio.PlayOneShot(engineSound);
        }

        if (!mainBooster.isPlaying)
        {
            mainBooster.Play();
        }
    }

    private void StopThrusting()
    {
        Audio.Stop();
        mainBooster.Stop();
    }

    void rocketrotating()
    {
        float rotationInput = rotation.ReadValue<float>();
        if(rotationInput < 0)
        {
            RotateRight();
        }

        else if(rotationInput > 0)
        {
            RotateLeft();
        }

        else
        {
            StopRotating();
        }
    }


    private void RotateRight()
    {
        ApplyRotation(rotationstrength);
        if (!RightParticle.isPlaying)
        {
            LeftParticle.Stop();
            RightParticle.Play();
        }
    }

    private void RotateLeft()
    {
        ApplyRotation(-rotationstrength);

        if (!LeftParticle.isPlaying)
        {
            RightParticle.Stop();
            LeftParticle.Play();
        }
    }

    private void StopRotating()
    {
        RightParticle.Stop();
        LeftParticle.Stop();
    }

    void ApplyRotation(float rotatethisframe)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotatethisframe * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
}


