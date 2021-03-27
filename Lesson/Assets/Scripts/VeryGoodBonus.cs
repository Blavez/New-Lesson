using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
namespace Geekbrains
{
    public sealed class VeryGoodBonus : InteractiveObject, IFlay, IFlicker
    {
        private float _lengthFlay;
        static int value;

        private void Awake()
        {
            _lengthFlay = Random.Range(1.0f, 5.0f);
        }

        protected override void Interaction()
        {
            FirstPersonController.m_RunSpeed = 20;
        }
        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Flicker()
        {

        }


    }
}