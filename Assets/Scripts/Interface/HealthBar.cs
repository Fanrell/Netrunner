using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private PlayerBehavior player;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        SetMaxHealth();
        SetHealth();

    }

    public void SetMaxHealth()
    {
        slider.maxValue = player.maxhp;
        slider.value = player.currhp;
    }

    public void SetHealth()
    {
        slider.value = player.currhp;
    }
}