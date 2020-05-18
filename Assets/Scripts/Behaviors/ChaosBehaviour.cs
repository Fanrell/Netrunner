public static class  ChaosBehaviour
{
    private static float hpBoost = 1f;
    private static float dmgBoost = 1f;

    public static int HpBoost
    {
        get => System.Convert.ToInt32(hpBoost);
    }
    public static int DmgBoost
    {
        get => System.Convert.ToInt32(dmgBoost);
    }

    public static void hpIncreas()
    {
        if(hpBoost < 3)
        {
            hpBoost += 0.5f;
        }
    }

    public static void dmgIncreas()
    {
        if(dmgBoost < 2)
        {
            dmgBoost += 0.3f;
        }
    }
}
