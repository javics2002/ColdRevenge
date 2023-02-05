using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimationController : MonoBehaviour
{
    Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float prob = Random.Range(0f, 1f);

        if (prob < 0.0001f)
        {
            animator.SetBool("boredAnimation", true);
            Invoke("exitBoredAnimation", 0.8f);
        }
    }

    void exitBoredAnimation()
    {
        animator.SetBool("boredAnimation", false);
    }

    public void startTalkingAnim()
    {
        animator.SetBool("talkingAnimation", true);
    }

    public void stopTalkingAnim()
    {
        animator.SetBool("talkingAnimation", false);
    }
}
