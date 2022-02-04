using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api; ///Para referenciar las librerias de Admob

public class AdManager : MonoBehaviour
{
    public static AdManager instance;

    public string appID = "ca-app-pub-1363069613034255~9753421341"; ///Colocar aqui tu APP ID

    public string FullScreenID = "ca-app-pub-1363069613034255/6824376807"; ///Colocar aqui tu Interstitial ID 
    public InterstitialAd PantallaCompleta;

    public string Banner = "ca-app-pub-1363069613034255/2654494674"; ///Colocar aqui tu Banner ID
    public BannerView BannerOneEon;

    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatus => { }); ///IMPORTANTE INICIALIZAR, NO OLVIDAR ESTA LINEA DE CODIGO
        RequestPantallaCompleta();
    }

    /// Para evitar que crashee
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }


    ///Banner a continuacion

    public void RequestBanner() ///Pide el banner
    {
        AdSize adSize = new AdSize(320, 50);
        BannerOneEon = new BannerView(Banner, adSize, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        BannerOneEon.LoadAd(request);

        BannerOneEon.Show(); ///Esta linea muestra el banner
    }

    public void HideBanner() ///Oculta el banner
    {
        BannerOneEon.Hide();
    }

    ///Interstitvial

    public void RequestPantallaCompleta()  ///Recuerden que esto se usa para cargarlo, no para mostrarlo
    {
        PantallaCompleta = new InterstitialAd(FullScreenID);

        AdRequest request = new AdRequest.Builder().Build();

        PantallaCompleta.LoadAd(request);
    }

    public void ShowPantallaCompleta() ///Muestra el anuncio pantalla completa
    {
        if (PantallaCompleta.IsLoaded())
        {
            PantallaCompleta.Show();
        }
        else
        {
            {
                Debug.Log("full screen ad not loaded");
            }
        }
    }

    ///Bringing Possibilities And Fun!

}

