using UnityEngine;
using UnityEngine.UI;

public class LifeDisplay : MonoBehaviour
{
    private PlayerBehavior player;
    public Text lifeDisplay;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeDisplay.text = "Life:\n" + player.currhp + " / " + player.maxhp;
    }
}
