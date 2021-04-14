using UnityEngine;
using UnityEngine.SceneManagement;

namespace Geekbrains
{
    public sealed class GoodBonus : InteractiveObject, IFlay, IFlicker
    {
        private Material _material;
        private float _lengthFlay;
        static int value;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFlay = Random.Range(1.0f, 5.0f);
        }
        protected override void Interaction()
        {
            value++;
            Debug.Log(value);
            if (value == 3)
            {
                Debug.Log("Вы набрали необходимое кол-во очков для победы");
                SceneManager.LoadScene(0);
                value = 0;
            }

        }
        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Flicker()
        {
                Mathf.PingPong(Time.time, 1.0f);
        }


}
}