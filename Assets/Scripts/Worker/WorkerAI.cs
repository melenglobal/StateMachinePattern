using Enums;
using UnityEngine;
using UnityEngine.AI;
using UnityTemplateProjects;
using UnityTemplateProjects.Worker;

namespace Worker
{
    public class WorkerAI
    {

        public STATE name;

        public EVENT stage;

        protected Animator anim;
        
        public Transform Gold;

        public GameObject Worker;

        protected NavMeshAgent Agent;

        public int currentScore;

        private float visibleDistance = 15.0f;
        private float visibleAngle = 60.0f;

        protected WorkerAI nextState;

        protected WorkerAI(GameObject _worker, Transform _gold,Animator _anim,NavMeshAgent _agent,int _currentScore)
        {
            Worker = _worker;
            Gold = _gold;
            anim = _anim;
            Agent = _agent;
            stage = EVENT.Enter;
            currentScore = _currentScore;
        }
        

        protected virtual void Enter()
        {
            stage = EVENT.Update;
        }

        protected virtual void Update()
        {
            stage = EVENT.Update;
        }

        protected virtual void Exit()
        {
            stage = EVENT.Exit;
        }

        public WorkerAI Process()
        {
            if (stage == EVENT.Enter)
            {
                Enter();
            }
        
            if (stage == EVENT.Update)
            {
                Update();
            }

            if (stage == EVENT.Exit)
            {
                Exit();    
                return nextState;
            }

            return this;
        }  
        
        public bool CanSeeGold()
        {
            Vector3 direction = Gold.position - Worker.transform.position;
            
            float angle = Vector3.Angle(direction, Worker.transform.forward);

            if (direction.magnitude < visibleDistance&& angle < visibleAngle)
            {
                return true;
            }
            return false;
        }

    }
}
