using System;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    
    [SerializeField] private float lifeTime = 10f;
    
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
    
    //------------------------------------------------------------------------------------------------------------------

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
