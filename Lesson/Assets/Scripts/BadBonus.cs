using UnityEngine;
using System;
using System.IO;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;


namespace Geekbrains
{
    public sealed class BadBonus : InteractiveObject, IFlay, IRotation
    {
        private Restart _restart;
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
           
                FirstPersonController.m_RunSpeed = 3;
                CaughtPlayer?.Invoke();
                _restart.RestartButton.gameObject.SetActive(true);
                _restart.RestartButton.onClick.AddListener(RestartGame);
        }
        private void RestartGame()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1.0f;
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
