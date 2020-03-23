using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDirectionScript : MonoBehaviour
{
    private Light light = null;

    private void OnEnable()
    {
        light = this.GetComponent<Light>();
    }

    private void Update()
    {
        Shader.SetGlobalVector("_LightDirection", -this.transform.forward);
    }
}
