using UnityEngine;
using System.Collections;

public class CatToy : MonoBehaviour
{
    public GameObject cat;
    private Vector3 mousePosition;
    public GameObject ParticleSlow;
    public GameObject ParticleBurst;
    Ray ray;

    
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (cat.GetComponent<CatAggro>().gotAggro.State)
            {
                var burstParticle = Instantiate(ParticleBurst) as GameObject;
                burstParticle.transform.position = ray.origin;
            }

        }

        if (Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            transform.position = ray.origin;
        }
        
    }
}

