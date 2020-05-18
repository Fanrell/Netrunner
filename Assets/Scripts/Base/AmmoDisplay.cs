using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    private int ammo;
    private PlayerBehavior player;
    public bool isFiring;
    public Text ammoDisplay;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        ammo = player.curramo;
        ammoDisplay.text = ammo.ToString() + " / 5";
    }
}
