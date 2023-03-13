using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpBar : MonoBehaviour
{
    [SerializeField] Slider jumpSlider;

    private void Start()
    {
        jumpSlider = GetComponent<Slider>();
    }

    public void SetMaxJump(float maxJump)
    {
        jumpSlider.maxValue = maxJump;
        jumpSlider.value = 0;
    }

    public void SetJump(float jump)
    {
        jumpSlider.value = jump;
    }
}
