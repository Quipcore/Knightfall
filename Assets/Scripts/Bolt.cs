using UnityEngine;

public class Bolt : MonoBehaviour
{
    
    [SerializeField] private float lifeTime = 2f;
    
    private const float Speed = 10f;
    
    //------------------------------------------------------------------------------------------------------------------
    
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0f)
        {
            Destroy(gameObject);
        }
        
        transform.position += transform.forward * Time.deltaTime * Speed;
    }
}
