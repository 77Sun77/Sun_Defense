using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reminder : MonoBehaviour
{
    void DestroyMessege()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        transform.Translate(Vector2.up * 100 * Time.deltaTime);
        Invoke("DestroyMessege", 1f);
    }
}
