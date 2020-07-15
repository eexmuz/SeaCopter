﻿using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private bool _followX;
    [SerializeField] private bool _followY;
    [SerializeField] private bool _followZ;
    [SerializeField] private bool _followXRotation;
    [SerializeField] private bool _followYRotation;
    [SerializeField] private bool _followZRotation;
    [SerializeField] private Vector3 _positionOffset;
    [SerializeField] private Vector3 _rotationOffset;

    private Transform _transform;

    private void Awake() => _transform = transform;

    private void Update()
    {
        Vector3 targetPosition = _target.position + _positionOffset;
        Vector3 targetRotation = _target.eulerAngles + _rotationOffset;

        if (!_followX)
            targetPosition.x = _transform.position.x;
        if (!_followY)
            targetPosition.y = _transform.position.y;
        if (!_followZ)
            targetPosition.z = _transform.position.z;

        if (!_followXRotation)
            targetRotation.x = _transform.eulerAngles.x;
        if (!_followYRotation)
            targetRotation.y = _transform.eulerAngles.y;
        if (!_followZRotation)
            targetRotation.z = _transform.eulerAngles.z;

        _transform.position = targetPosition;
        _transform.rotation = Quaternion.Euler(targetRotation);
    }
}
