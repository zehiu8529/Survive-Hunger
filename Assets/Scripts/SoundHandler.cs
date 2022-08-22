using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    public AudioClip walkingSound;    
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
}
