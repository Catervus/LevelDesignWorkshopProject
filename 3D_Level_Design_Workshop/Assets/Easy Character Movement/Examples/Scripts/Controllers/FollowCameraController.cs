﻿using UnityEngine;

namespace ECM.Examples
{
    public sealed class FollowCameraController : MonoBehaviour
    {
        #region PUBLIC FIELDS

        [SerializeField]
        private Transform _targetTransform;

        [SerializeField]
        private float _distanceToTarget = 15.0f;

        [SerializeField]
        private float _followSpeed = 3.0f;

        private float currentFollowSpeed;

        [SerializeField]
        private bool lockCameraRotation = true;

        #endregion

        #region PROPERTIES

        public Transform targetTransform
        {
            get { return _targetTransform; }
            set { _targetTransform = value; }
        }

        public float distanceToTarget
        {
            get { return _distanceToTarget; }
            set { _distanceToTarget = Mathf.Max(0.0f, value); }
        }

        public float followSpeed
        {
            get { return currentFollowSpeed; }
            set { currentFollowSpeed = Mathf.Max(0.0f, value); }
        }

        private Vector3 cameraRelativePosition
        {
            get { return targetTransform.position - transform.forward * distanceToTarget; }
        }

        #endregion

        #region MONOBEHAVIOUR

        public void OnValidate()
        {
            distanceToTarget = _distanceToTarget;
            followSpeed = currentFollowSpeed = _followSpeed;
        }
        Quaternion targetrot;

        public void Start()
        {
            transform.position = cameraRelativePosition;
            targetrot = transform.rotation;
        }
        public void LateUpdate()
        {
            if (!lockCameraRotation)
                RotateCamera();

            
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.rotation = targetrot;
                transform.Rotate(0, 90, 0, Space.World);
                targetrot = transform.rotation;
                transform.Rotate(0, -90, 0, Space.World);

            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                transform.rotation = targetrot;
                transform.Rotate(0, -90, 0, Space.World);
                targetrot = transform.rotation;
                transform.Rotate(0, 90, 0, Space.World);
            }
            if (transform.rotation != targetrot)
                followSpeed = 100;
            else
                currentFollowSpeed = followSpeed;

            transform.rotation = Quaternion.Lerp(transform.rotation, targetrot, Time.deltaTime * 10);
            transform.position = Vector3.Lerp(transform.position, cameraRelativePosition, followSpeed * Time.deltaTime);
        }

        public void RotateCamera()
        {
            
        }

        #endregion
    }
}