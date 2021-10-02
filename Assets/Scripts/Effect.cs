using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    float offTime;
    public void UseEffect(float offTime)
    {
        gameObject.SetActive(true);
        this.offTime = offTime;
        StartCoroutine(EffectOff());
    }
    private void OnEnable()
    {
        
    }
    IEnumerator EffectOff()
    {
        yield return new WaitForSeconds(offTime);
        gameObject.SetActive(false);
    }
}
