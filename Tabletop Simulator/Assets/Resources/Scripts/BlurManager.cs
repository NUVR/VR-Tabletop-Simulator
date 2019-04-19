using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SuperBlur.SuperBlurBase))]
public class BlurManager : MonoBehaviour
{

    [SerializeField]
    GameManager manager;

    private SuperBlur.SuperBlurBase blur;
    private float blurToApply;

    // Start is called before the first frame update
    void Start()
    {
        blur = GetComponent<SuperBlur.SuperBlurBase>();
        blurToApply = 0f;
        manager.IncreaseBlur = OnBlur;
    }

    // Update is called once per frame
    void Update()
    {
        ApplyBlur();
    }

    void ApplyBlur()
    {
        if (blurToApply <= 0f)
        {
            blurToApply = 0f;
            return;
        }

        // In seconds
        float TIME_TO_COMPLETE = 20;
        float frameBlur = blurToApply / (25 * TIME_TO_COMPLETE);

        float FLOAT_OFF_THRESHOLD = 0.000001f;
        if (frameBlur < FLOAT_OFF_THRESHOLD)
        {
            frameBlur = FLOAT_OFF_THRESHOLD;
        }
        blurToApply -= frameBlur;
        blur.interpolation += frameBlur;
    }

    void OnBlur()
    {
        blurToApply += 0.1f;
    }
}
