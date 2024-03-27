using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CarSFXHandler : MonoBehaviour
{
    [Header("Mixers")]
    public AudioMixer audioMixer;

    [Header("Audio sources")]
    public AudioSource tiresScreeachingAudioSource;
    public AudioSource engineAudioSource;
    public AudioSource carHitAudioSource;
    public AudioSource carJumpAudioSource;
    public AudioSource carJumpLandingAudioSource;

    // Local variables
    float desiredEnginePitch = 0.5f;
    float tireScreechPitch = 0.5f;

    // Components
    TopDownCarController topDownCarController;

    // Awake is called when the script instance is being loaded.
    void Awake()
    {
        // Get the reference to the TopDownCarController component in the parent object
        topDownCarController = GetComponentInParent<TopDownCarController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Example for recording, move this part to any setting script that your game might use.
        // Set the SFX volume to 0.5
        audioMixer.SetFloat("SFXVolume", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        // Update engine sound effects
        UpdateEngineSFX();
        // Update tire screeching sound effects
        UpdateTiresScreechingSFX();
    }

    void UpdateEngineSFX()
    {
        // Handle engine sound effects
        // Get the magnitude of the car's velocity
        float velocityMagnitude = topDownCarController.GetVelocityMagnitude();

        // Increase the engine volume as the car goes faster
        float desiredEngineVolume = velocityMagnitude * 0.05f;

        // Keep a minimum volume level even if the car is idle
        desiredEngineVolume = Mathf.Clamp(desiredEngineVolume, 0.2f, 1.0f);

        // Smoothly change the engine volume over time
        engineAudioSource.volume = Mathf.Lerp(engineAudioSource.volume, desiredEngineVolume, Time.deltaTime * 10);

        // To add more variation to the engine sound, change the pitch based on the car's velocity
        desiredEnginePitch = velocityMagnitude * 0.2f;
        desiredEnginePitch = Mathf.Clamp(desiredEnginePitch, 0.5f, 2f);

        // Smoothly change the engine pitch over time
        engineAudioSource.pitch = Mathf.Lerp(engineAudioSource.pitch, desiredEnginePitch, Time.deltaTime * 1.5f);
    }
    void UpdateTiresScreechingSFX()
    {
        // Handle tire screeching sound effects

        // Check if the car is experiencing tire screeching
        if (topDownCarController.IsTireScreeching(out float lateralVelocity, out bool isBraking))
        {
            // If the car is braking, increase the volume and change the pitch of the tire screech
            if (isBraking)
            {
                tiresScreeachingAudioSource.volume = Mathf.Lerp(tiresScreeachingAudioSource.volume, 1.0f, Time.deltaTime * 10);
                tireScreechPitch = Mathf.Lerp(tireScreechPitch, 0.5f, Time.deltaTime * 10);
            }
            else
            {
                // If we are not braking, play a screech sound while drifting based on the lateral velocity
                tiresScreeachingAudioSource.volume = Mathf.Abs(lateralVelocity) * 0.05f;
                tireScreechPitch = Mathf.Abs(lateralVelocity) * 0.1f;
            }
        }
        // Fade out the tire screech sound effect if no screeching is occurring
        else
        {
            tiresScreeachingAudioSource.volume = Mathf.Lerp(tiresScreeachingAudioSource.volume, 0, Time.deltaTime * 10);
        }
    }

    public void PlayJumpSfx()
    {
        // Play the car jump sound effect
        carJumpAudioSource.Play();
    }

    public void PlayLandingSfx()
    {
        // Play the car landing sound effect
        carJumpLandingAudioSource.Play();
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        // Get the relative velocity of the collision
        float relativeVelocity = collision2D.relativeVelocity.magnitude;

        // Calculate the volume based on the relative velocity
        float volume = relativeVelocity * 0.1f;

        // Randomize the pitch of the car hit sound effect slightly
        carHitAudioSource.pitch = Random.Range(0.95f, 1.05f);

        // Set the volume of the car hit sound effect
        carHitAudioSource.volume = volume;

        // Play the car hit sound effect if it's not already playing
        if (!carHitAudioSource.isPlaying)
        {
            carHitAudioSource.Play();
        }
    }
}