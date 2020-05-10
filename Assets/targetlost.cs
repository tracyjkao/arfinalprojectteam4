using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetlost : MonoBehaviour
{

    public void EnableComponents()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;

    }


}
