using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteractionHandler : MonoBehaviour
{
    [Header("Interactions")]
    public float interactionLength = 1.0f;
    public LayerMask interactionLayers;
    public TextMeshProUGUI interactionText;

    [Header("Grenade")]
    public GameObject grenadePrefab;
    public Transform firePoint;
    public float throwForce;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInteraction();

        if (Input.GetMouseButtonDown(1))
        {
            ThrowGrenade();
        }
    }

    void ThrowGrenade()
    {
        // synnytet‰‰n kranaatti pelaajan FirePointtiin
        GameObject grenade = Instantiate(grenadePrefab, firePoint);
        // Otetaan kranaatin parent pois, jotta se ei olisi yhdistetty pelaajaan
        grenade.transform.parent = null;
        // Annetaan kranaatille force eteenp‰in, eli ns. heitet‰‰n kranaatti
        grenade.GetComponent<Rigidbody>().AddForce(grenade.transform.forward * throwForce);
    }

    void HandleInteraction()
    {
        // Ampuu s‰teen keskelle n‰yttˆ‰
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        // Tarkistetaan osuuko pelaajan s‰de mihink‰‰n Collideriin
        if (Physics.Raycast(ray, out hit, interactionLength, interactionLayers))
        {
            // Jos s‰de osuu, tarkistetaan onko osutulla objektilla "Interactable" skripti
            if (hit.transform.GetComponent<Interactable>())
            {
                // Jos on, niin n‰ytet‰‰n UI:ssa ett‰ voidaan interactoida
                interactionText.text = "[E] to interact with " + hit.transform.GetComponent<Interactable>().interactableName;

                // Jos pelaaja painaa E:t‰ KUN se katsoo objektia, niin 
                // l‰hetet‰‰n kutsu ja interactoidaan objektin kanssa
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.GetComponent<Interactable>().OnInteract();
                }
            }

        }
        else
        {
            interactionText.text = "";
        }
    }
}
