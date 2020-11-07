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

public class Net_Mgr 
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
        var address = $"(IP_Local):{networkPort}";
        Debug.LogWarning("Address: " + address);
        QRcodeShare = generateQR(address);
        qrImg.texture = QRcodeShare;
        if (!QRcodeShare)
            Debug.LogWarning("the QR Code is null");

    }
    
    void Start()
    {
        screenRect = new Rect(0, 0, Screen.width, Screen.height);
        camTexture = new WebCamTexture();
        camTexture.requestedHeight = Screen.height;
        camTexture.requestedWidth = Screen.width;
        qrCamera.texture = camTexture;
    }

    void Update()
    {
        if(qrCam.gameObject.activeSelf)
        {
            IBarcodeReader barcode = new BarcodeReader();
            var resulte = barcode.Decode(camTexture.GetPixels32(),camTexture.width,camTexture.height);
            if(resulte != null)
            {
                Debug.LogWarning("Decode result: " +resulte)
                try
                {
                    var
                }
            }
        }
    }
}
