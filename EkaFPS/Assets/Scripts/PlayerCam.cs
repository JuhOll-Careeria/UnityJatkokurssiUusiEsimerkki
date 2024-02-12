using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;  // sensitivity x-akselille
    public float sensY;  // sensitivity y-akselille
    public Transform orientation; // Pelaaja hahmo

    float xRot;
    float yRot;

    void Start()
    {
        // Lukitaan kursori ja laitetaan se piiloon
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Luetaan hiiren X ja Y liikkuminen
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRot += mouseX;
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90, 90); // <-- Estää ettei käännytä alle -90 astetta ja yli 90 astetta

        // Käännettään kameraa ja pelaajaa 
        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        orientation.rotation = Quaternion.Euler(0, yRot, 0);
    }
}