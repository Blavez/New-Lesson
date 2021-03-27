using UnityEngine;
using Random = UnityEngine.Random;

namespace Geekbrains
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable, IInitialization
    {
        public bool IsInteractable { get; }
        protected abstract void Interaction();

        private void Start()
        {
            ((IAction)this).Action();
            ((IInitialization)this).Action();
        }

        void IAction.Action()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Random.ColorHSV();
            }
        }

        void IInitialization.Action()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Color.cyan;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }
            Destroy(gameObject);
            Interaction();
           
        }

    }
}