using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class KelimeHaraket : MonoBehaviour
{
    public TextMeshProUGUI harf;
    GameObject oyunKontrol;
    GameObject yenikelime;
    Vector3 pozisyon;
    int kelimeKonumx = 3;
    int kelimeKonumy = -1;
    int hiz = 3;

    System.Random random;

    char[] harfListesi = { 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'B', 'B', 'C', 'C', 'Ç', 'Ç', 'D', 'D', 'D', 'E', 'E', 'E', 'E', 'E', 'E', 'F', 'F', 'G', 'G', 'Ð', 'H', 'H', 'I', 'I', 'I', 'Ý', 'Ý', 'Ý', 'Ý', 'Ý', 'J', 'K', 'K', 'K', 'K', 'K', 'K', 'L', 'L', 'L', 'L', 'L', 'L', 'M', 'M', 'M', 'M', 'M', 'N', 'N', 'N', 'N', 'O', 'O', 'O', 'Ö', 'P', 'P', 'R', 'R', 'R', 'R', 'R', 'S', 'S', 'S', 'S', 'Þ', 'Þ', 'T', 'T', 'T', 'T', 'T', 'U', 'U', 'U', 'Ü', 'Ü', 'V', 'V', 'Y', 'Y', 'Y', 'Z', 'Z', 'Z'};
    void Start()
    {
        random = new System.Random();
        oyunKontrol = GameObject.Find("OyunKontrol");
        yenikelime = oyunKontrol.GetComponent<OyunKontrol>().klon;
        harf.text = harfOlustur();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Taban")
        {
            oyunKontrol.GetComponent<OyunKontrol>().harfdeposu[kelimeKonumy,kelimeKonumx] = harf.text[0];
            oyunKontrol.GetComponent<OyunKontrol>().kutular[kelimeKonumy, kelimeKonumx] = yenikelime;
            Destroy(yenikelime.GetComponent<KelimeHaraket>());
            yenikelime.GetComponent<Rigidbody2D>().gravityScale = 1;
            oyunKontrol.GetComponent<OyunKontrol>().KelimeOlustur();
            kelimeKonumx = 3;
            kelimeKonumy = -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "satir1")
            kelimeKonumy++;
        if (collision.gameObject.tag == "satir2")
            kelimeKonumy++;
        if (collision.gameObject.tag == "satir3")
            kelimeKonumy++;
        if (collision.gameObject.tag == "satir4")
            kelimeKonumy++;
        if (collision.gameObject.tag == "satir5")
            kelimeKonumy++;
        if (collision.gameObject.tag == "satir6")
            kelimeKonumy++;
        if (collision.gameObject.tag == "satir7")
            kelimeKonumy++;
        if (collision.gameObject.tag == "satir8")
            kelimeKonumy++;
            
    }

    void kelimeHareket()
    {
        transform.Translate(Vector2.down * hiz * Time.deltaTime);
    }
    void haraket()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (kelimeKonumx == 0)
            {
                return;
            }
            else
            {
                pozisyon.x -= 3.25f;
                transform.position = pozisyon;
            }

            kelimeKonumx--;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            if (kelimeKonumx == 7)
            {
                return;
            }
            else
            {
                pozisyon.x += 3.25f;
                transform.position = pozisyon;
            }

            kelimeKonumx++;
        }

        if(Input.GetKey(KeyCode.DownArrow))
            hiz = 12;
        if (Input.GetKeyUp(KeyCode.DownArrow))
            hiz = 3;
        
    }
    string harfOlustur()
    {
        char harfUret;

        harfUret = harfListesi[random.Next(harfListesi.Length)];

        return harfUret.ToString();
    }
    void Update()
    {
        pozisyon = transform.position;
        kelimeHareket();
        haraket();

    }
}
