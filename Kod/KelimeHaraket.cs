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
    int kelimeKonum = 3;
    int hiz = 3;
    bool durdumu=false;

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
            durdumu = true;
            Destroy(yenikelime.GetComponent<KelimeHaraket>());
            yenikelime.GetComponent<Rigidbody2D>().gravityScale = 1;
            oyunKontrol.GetComponent<OyunKontrol>().KelimeOlustur();
            Debug.Log(oyunKontrol.GetComponent<OyunKontrol>().satir8[kelimeKonum]);
            kelimeKonum = 3;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "satir1")
            oyunKontrol.GetComponent<OyunKontrol>().satir1[kelimeKonum] = harf.text[0];
        if (collision.gameObject.tag == "satir2")
            oyunKontrol.GetComponent<OyunKontrol>().satir2[kelimeKonum] = harf.text[0];
        if (collision.gameObject.tag == "satir3")
            oyunKontrol.GetComponent<OyunKontrol>().satir3[kelimeKonum] = harf.text[0];
        if (collision.gameObject.tag == "satir4")
            oyunKontrol.GetComponent<OyunKontrol>().satir4[kelimeKonum] = harf.text[0];
        if (collision.gameObject.tag == "satir5")
            oyunKontrol.GetComponent<OyunKontrol>().satir5[kelimeKonum] = harf.text[0];
        if (collision.gameObject.tag == "satir6")
            oyunKontrol.GetComponent<OyunKontrol>().satir6[kelimeKonum] = harf.text[0];
        if (collision.gameObject.tag == "satir7")
            oyunKontrol.GetComponent<OyunKontrol>().satir7[kelimeKonum] = harf.text[0];
        if (collision.gameObject.tag == "satir8")
        {
            Debug.Log("burdayim");
            oyunKontrol.GetComponent<OyunKontrol>().satir8[kelimeKonum] = harf.text[0];
        }
            
    }

    void kelimeHareket()
    {
        transform.Translate(Vector2.down * hiz * Time.deltaTime);
    }
    void haraket()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (kelimeKonum == 0)
            {
                return;
            }
            else
            {
                pozisyon.x -= 3.25f;
                transform.position = pozisyon;
            }

            kelimeKonum--;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            if (kelimeKonum == 7)
            {
                return;
            }
            else
            {
                pozisyon.x += 3.25f;
                transform.position = pozisyon;
            }

            kelimeKonum++;
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
