using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class control : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;
        public Animator animatorAI;
        float temp;


        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            animatorAI = GetComponent<Animator>();

            agent.updateRotation = false;
            agent.updatePosition = true;
            animatorAI.applyRootMotion = true;
        }


        private void Update()
        {
            if (target != null)
            {
                agent.SetDestination(target.position);

            }


            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
            {
                character.Move(Vector3.zero, false, false);
            }
            temp += (Time.deltaTime * 0.1f);
            animatorAI.SetFloat("Blend", Mathf.Clamp(temp, 0f, 1f));
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
