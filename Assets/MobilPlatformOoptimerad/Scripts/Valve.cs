using UnityEngine;

public class Valve : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TurnValve()
    {
        animator.SetTrigger("ValveTrigger");
    }
}
