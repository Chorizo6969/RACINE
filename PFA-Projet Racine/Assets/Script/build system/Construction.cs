using UnityEngine;

public class Construction : MonoBehaviour
{
    public Animator animator;

    public void AnimationBuild()
    {
        animator.Play("Base Layer.Construction", 0, 0.25f);
    }
}