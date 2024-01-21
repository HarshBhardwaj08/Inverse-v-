using UnityEngine;

public class WizardAI : MonoBehaviour
{
    public float throwRange = 8f;
    public float attackRange = 5f;
    readonly int WizardIdle = Animator.StringToHash("WizardIdle");
    readonly int WizardWalk = Animator.StringToHash("WizardWalk");
    readonly int WizardAttack = Animator.StringToHash("WizardAttack");
    readonly int WizardThrow = Animator.StringToHash("WizardThrow");
    readonly int WizardDead = Animator.StringToHash("WizardDead");
    readonly int WizardImpact = Animator.StringToHash("WizardImpact");

    State state;
    Animator anime;
    public Transform player;

    private void Start() {
        state = State.idel;
        anime = GetComponent<Animator>();

    }

    private void Update() {
        
        float distance = Vector3.Distance(transform.position , player.position);
        switch(state)
        {
            case State.idel:

            if(distance < throwRange)
            {
                state = State.attack;
            }
            break;

            case State.attack:
            if(distance < attackRange)
            {
                
            }
            break;

            case State.impact:
            break;

            case State.dead:
            break;
        }
    }

}


