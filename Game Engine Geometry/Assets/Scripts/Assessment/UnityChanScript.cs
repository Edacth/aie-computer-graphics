using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanScript : MonoBehaviour
{
    [SerializeField]
    private Animator unityChanAnimator = default;

    void Start()
    {
        
    }

    public void TriggerJump()
    {
        unityChanAnimator.SetTrigger("Jump");
    }

    public void TriggerSlide()
    {
        unityChanAnimator.SetTrigger("Slide");
    }

    public void TriggerImpact()
    {
        unityChanAnimator.SetTrigger("Take Damage");
    }

    public void SetArmRaised(bool raised)
    {
        unityChanAnimator.SetBool("Hand Raised", raised);
    }

    public void SetMovementSpeed(float speed)
    {
        unityChanAnimator.SetFloat("Move Speed", speed);
    }
}
