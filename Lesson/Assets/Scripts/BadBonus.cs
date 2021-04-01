using UnityEngine;
using System;
using System.IO;
using UnityStandardAssets.Characters.FirstPerson;


namespace Geekbrains
{
    public sealed class BadBonus : InteractiveObject, IFlay, IRotation
    {
        private float _lengthFlay;
        private float _speedRotation;

        public delegate void CaughtPlayerChange();
        public event CaughtPlayerChange CaughtPlayer;

        private void Add(CaughtPlayerChange f) 
        {
            CaughtPlayer += f;
        } 
        private void Awake()
        {
            CameraShake method = new CameraShake();
            _lengthFlay = UnityEngine.Random.Range(1.0f, 5.0f);
            _speedRotation = UnityEngine.Random.Range(10.0f, 50.0f);
            Add(method.CaughtPlayer2);
            Add(method.Test);

        }
        protected override void Interaction()
        {
            try
            {
                FirstPersonController.m_RunSpeed = 3;
                CaughtPlayer?.Invoke();
            }

            catch (Exception exc) 
            {
                Debug.Log("Неизвестная ошибка");
            }
        }
        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }
    }
}
