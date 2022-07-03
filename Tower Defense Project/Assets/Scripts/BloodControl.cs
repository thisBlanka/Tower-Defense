using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodControl : MonoBehaviour
{
    private Animator animator;
    private float duration;
    private Transform child;

    void Start()
    {
        animator = GetComponent<Animator>();
        duration = Random.Range(.2f, .5f);
        child = this.transform;
        child.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("stopAnimationPlayback", duration);
    }

    private void stopAnimationPlayback()
    {
        animator.speed = 0;
    }

}
