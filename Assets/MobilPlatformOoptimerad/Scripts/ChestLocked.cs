using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestLocked : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator = GetComponent<Animator>();
    }
    public void ChestLockedAnim()
    {
        Debug.Log("CHEST IS LOCKED!");

        animator.SetTrigger("ChestTrigger");
    }

}
