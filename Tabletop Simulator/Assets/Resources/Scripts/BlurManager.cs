using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SuperBlur.SuperBlurBase))]
public class BlurManager : MonoBehaviour
{

    private SuperBlur.SuperBlurBase blur;
    // Start is called before the first frame update
    void Start()
    {
        blur = GetComponent<SuperBlur.SuperBlurBase>();
    }

    // Update is called once per frame
    void Update()
    {
        blur.interpolation += 0.0001f;
    }
}
