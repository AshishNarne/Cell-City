using UnityEngine;

public class LowerArmsPose : MonoBehaviour
{
    public float armDropDegrees = 35f;

    Animator animator;
    Transform leftUpperArm;
    Transform rightUpperArm;
    Quaternion leftStart;
    Quaternion rightStart;

    void Awake()
    {
        animator = GetComponent<Animator>();
        if (animator != null)
            animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;

        foreach (var smr in GetComponentsInChildren<SkinnedMeshRenderer>(true))
            smr.updateWhenOffscreen = true;
    }

    void Start()
    {
        if (animator == null) return;

        leftUpperArm = animator.GetBoneTransform(HumanBodyBones.LeftUpperArm);
        rightUpperArm = animator.GetBoneTransform(HumanBodyBones.RightUpperArm);

        if (leftUpperArm != null) leftStart = leftUpperArm.localRotation;
        if (rightUpperArm != null) rightStart = rightUpperArm.localRotation;
    }

    void LateUpdate()
    {
        if (leftUpperArm != null)
            leftUpperArm.localRotation = leftStart * Quaternion.Euler(0f, 0f, -armDropDegrees);

        if (rightUpperArm != null)
            rightUpperArm.localRotation = rightStart * Quaternion.Euler(0f, 0f, armDropDegrees);
    }
}