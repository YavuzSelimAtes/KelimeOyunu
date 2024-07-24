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
            Debug.Log(kelimeKonumy);
            Debug.Log(kelimeKonumx);
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
        do
        {
            harfUret = (char)random.Next('A', 'Z' + 1);
        } while (harfUret == 'Q' || harfUret == 'W' || harfUret == 'X');

        return harfUret.ToString();
    }
    void Update()
    {
        pozisyon = transform.position;
        kelimeHareket();
        haraket();

    }
}
