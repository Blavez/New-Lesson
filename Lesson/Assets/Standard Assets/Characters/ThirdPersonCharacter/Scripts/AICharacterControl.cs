using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        [SerializeField] private Rigidbody RB;
        [SerializeField] private float killForce = 5f;
        [SerializeField] private bool kill;
        [SerializeField] private bool revive;

        [SerializeField] private Rigidbody[] RbS;
        [SerializeField] private Collider[] colls;
        [SerializeField] private Animator anim;

        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;
        public Animator animatorAI;// target to aim for

        private void Awake()
        {
            anim = GetComponent<Animator>();
            RbS = GetComponentsInChildren<Rigidbody>();
            colls = GetComponentsInChildren<Collider>();
            Revive();
        }
        private void Kill()
        {
            kill = false;
            SetRagdoll(true);
            SetMain(false);
        }
        private void Revive()
        {
            revive = false;
            SetRagdoll(false);
            SetMain(true);
        }

        void SetRagdoll(bool active)
        {
            for (int i = 0; i < RbS.Length; i++)
            {
                RbS[i].isKinematic = !active;
            }
            for (int i = 0; i < colls.Length; i++)
            {
                colls[i].enabled = active;
            }
        }
        void SetMain(bool active)
        {
            anim.enabled = active;
            RbS[0].isKinematic = !active;
            colls[0].enabled = active;
        }

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
            var heading = target.transform.position - agent.transform.position;
            if (target != null)
            {
                agent.SetDestination(target.position);
                animatorAI.SetBool("Run", true);
                animatorAI.SetBool("Stop", false);

            }
            if (heading.sqrMagnitude < 2)
            {
                Kill();
            }

            if (agent.remainingDistance > agent.stoppingDistance)
            {
                character.Move(agent.desiredVelocity, false, false);
            }
            else
            {
                character.Move(Vector3.zero, false, false);
                animatorAI.SetBool("Run", false);
                animatorAI.SetBool("Stop", true);
            }
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
