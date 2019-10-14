using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed, hitDistance, shootCooldown, nextShoot, hitCooldown, nextHit;
    public bool isMoving, isShooting, isDead;
    public Vector3 movement;
    private RaycastHit hit;
    private PlayerAnimations playerAnimations;
    public LayerMask layerMask;
    public GameObject projectile, shootPosition;
    public int hp;
    private UIManager uIManager;
    private GameManager gameManager;
    private CamAnimations camAnimations;
    public float maxX, maxZ, minX, minZ;

    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
        uIManager = FindObjectOfType<UIManager>();
        gameManager = FindObjectOfType<GameManager>();
        camAnimations = FindObjectOfType<CamAnimations>();
    }
    private void Start()
    {
        nextShoot = 0;
    }
    private void Update()
    {
        if (isDead)
        {
            return;
        }
        movement.x = Input.GetAxis("Horizontal");
        movement.y = 0;
        movement.z = Input.GetAxis("Vertical");
        this.transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
        Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mousePos, out hit, hitDistance, layerMask))
        {
            Vector3 aimRotation = hit.point - this.transform.position;
            aimRotation.y = 0;
            Quaternion lookRotation = Quaternion.LookRotation(aimRotation);
            this.transform.rotation = lookRotation;
        }
        nextShoot -= Time.deltaTime;
        nextHit -= Time.deltaTime;
        VerifiyMovement();

        if (Input.GetMouseButton(0) && nextShoot <= 0)
        {
            isShooting = true;
            playerAnimations.IsShooting(isShooting);
            Instantiate(projectile, this.shootPosition.transform.position, this.transform.rotation);
            nextShoot = shootCooldown;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isShooting = false;
            playerAnimations.IsShooting(isShooting);
        }
        if (this.transform.position.x >= maxX)
        {
            this.transform.position = new Vector3(maxX, this.transform.position.y, this.transform.position.z);
        }
        if (this.transform.position.x <= minX)
        {
            this.transform.position = new Vector3(minX, this.transform.position.y, this.transform.position.z);
        }
        if (this.transform.position.z >= maxZ)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, maxZ);
        }
        if (this.transform.position.z <= minZ)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, minZ);
        }

    }
    private void VerifiyMovement()
    {
        if (movement.x != 0 || movement.z != 0)
        {
            isMoving = true;
            playerAnimations.IsMoving(isMoving);
        }
        else
        {
            isMoving = false;
            playerAnimations.IsMoving(isMoving);
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && nextHit <= 0)
        {
            TakeDamage();
        }
    }
    public void TakeDamage()
    {
        this.hp -= 1;
        uIManager.SetHPSlider(hp);
        nextHit = hitCooldown;
        camAnimations.TriggerShake();
        if (hp <= 0)
        {
            isDead = true;
            playerAnimations.IsDead();
            Invoke("RestartGame", 4f);
        }
    }
    public void RestartGame()
    {
        gameManager.RestartGame();
    }
}
