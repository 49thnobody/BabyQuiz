using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public static class Utils
{
    public static IEnumerator Wait(float seconds, UnityAction callback = null)
    {
        yield return new WaitForSeconds(seconds);

        callback?.Invoke();
    }
}