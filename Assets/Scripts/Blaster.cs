using UnityEngine;

public class Blaster : MonoBehaviour
{

    public GameObject blasterboltPrefab;
    public GameObject tipOfBlaster;
    
    private const float Cooldown = 0.25f;
    
    [SerializeField] private float cooldownTimer;
    [SerializeField] private bool canShoot = true;
    
    
    //------------------------------------------------------------------------------------------------------------------
    
    void Start()
    {
        cooldownTimer = Cooldown;
    }
    
    //------------------------------------------------------------------------------------------------------------------
    
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0f)
        {
            canShoot = true;
        }
    }
    
    //------------------------------------------------------------------------------------------------------------------

    public void Shoot()
    {
        if (!canShoot)
        {
            return;
        }
        canShoot = false;
        cooldownTimer = Cooldown;
        Instantiate(blasterboltPrefab, tipOfBlaster.transform.position, tipOfBlaster.transform.rotation);
    }
}
