using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSword : MonoBehaviour
{

    IEnumerator activeSword()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
    void Update()
    {
        if (transform.position.y > -0.8f) transform.Translate(Vector2.down * 4f * Time.deltaTime);
        else StartCoroutine(activeSword());
    }
}
