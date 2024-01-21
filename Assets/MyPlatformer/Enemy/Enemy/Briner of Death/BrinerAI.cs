using UnityEngine;

public class BrinerAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float throwRange = 5f;
    public float attackRange = 2f;
    public float moveRange = 8f; // Adjust this value based on your requirements
    public Transform player;

    private Animator animator;
    private bool isFacingRight = true;
    public Transform blade;
    public Transform bladepoint;
    public float bladetime =3f;
    public Transform impactEffect;
    public Transform impactPoint;
    HealthBar healthBar;
    public float playershoulderoffsetY = 0.6f;
    void Start()
    {
        animator = GetComponent<Animator>();
        healthBar = GetComponent<HealthBar>();
    }

    void Update()
    {

        if(healthBar.GetIsDead())
        {
        animator.CrossFade("Bringerdead" , 0.1f);
        return;
        }


        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= throwRange && distanceToPlayer > attackRange)
        {
            PerformThrowAnimation();
        }
        else if (distanceToPlayer <= attackRange)
        {
            PerformAttackAnimation();
        }
        else if (distanceToPlayer <= moveRange)
        {
            MoveTowardsPlayer();
        }
        else
        {
            // If the player is out of move range, you can add idle or other behavior here
            animator.SetBool("isMoving", false);
        }
    }

    void MoveTowardsPlayer()
    {
        // Flip the enemy if needed
        FlipIfNeeded(player.position.x - transform.position.x);
        Vector3 playerPosition = player.position;
        playerPosition.y = transform.position.y;

        // Move towards the player
        transform.position = Vector2.MoveTowards(transform.position, playerPosition, moveSpeed * Time.deltaTime);

        // Play move animation or set isMoving parameter to true based on your setup
        animator.SetBool("isMoving", true);
    }

    void PerformThrowAnimation()
    {
        FlipIfNeeded(player.position.x - transform.position.x);

        // Stop moving
        animator.SetBool("isMoving", false);

        // Play throw animation
        animator.SetTrigger("ThrowTrigger");

        // Additional logic for throwing behavior
    }

    void PerformAttackAnimation()
    {
        // Stop moving
        animator.SetBool("isMoving", false);

        // Play attack animation
        animator.SetTrigger("AttackTrigger");

        // Additional logic for attack behavior
    }

    void FlipIfNeeded(float horizontalMovement)
    {
        // Flip the enemy sprite based on movement direction
        if ((horizontalMovement > 0 && !isFacingRight) || (horizontalMovement < 0 && isFacingRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    void ThrowBlade()
    {
        Transform currentblade = Instantiate(blade , bladepoint.position , Quaternion.identity );
        currentblade.GetComponent<Blade>().SetUp(player.position + Vector3.up*playershoulderoffsetY, bladetime);
    }

    void SplashAttack()
    {
        //damage player health
    }


    public void PlayImpactAnimation()
    {
        Transform currenteffect = Instantiate(impactEffect , impactPoint.position , Quaternion.identity );
        
    }
}


