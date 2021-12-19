using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float moveSpeed = 5f;

    public AudioSource audioSource;
    public AudioClip sound;

    public bool canMove = true;

    Vector2 movement;

    private Animator animator;
    private BoxCollider2D boxCollider2D;
    private Rigidbody2D rigidbody;


    public static MovePlayer instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Inventory dans la scène");
            return;
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = this.transform.GetComponent<Animator>();
        boxCollider2D = this.transform.GetComponent<BoxCollider2D>();
        rigidbody = this.transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Flip();
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }
    public void AnimationPlay(string nameAnim)
    {
        StartCoroutine(AnimationWait(nameAnim));
    }
    public IEnumerator AnimationWait(string nameAnim)
    {
        CanMove(false);
        animator.Play(nameAnim);
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName(nameAnim))
        {
            yield return null;
        }
        audioSource.PlayOneShot(sound);
        float counter = 0;
        while ((animator.GetCurrentAnimatorStateInfo(0).normalizedTime) % 1 < 0.99f )
        {
            counter += Time.deltaTime;
            yield return null;
        }
        CanMove(true);
    }

    void FixedUpdate()
    {

        rigidbody.MovePosition(rigidbody.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    private void Flip()
    {
        if (CanMove())
        {
            if (movement.x > 0.1f)
            {
                //spriteRenderer.flipX = false;
                boxCollider2D.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (movement.x < -0.1f)
            {
                //spriteRenderer.flipX = true;
                boxCollider2D.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

    private bool CanMove(bool? canMoveNow = null)
    {
        if (canMoveNow == null)
            return canMove;
        if ((bool)canMoveNow)
        {
            canMove = true;
            rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            canMove = false;
            rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        return canMove;
    }


}
