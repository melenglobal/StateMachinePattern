using Enums;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityTemplateProjects;
using UnityTemplateProjects.Worker;

namespace Worker
{
    public class Put : WorkerAI
    {   
        private int previousScore;
        public Put(GameObject _worker, Transform _gold, Animator _anim, NavMeshAgent _agent,int _currentScore) : base(_worker, _gold, _anim, _agent,_currentScore)
        {
            name = STATE.PUT;
        }

        
        protected override void Enter()
        {   
            Debug.Log("PUT ENTER");
            
            previousScore = currentScore;
    
            currentScore += 1 ;
            
            Worker.transform.GetChild(0).GetComponent<TextMeshPro>().text = currentScore.ToString();
            
            base.Enter();
        }

        protected override void Update()
        {
            if (currentScore > previousScore)
            {
                nextState = new Idle(Worker, Gold, anim, Agent,currentScore);
                
                stage = EVENT.Exit;
                
                Gold.gameObject.SetActive(true);

                currentScore = previousScore;

            }
            
        }

        protected override void Exit()
        {
            base.Exit();
        }
    }
}