using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed;
    public string direction;
    public bool canMove, dead;
    private Animator animator;
    private GameManager gameManager;
    private AudioSource audioSource;
    public AudioClip deathEnemySound;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        Destroy(this.gameObject,10);
    }
    private void Update()
    {
        if (canMove)
        {
            transform.Translate(-Vector3.forward * enemySpeed * Time.deltaTime);
        }
    }
    public void CanMove()
    {
        canMove = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            canMove = false;
            dead = true;
            gameManager.AddScore();
            audioSource.PlayOneShot(deathEnemySound);
            animator.SetTrigger("Dead");
        }
    }
    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }
}
