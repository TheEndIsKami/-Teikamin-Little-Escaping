using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Vector3 initPos;
    // Start is called before the first frame update

    public void Play(float shakeMagnitude, float shakeDuration)
    {
        initPos = transform.position;
        StartCoroutine(Shake(shakeMagnitude, shakeDuration));
    }

    IEnumerator Shake(float shakeMagnitude, float shakeDuration)
    {
        float elapsedTime = 0;
        while (elapsedTime < shakeDuration)
        {
            transform.position = initPos + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initPos;
    }
}
