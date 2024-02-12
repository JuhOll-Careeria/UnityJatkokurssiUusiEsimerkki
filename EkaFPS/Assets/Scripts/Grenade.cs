using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float force;
    public float radius;
    public float upModifier;
    public float timeToBlowUp = 5f;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // Kun objekti syntyy, odotetaan timeToBlowUp -muuttujan
        // verran, ennen kuin r‰j‰hdet‰‰n
        Invoke("Explode", timeToBlowUp);

        anim = GetComponentInChildren<Animator>();    
    }

    void Explode()
    {
        Collider[] collidersHit = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider hit in collidersHit)
        {
            if (hit.GetComponent<Rigidbody>())
            {
                hit.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius, upModifier);
            }
        }

        anim.Play("FlashBang");
        Destroy(this.gameObject, 4f);
    }

}
