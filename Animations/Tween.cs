using System;
using System.Collections;
using UnityEngine;

public abstract class Tween : MonoBehaviour
{
    /// <summary>
    /// Animates the transform position from initial to final state in a specified time using an animation curve. Optional completition is called when the animation is done.
    /// </summary>
    /// <param name="transform">Transform to move</param>
    /// <param name="animationCurve">Controls the animation</param>
    /// <param name="playbackTime">Duration of the animation</param>
    /// <param name="initialState">Initial Position of the Transform</param>
    /// <param name="finalState">Desired Position to move</param>
    /// <param name="completition">Optional Action called at the end of the animation</param>
    /// <returns></returns>
    public static IEnumerator Animate(Transform transform, AnimationCurve animationCurve, float playbackTime, Vector3 initialState, Vector3 finalState, Action completition = null)
    {
        float i = 0;
        float rate = 1 / playbackTime;
        while (i < 1)
        {
            i += rate * Time.deltaTime;
            transform.position = Vector3.LerpUnclamped(initialState, finalState, animationCurve.Evaluate(i));
            yield return 0;
        }
        completition?.Invoke();
    }
}