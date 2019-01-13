using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectRatioFixer : MonoBehaviour
{
    private Camera myCamera;

	void Start ()
    {
        myCamera = GetComponent<Camera>();
        float newAspectRatio = 2.055555555555556f;

        var variance = newAspectRatio / myCamera.aspect;
        if (variance < 1.0)
        {
            myCamera.rect = new Rect((1.0f - variance) / 2.0f, 0, variance, 1.0f);
        }
        else
        {
            variance = 1.0f / variance;
            myCamera.rect = new Rect(0, (1.0f - variance) / 2.0f, 1.0f, variance);
        }
    }
}
