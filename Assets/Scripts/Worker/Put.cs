using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityTemplateProjects;

namespace Worker
{
    public class Put : WorkerAI
    {   
        int previousScore;
        public Put(GameObject _worker, Transform _gold, Animator _anim, NavMeshAgent _agent,int _currentScore) : base(_worker, _gold, _anim, _agent,_currentScore)
        {
            
        }

        
        protected override void Enter()
        {   
            Debug.Log("PUT ENTER");
            
            previousScore = currentScore;
            Debug.Log(currentScore);
            Debug.Log(previousScore);
            currentScore += 1 ;
            Worker.transform.GetChild(0).GetComponent<TextMeshPro>().text = currentScore.ToString();
            base.Enter();
        }

        protected override void Update()
        {
            if (currentScore > previousScore)
            {
                nextState = new Idle(Worker, Gold, anim, Agent,currentScore);
                stage = EVENT.EXIT;
                Gold.gameObject.SetActive(true);
                
                Debug.Log("Dağlar ardinda");
                
                 currentScore = previousScore;
                Debug.Log(currentScore);
            }
            
        }

        protected override void Exit()
        {
            //Anim reset
            base.Exit();
        }
    }
}