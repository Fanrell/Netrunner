using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    private PlayerBehavior player;
    public Text ammoDisplay;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerBehavior>();
        Debug.Log(player);
    }

    // Update is called once per frame
    void Update()
    {
        ammoDisplay.text = "Ammo:\n" + player.curramo + " / " + player.maxamo;
    }

}
