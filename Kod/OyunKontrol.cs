using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class OyunKontrol : MonoBehaviour
{
    public GameObject kelime;
    public GameObject klon;
    public Transform kelimeBaslangic;

    public GameObject[,] kutular = new GameObject[8,8];

    public char[,] harfdeposu = new char[8, 8];

    void Start()
    {
        klon = Instantiate(kelime, kelimeBaslangic.position, kelime.transform.rotation);
    }

    IEnumerator kelimeBul()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1;
    }
    public void KelimeOlustur()
    {
        klon = Instantiate(kelime, kelimeBaslangic.position, kelime.transform.rotation);
    }

    public void gondereBas()
    {
        StartCoroutine(kelimeBul());
    }
}
