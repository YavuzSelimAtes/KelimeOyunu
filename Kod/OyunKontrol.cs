using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class OyunKontrol : MonoBehaviour
{
    public GameObject kelime;
    public GameObject klon;
    public Transform kelimeBaslangic;
    Vector3 pozisyon;
    int kelimeKonum = 4;
    void Start()
    {
        klon=Instantiate(kelime, kelimeBaslangic.position, kelime.transform.rotation);
        pozisyon = klon.transform.position;
    }

    public void KelimeOlustur()
    {
        kelimeKonum = 4;
        klon = Instantiate(kelime, kelimeBaslangic.position, kelime.transform.rotation);
    }

    void kelimeHareket()
    {
        klon.transform.Translate(Vector2.down * 3 * Time.deltaTime);
    }
    void haraket()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (kelimeKonum == 1)
            {
                return;
            }
            else
            {
                pozisyon.x -= 3.25f;
                klon.transform.position = pozisyon;
            }

            kelimeKonum--;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            if (kelimeKonum == 8)
            {
                return;
            }
            else
            {
                pozisyon.x += 3.25f;
                klon.transform.position = pozisyon;
            }

            kelimeKonum++;
        }
    }
    void Update()
    {
        pozisyon = klon.transform.position;
        kelimeHareket();
        haraket();
    }

}
