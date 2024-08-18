using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public GameObject Player;
    public GameObject ManaBar;
    private PlayerMovement playerMovement;
    private ManaBar manaBar;
    public AudioSource shootSound;

    void Start()
    {
        playerMovement = Player.GetComponent<PlayerMovement>();
        manaBar = ManaBar.GetComponent<ManaBar>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(playerMovement.powerActive && playerMovement.maskHP > 0){
                Shoot();
                playerMovement.maskHP -= 1;
                manaBar.SetCurrentMana(manaBar.currentmana -= 1);
                Debug.Log("Mana left: " + playerMovement.maskHP);
            }
            else if(playerMovement.powerActive && playerMovement.maskHP <= 0){
                playerMovement.MaskExplode("ProjectileShoot");
            }
        }
    }

    void Shoot()
    {
        shootSound.Play();
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector2 direction = (mousePosition - transform.position).normalized;

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        projectile.transform.up = direction;
    }
}
