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
    int kelimeKonum = 4;
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
            Destroy(yenikelime.GetComponent<KelimeHaraket>());
            yenikelime.GetComponent<Rigidbody2D>().gravityScale = 1;
            oyunKontrol.GetComponent<OyunKontrol>().KelimeOlustur();
            kelimeKonum = 4;
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
            if (kelimeKonum == 1)
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

            if (kelimeKonum == 8)
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

    public string harfOlustur()
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
