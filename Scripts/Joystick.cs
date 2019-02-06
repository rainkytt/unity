using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// see skript töötab juhul kui Unity2D "Main Camera" on "Perspective" vaates
public class Joystick : MonoBehaviour
{
    public Transform player; // see väli ilmub muutujaks Unity-sse (skripti Inspector väljale)
    public float speed = 5.0f; // see väli ilmub muutujaks Unity-sse
    private bool touchStart = false; // kontrollimaks millal vajutame
    private Vector2 pointA; // joystiku (k.a tegelase) algne asukoht
    private Vector2 pointB; // joystiku (k.a tegelase) asukoht kui lohistame seda sõrmega

    public Transform circle; // joistiku sisemine ring, samuti muutujaks Unity-sse
    public Transform outerCircle; // joistiku välimine ring, samuti muutujaks Unity-sse

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // kas on vajutatud hiire nuppu
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z)); // kui on vajutatud, siis see on pointA

            circle.transform.position = pointA * -1; // joistiku asukohaks, sisemine ring
            outerCircle.transform.position = pointA * -1; // joistiku asukohaks, välimine ring
            circle.GetComponent<SpriteRenderer>().enabled = true; // näita joistikut ainult siis kui nuppu (näpp) on vajutatud
            outerCircle.GetComponent<SpriteRenderer>().enabled = true; // näita joistikut ainult siis kui nuppu (näpp) on vajutatud
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true; // algab samuti nupu vajutusest
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z)); // samamoodi saame pointB
        }
        else
        {
            touchStart = false;
        }

    }
    private void FixedUpdate() // FixedUpdate on kasutusel kui objektidel on füüsilised omadused nagu gravitatsioon jne
    {
        if (touchStart)
        {
            Vector2 offset = pointB - pointA; // asukoha valem (k.a liikumise suund), kuhu vajutasid hiirega/näpuga
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f); // liikumine toimub -1 kuni +1 vahemikus
            moveCharacter(direction * -1); // seotud Main Camera asukohaga Unity-s

            circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) * -1; // et joistiku sisemine ring püsiks välimise sees
        }
        else
        {
            circle.GetComponent<SpriteRenderer>().enabled = false; // joistik kaob kui nupu (näpu) vajutus on lõppenud
            outerCircle.GetComponent<SpriteRenderer>().enabled = false; // joistik kaob kui nupu (näpu) vajutus on lõppenud
        }

    }
    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime); // tegelase liikumise suund ja kiirus, kui tahaks lisada ka füüsikat siis player.AddForce(...);
    }
}