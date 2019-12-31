using System;
using System.Collections;
using UnityEngine;

public static class UnityUtils
{
    public static IEnumerator DelayedAction(float time, Action action)
    {
        yield return new WaitForSecondsRealtime(time);
        action?.Invoke();
    }

    public static IEnumerator FreezeTime(float time, Action setup = null, Action completition = null)
    {
        setup?.Invoke();
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(time);
        Time.timeScale = 1;

        completition?.Invoke();
    }

}
