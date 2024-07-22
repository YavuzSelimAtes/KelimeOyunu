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

    public char[] satir1 = new char[8];
    public char[] satir2 = new char[8];
    public char[] satir3 = new char[8];
    public char[] satir4 = new char[8];
    public char[] satir5 = new char[8];
    public char[] satir6 = new char[8];
    public char[] satir7 = new char[8];
    public char[] satir8 = new char[8];

    void Start()
    {
        klon = Instantiate(kelime, kelimeBaslangic.position, kelime.transform.rotation);

    }

    public void KelimeOlustur()
    {
        klon = Instantiate(kelime, kelimeBaslangic.position, kelime.transform.rotation);
    }



   

}
