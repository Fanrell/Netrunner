public static class  ChaosBehaviour
{
    private static float hpBoost = 1f;
    private static float dmgBoost = 1f;
    private static float spawnboost = 1f;

    public static int HpBoost
    {
        get => System.Convert.ToInt32(hpBoost);
        set => hpBoost = value;
    }
    public static int DmgBoost
    {
        get => System.Convert.ToInt32(dmgBoost);
        set => DmgBoost = value;
    }
    public static int SpawnBoost
    {
        get => System.Convert.ToInt32(spawnboost);
        set => SpawnBoost = value;
    }

    public static void hpIncreas()
    {
        if(hpBoost < 10)
        {
            hpBoost += 0.5f;
        }
    }

    public static void dmgIncreas()
    {
        if(dmgBoost < 10)
        {
            dmgBoost += 0.5f;
        }
    }

    public static void spawnIncreas()
    {
        if (spawnboost < 10)
        {
            spawnboost += 0.5f;
        }
    }
}
