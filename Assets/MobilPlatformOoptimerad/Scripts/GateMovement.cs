using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateMovement : MonoBehaviour
{

    //[SerializeField] private Animation anim;
    //[SerializeField] private AnimationClip clip;
    public Animator animator;
    public AudioSource audioSource;
    [SerializeField] public AudioClip clip;

    void Start()
    {
        animator = GetComponent<Animator>();
        clip = GetComponent<AudioClip>();
    }

    void Update()
    {
        
    }
    public void OpenGate()
    {
        Debug.Log("skriptet opengate körs");
        audioSource.PlayOneShot(clip);
        animator.SetTrigger("ValveActivate");
                
    }
    
}
