using UnityEngine;
using System.Collections;
using System;

public class AnimationController : MonoBehaviour
{
    [Header("Animation Curves for Tweening")]
    public AnimationCurve poppingAnimationCurve;
    public AnimationCurve collapseAnimationCurve;
    public AnimationCurve movementAnimationCurve;

    [Space]
    [Header("Speed of the Tweening")]
    public float poppingOutSpeed;
    public float collapseSpeed;
    public float treeMovementSpeed;

    /// <summary>
    /// Tween the transform to perform a popping out animation and after a movement animation to the specified position
    /// </summary>
    /// <param name="transform">Transform to animate</param>
    /// <param name="initialPosition">Initial position of the transform</param>
    /// <param name="finalPosition">Final position of the Transform</param>
    /// <param name="completition">Action to be executed at the end</param>
    public void PoppingOutAnimation(Transform transform, Vector3 initialPosition, Vector3 finalPosition, Action completition)
    {
        StartCoroutine(Tween.Animate(transform, poppingAnimationCurve, poppingOutSpeed, initialPosition, finalPosition, () => MoveTree(transform, transform.position, Vector3.zero, completition)));
    }

    /// <summary>
    /// Tween the transform to perform a Collapse animation
    /// </summary>
    /// <param name="transform">Transform to animate</param>
    /// <param name="initialPosition">Initial position of the transform</param>
    /// <param name="finalPosition">Final position of the Transform</param>
    public void CollapseAnimation(Transform transform, Vector3 initialPosition, Vector3 finalPosition)
    {
        StartCoroutine(Tween.Animate(transform, collapseAnimationCurve, collapseSpeed, initialPosition, finalPosition));
    }

    /// <summary>
    /// Animate the movement of the transform to target position
    /// </summary>
    /// <param name="transform">Transform to animate</param>
    /// <param name="initialPosition">Initial position of the transform</param>
    /// <param name="finalPosition">Desired Position</param>
    /// <param name="completition">Action to be executed at the end</param>
    public void MoveTree(Transform transform, Vector3 initialPosition, Vector3 finalPosition, Action completition)
    {
        StartCoroutine(Tween.Animate(transform, movementAnimationCurve, treeMovementSpeed, initialPosition, finalPosition, completition));
    }
}
