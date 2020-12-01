using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;
using System.Net;
using ZXing.QrCode.Internal;
using System.Net.NetworkInformation;
using System.Diagnostics;

public class Net_Mgr : NetworkManager
{
    string IP_Local = "192.168.1.64";

    Texture2D QRcodeShare;

    public RawImage qrImg;
    public RawImage qrCam;

    Rect screenRect;
    WebCamTexture camTexture;

    public void ToggleQrCode()
    {
        qrImg.gameObject.SetActive(!qrImg.gameObject.activeSelf);
    }

    public void ToggleQrCam()
    {
        qrCam.gameObject.SetActive(!qrCam.gameObject.activeSelf);
        if (qrCam.gameObject.activeSelf)
            camTexture.Play();
        else
            camTexture.Stop();
    }

    public override void OnStartHost()   
    {
        base.OnStartHost();    
        var address = $"{IP_Local}:{networkPort}";  
        UnityEngine.Debug.LogWarning("Address: " + address);
        QRcodeShare = generateQrBox(address);
        qrImg.texture = QRcodeShare;
        if (!QRcodeShare)
            UnityEngine.Debug.LogWarning("QRcodeShare is null");


    }
    
    void Start()
    {
        screenRect = new Rect(0, 0, Screen.width, Screen.height);
        camTexture = new WebCamTexture();
        camTexture.requestedHeight = Screen.height;
        camTexture.requestedWidth = Screen.width;
        qrCam.texture = camTexture;
    }

    void Update()
    {
        if(qrCam.gameObject.activeSelf)
        {
            IBarcodeReader barcode = new BarcodeReader();
            var resulte = barcode.Decode(camTexture.GetPixels32(),camTexture.width,camTexture.height);
            if(resulte != null)
            {
                UnityEngine.Debug.LogWarning("Decode result: " + resulte);
                try
                {
                    var address = resulte.ToString().Split(':');
                    networkAddress = address[0]; 
                    networkPort = int.Parse(address[1]);   

                    ToggleQrCam();
                }
                catch(Exception ext)
                {
                    UnityEngine.Debug.LogError("result is in unexpected format.");
                }
            }
        }
    }

    private static Color32[] Encode(string textForEmcoding, int width, int height)
    {
        var writerT = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };

        return writerT.Write(textForEmcoding);
    }

    public Texture2D generateQrBox(string text)
    {
        var encodedT = new Texture2D(254, 254);
        var color32 = Encode(text, encodedT.width, encodedT.height);
        encodedT.SetPixels32(color32);
        return encodedT;
    }
}
