using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public GameObject Player;
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = Player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(playerMovement.powerActive){
                Shoot();
            }
        }
    }

    void Shoot()
    {
Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector2 direction = (mousePosition - transform.position).normalized;

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        projectile.transform.up = direction;
    }
}
