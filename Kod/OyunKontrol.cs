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
    TextMeshProUGUI harf;

    void Start()
    {
        klon = Instantiate(kelime, kelimeBaslangic.position, kelime.transform.rotation);

    }

    public void KelimeOlustur()
    {
        klon = Instantiate(kelime, kelimeBaslangic.position, kelime.transform.rotation);
    }



   

}
