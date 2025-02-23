using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyEffect : MonoBehaviour
{
    public float animationDuration;

    private void Start()
    {
        Destroy(gameObject, animationDuration);
    }
}
