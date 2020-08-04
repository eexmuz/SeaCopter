﻿using UnityEngine;
using UnityEngine.UI;

public class IndicatorUI : MonoBehaviour
{
    [SerializeField] private Image _indicatorImage;
    [SerializeField] private float _height = 6f;
    [SerializeField, Range(0, .4f)] private float _borderOffset = .1f;

    private Indicator _indicator;
    private Camera _camera;

    private void Awake() => _camera = FindObjectOfType<Camera>();

    public void SetIndicator(Indicator indicator)
    {
        _indicator = indicator;
        _indicator.OnIndicatorChanged += UpdateIndicator;
    }

    private void UpdateIndicator(float percentage) => _indicatorImage.fillAmount = percentage;

    private void LateUpdate()
    {
        Vector3 viewport = _camera.WorldToViewportPoint(_indicator.transform.position + Vector3.up * _height);
        if (viewport.y < -1 || viewport.z < 0)
        {
            Vector3 cameraRelativePos = _indicator.transform.position;
            cameraRelativePos.z = _camera.transform.position.z;
            Vector3 indicatorPos = _indicator.transform.position + Vector3.forward * Vector3.Distance(cameraRelativePos, _indicator.transform.position);
            viewport = _camera.WorldToViewportPoint(indicatorPos);
        }
        viewport.x = Mathf.Clamp(viewport.x, _borderOffset, 1 - _borderOffset);
        viewport.y = Mathf.Clamp(viewport.y, _borderOffset, 1 - _borderOffset);
        viewport.z = 0;

        transform.position = _camera.ViewportToScreenPoint(viewport);
    }
}
