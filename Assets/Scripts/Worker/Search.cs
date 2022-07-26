using UnityEngine;
using UnityEngine.AI;
using UnityTemplateProjects;
using CheckPoints;
using UnityTemplateProjects.Worker;

namespace Worker
{
    public class Search: WorkerAI
    {
        private int currentIndex = -1;

  
        public Search(GameObject _worker, Transform _gold, Animator _anim, NavMeshAgent _agent,int _currentScore) : base(_worker, _gold, _anim, _agent,_currentScore)
        {
            name = STATE.SEARCH;
            Agent.speed = 5;
        }

        protected override void Enter()
        {   
            Debug.Log("SEARCH ENTER!");
            float lastDist = Mathf.Infinity;
            for (int i = 0; i < GameEnvironment.Singleton.Checkpoints.Count; i++)
            {
                GameObject thisWayPoint = GameEnvironment.Singleton.Checkpoints[i];
                float distance = Vector3.Distance(Worker.transform.position, thisWayPoint.transform.position);
                if (distance < lastDist)
                {
                    currentIndex = i - 1;
                    lastDist = distance;
                }
            }
            // anim.SetTrigger("isWalking");
            base.Enter();
        }

        protected override void Update()
        {   
            if (Agent.remainingDistance < 1)
            {
                if (currentIndex >= GameEnvironment.Singleton.Checkpoints.Count - 1)
                    currentIndex = 0;
                else
                    currentIndex++;

                Agent.SetDestination(GameEnvironment.Singleton.Checkpoints[currentIndex].transform.position);
                
            }

            if (CanSeeGold())
            {
                nextState = new GoNear(Worker, Gold, anim, Agent,currentScore);
                stage = EVENT.EXIT;
            }
        }

        protected override void Exit()
        {
            //anim.ResetTrigger("isWalking");
            base.Exit();
        }
    }
}