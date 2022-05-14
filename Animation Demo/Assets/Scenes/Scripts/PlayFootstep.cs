using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFootstep : MonoBehaviour
{
    // Particle System objects
    public GameObject particles;
    public GameObject particleArea;
    public GameObject particleArea2;

    // Audio objects
    [SerializeField]
    private AudioClip[] soundEffects;
    private AudioSource audioSource;
    private Animator animator;

    // Get audio source component
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Play random footstep
    private void Footstep()
    {
        if (animator.GetBool("IsRunning") == true)
        {
            AudioClip soundEffects = GetRandomClip();
            audioSource.PlayOneShot(soundEffects);
        }
    }

    // Obtain random sound effect for Footstep() method
    private AudioClip GetRandomClip()
    {
        return soundEffects[UnityEngine.Random.Range(0, soundEffects.Length)];
    }

    // Instantiate particle system at specified gameObject location
    private void Particles()
    {
        if (animator.GetBool("IsRunning") == true)
        {
            Instantiate(particles, particleArea.transform);
            Instantiate(particles, particleArea2.transform);
        }
    }
}
