using UnityEngine;

public class GateMovement : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    [SerializeField] public AudioClip clip;

    void Start()
    {
        animator = GetComponent<Animator>();
        clip = GetComponent<AudioClip>();
    }

    public void OpenGate()
    {
        animator.SetTrigger("ValveActivate");
        audioSource.PlayOneShot(clip);
    }
    
}
