using UnityEngine;

public class ChestLocked : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ChestLockedAnim()
    {
        animator.SetTrigger("ChestTrigger");
    }

}
