using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class IKControl : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    private RaycastHit hit;
    protected Animator animator;

    public bool ikActive = false;
    public Transform rightHandObj = null;
    public Transform lookObj = null;
    public Transform leftHandObj = null;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var distanceOfRay = 100;
        var hitDirection = (lookObj.transform.position - transform.position).normalized;
        if (Physics.Raycast(transform.position, hitDirection, out hit))
        {


            Debug.DrawRay(transform.position, hitDirection * distanceOfRay, Color.red);
        }

    }
    //Вызывается при расчёте IK
    void OnAnimatorIK()
    {
        if (animator)
        {

            //Если, мы включили IK, устанавливаем позицию и вращение
            if (ikActive)
            {

                // Устанавливаем цель взгляда для головы


                // Устанавливаем цель для правой руки и выставляем её в позицию
                if (rightHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
                }
                
                if (leftHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.rotation);
                }
                if ((lookObj != null)&& hit.distance < 5)
                {
                    animator.SetLookAtWeight(1);
                    animator.SetLookAtPosition(lookObj.position);
                }
                else
                {
                    animator.SetLookAtWeight(0);
                }


            }

            // Если IK неактивен, ставим позицию и вращение рук и головы в изначальное положение
            else
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
            }
        }
    }
}
