using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private bool isShake;
    public void StartShake(float duration, float strength)
    {
        if (!isShake)
        {
            StartCoroutine(Shake(duration,strength));
        }
    }
    IEnumerator Shake(float duaration, float strength)
    {
        isShake = true;
        Transform camera = this.transform;
        Vector3 startPosition = camera.position;

        while (duaration > 0)
        {
            camera.position = Random.insideUnitSphere * strength + startPosition;
            duaration -= Time.deltaTime;
            yield return null;
        }

        camera.position = startPosition;
        isShake = false;
    }
}
