using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuUi : MonoBehaviour
{
    Button playButton;

    void Awake()
    {
        playButton.onClick.AddListener(() => ViewManager.singleton.Show<Options>());

    }
}
