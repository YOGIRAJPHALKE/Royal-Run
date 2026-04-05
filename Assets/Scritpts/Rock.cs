using UnityEngine;
using Unity.Cinemachine;

public class Rock : MonoBehaviour
{
    CinemachineImpulseSource cinemachineImpulseSource;
    Transform camTransform;

    [SerializeField] float shakeModifier = 50f;
    [SerializeField] ParticleSystem collisionParticalSystem;
    [SerializeField] AudioSource boulderSmashAudioSource;
    [SerializeField] float collisionCooldown =1f;

    float collisionTimer = 1f;

    void Awake()
    {
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
        camTransform = Camera.main.transform;
    }

    void Update() 
    {
        collisionTimer += Time.deltaTime;
        
    }

    void OnCollisionEnter(Collision other) 
    {
        if (collisionTimer < collisionCooldown)
        {
            return;
        }
        FireImpulse();
        CollisionFX(other);
        collisionTimer = 0f;
        
    }
    void FireImpulse()
    {
        float distance = Mathf.Max(Vector3.Distance(transform.position, camTransform.position), 0.1f);

        float shakeIntensity = (1f/distance) * shakeModifier;

        shakeIntensity = Mathf.Clamp(shakeIntensity, 0f, 1f);

        cinemachineImpulseSource.GenerateImpulse(shakeIntensity);

    }
    void CollisionFX(Collision other)
    {
        ContactPoint contactpoint = other.contacts[0]; 
        collisionParticalSystem.transform.position = contactpoint.point;
        collisionParticalSystem.Play();
        boulderSmashAudioSource.Play();
    }
}