using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace fsi.cutscene.Characters
{
    public class Character : MonoBehaviour
    {
        [Header("Moving")]
        
        [SerializeField]
        private float moveSpeed = 10f;
        
        [SerializeField]
        private float rotationSpeed = 100f;
        
        [SerializeField]
        private float stopDistance = 0.1f;

        [SerializeField]
        private string moveXParam = "MoveX";

        [SerializeField]
        private string moveZParam = "MoveZ";
        
        [SerializeField]
        private string moveParam = "Move";
        
        [Header("References")]
        
        [SerializeField]
        private Animator animator;

        [SerializeField]
        private NavMeshAgent agent;

        public void SetTrigger(string param)
        {
            if (string.IsNullOrEmpty(param))
            {
                return;
            }
            
            animator.SetTrigger(param);
        }

        public void MoveTo(Vector3 target, Action arrived = null)
        {
            agent.SetDestination(target);
            agent.isStopped = false;

            StartCoroutine(UpdateMovement(arrived));
        }

        private IEnumerator UpdateMovement(Action arrived = null)
        {
            while (agent.remainingDistance > stopDistance)
            {
                Vector3 inverse = transform.InverseTransformDirection(agent.velocity.normalized) *
                                  agent.velocity.magnitude;

                animator.SetFloat(moveXParam, inverse.x);
                animator.SetFloat(moveZParam, inverse.z);
                
                yield return null;
            }
            
            animator.SetFloat(moveXParam, 0);
            animator.SetFloat(moveZParam, 0);
            
            agent.isStopped = true;
            
            arrived?.Invoke();
        }
    }
}
