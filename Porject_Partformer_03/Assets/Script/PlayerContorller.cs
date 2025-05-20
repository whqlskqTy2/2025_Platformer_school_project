using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerContorller : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator pAni;
    private bool isGrounded;

    private bool isGiant = false;
    private float originalSpeed;

    public GameObject jumpItemImage;

    private bool isJumpBoosted = false;
    private float originalJumpForce;

    private bool isInvincible = false; // ���� ���� ����

    public float score;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pAni = GetComponent<Animator>();
        originalSpeed = moveSpeed;
        originalJumpForce = jumpForce;

        score = 1000f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn"))
        {
            if (!isInvincible)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                Debug.Log("���� �����̹Ƿ� Respawn Ÿ�� ���� ������ ���� �ʽ��ϴ�.");
            }
        }

        if (collision.CompareTag("Finish"))
        {
            //HighScore.TrySet(SceneManager.GetActiveScene().buildIndex, (int)score);
            StageResultSaver.SaveStage(SceneManager.GetActiveScene().buildIndex, (int)score);

            collision.GetComponent<LevelObject>().MoveToNextLevel();
        }

        if (collision.CompareTag("Enemy"))
        {
            if (!isInvincible)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (collision.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(SpeedBoostCoroutine());
        }

        if (collision.CompareTag("Jump Item"))
        {
            isJumpBoosted = true;
            jumpForce = 8f;
            Destroy(collision.gameObject);
            StartCoroutine(JumpBoostCoroutine());
        }

        if (collision.CompareTag("invincibility_Item"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(InvincibilityCoroutine());
        }

        // �浹�� ������Ʈ�� �±װ� "Item"�� ��쿡�� ����
        if (collision.CompareTag("Item"))
        {
            isGiant = true;  // �÷��̾� ���¸� �������� ����

            // �浹�� ������Ʈ�� ���� ItemObject ������Ʈ���� ������ ������ ����
            score += collision.GetComponent<ItemObject>().GetPoint();

            // ������ ������Ʈ ����
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (isGiant)
        {
            if (moveInput < 0)
                transform.localScale = new Vector3(2f, 2f, 2f);

            if (moveInput > 0)
                transform.localScale = new Vector3(-2f, 2f, 1f);
        }
        else
        {
            if (moveInput < 0)
                transform.localScale = new Vector3(1f, 1f, 1f);

            if (moveInput > 0)
                transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            pAni.SetTrigger("JumpAction");
        }

        score -= Time.deltaTime;
    }

    private IEnumerator GiantModeCoroutine()
    {
        moveSpeed = 8f;
        yield return new WaitForSeconds(5f);
        moveSpeed = originalSpeed;
        isGiant = false;
    }

    private IEnumerator SpeedBoostCoroutine()
    {
        moveSpeed = 8f;
        yield return new WaitForSeconds(5f);
        moveSpeed = originalSpeed;
    }

    private IEnumerator JumpBoostCoroutine()
    {
        yield return new WaitForSeconds(5f);
        jumpForce = originalJumpForce;
        isJumpBoosted = false;
    }

    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
       
        yield return new WaitForSeconds(3f);
        isInvincible = false;
    }
}