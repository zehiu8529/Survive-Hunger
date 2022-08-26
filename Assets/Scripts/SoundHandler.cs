using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    [SerializeReference] AudioClip walkingSound;
    [SerializeReference] AudioClip clearedSound;
    [SerializeReference] AudioClip replenishSound;
    [SerializeReference] AudioClip explodeSound;
    AudioSource audioSource;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get audio source component from game object
    }

    /// <summary>
    /// Play walking sound
    /// </summary>
    /// <param name="walkRate"></param>
    public void PlayWalkingSound(float walkRate)
    {
        if (Time.time >= timer)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                audioSource.PlayOneShot(walkingSound);
                timer = Time.time + 1 / walkRate;
            }
        }
    }   

    public void PlayClearedStageSound()
    {
        PlaySound(clearedSound);
    }

    public void PlayReplenishSound()
    {
        PlaySound(replenishSound);
    }

    public void PlayExplodeOnDeathSound()
    {
        PlaySound(explodeSound);
    }

    void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
