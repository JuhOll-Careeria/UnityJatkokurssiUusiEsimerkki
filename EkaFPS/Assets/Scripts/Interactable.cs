using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Interactable : MonoBehaviour
{
    public string interactableName;
    public AudioClip onInteractClip;
    public UnityEvent interactEvents;

    AudioSource AS;

    private void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    public void OnInteract()
    {
        interactEvents.Invoke();

        // tarkistus onko onInteractClip:i‰ annettu vai ei,
        // Jos on niin toistetaan interaction ‰‰nieffekti
        if (onInteractClip != null)
            AS.PlayOneShot(onInteractClip); // Toistaa kerran Audiosourcesta annetun klipin
    }
}
