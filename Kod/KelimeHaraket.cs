using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KelimeHaraket : MonoBehaviour
{
    GameObject oyunKontrol;
    GameObject yenikelime;
    void Start()
    {
        oyunKontrol = GameObject.Find("OyunKontrol");
        yenikelime = oyunKontrol.GetComponent<OyunKontrol>().klon;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Taban")
        {
            Destroy(yenikelime.GetComponent<KelimeHaraket>());
            yenikelime.GetComponent<Rigidbody2D>().gravityScale = 1;
            oyunKontrol.GetComponent<OyunKontrol>().KelimeOlustur();
        }
    }
}
