
using UnityEngine;

public class SlimeAI : MonoBehaviour
{
    State state;
    
    readonly int SlimeIdel = Animator.StringToHash("SlimeIdel");
    readonly int SlimeAttack = Animator.StringToHash("SlimeAttack");
    public float patrolRange = 5f; // The range within which the enemy patrols
    public float moveSpeed = 2f;   // Speed at which the enemy moves

    private float initialPosition;

    public Transform leftPoint;    // Left patrol point
    public Transform rightPoint;
    private bool movingRight = true;
    public Transform player;
    public float attackRange = 5f;
    public float gaintScale = 8;
    public float yoffset = 0.1f;
    public bool playerKilled;
    
    Vector3 initialScale ;
    bool right;
    

    Animator anime;
    private void Start() {
        
        state = State.patrol;
        anime = GetComponent<Animator>();
        initialScale = transform.localScale;

    }

    void Update()
    {
        float distance  = Vector3.Distance(transform.position , player.position);
        switch(state)
        {
            case State.patrol :
            MoveEnemy();
            FlipSprite();

            if(distance < attackRange && !playerKilled)
            {
                state = State.attack;
                transform.position += Vector3.up*yoffset;
                anime.CrossFadeInFixedTime(SlimeAttack , 0.1f);
                transform.localScale = Vector3.one * gaintScale;
            }

            break;

            case State.attack :
            // FlipSprite();
            Vector3 dir = (player.position - transform.position).normalized;

            if(dir.x > 0)
            {
                right = true;
            }
            else if(dir.x < 0)
            {
                right = false;
            }

            float currentScaleX = transform.localScale.x;

            float newScaleX = Mathf.Abs(currentScaleX) * (right ? -1 : 1);
            transform.localScale = new Vector3(newScaleX, transform.localScale.y, transform.localScale.z);
            playerKilled = true;

            break;

        }



    }

    void MoveEnemy()
    {
        Vector2 direction = movingRight ? Vector2.right : Vector2.left;
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        if ((movingRight && transform.position.x > rightPoint.position.x) ||
            (!movingRight && transform.position.x < leftPoint.position.x))
        {
            movingRight = !movingRight;
        }
    }

    void FlipSprite()
    {
        float currentScaleX = transform.localScale.x;
        float newScaleX = Mathf.Abs(currentScaleX) * (movingRight ? -1 : 1);
        transform.localScale = new Vector3(newScaleX, transform.localScale.y, transform.localScale.z);
    }

    void KillPlayer()
    {
        //attack player event 
        //implemt dead logic
    }

    void EndEvent()
    {
        transform.localScale = initialScale;
        transform.position += Vector3.down*yoffset;
        Vector3 dir = (player.position - transform.position).normalized;

            if(dir.x > 0)
            {
                right = true;
            }
            else if(dir.x < 0)
            {
                right = false;
            }

            float currentScaleX = transform.localScale.x;

            float newScaleX = Mathf.Abs(currentScaleX) * (right ? -1 : 1);
            transform.localScale = new Vector3(newScaleX, transform.localScale.y, transform.localScale.z);

            state = State.patrol;

    }
}

public enum State {idel , patrol , attack , impact , dead}