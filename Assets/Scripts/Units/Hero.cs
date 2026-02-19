
public class Hero : Unit
{
    public HeroGroup heroGroupImIn;// must finish when hero is assigned
    public HeroInventory heroInventory;

    private HeroGroupManager _heroGroupManager;


    public string heroGroupImInName;
    public int idGroupHeroIsIn;
    private void Awake()
    {
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DoBasicSetup()
    {
        stats.AddStatsToList();
    }
    public void SetHeroGroupManagerReference(HeroGroupManager heroGroupManager)
    { 
        _heroGroupManager = heroGroupManager;
    }
    public int ReturnHealthBase()
    {
        return ((HeroStats)stats).healthStat.valueBase;
    }
    public int ReturnDamageBase()
    {
        return ((HeroStats)stats).damageStat.valueCurrent;
    }
    public int ReturnDefenseBase()
    {
        return ((HeroStats)stats).defenseStat.valueCurrent;
    }
    public int ReturnEnergyBase()
    {
        return ((HeroStats)stats).energyStat.valueCurrent;
    }

    public int ReturnHealthCurrent()
    {
        return ((HeroStats)stats).healthStat.valueCurrent;
    }
    public int ReturnDamageCurrent()
    {
        return ((HeroStats)stats).damageStat.valueCurrent;
    }
    public int ReturnDefenseCurrent()
    {
        return ((HeroStats)stats).defenseStat.valueCurrent;
    }
    public int ReturnEnergyCurrent()
    {
        return ((HeroStats)stats).energyStat.valueCurrent;
    }
    public void DressItem(Item_Gear item)
    { 
        heroInventory.DressItem(item);
    }
    public Hero_SaveData SaveHero()
    { 
        Hero_SaveData data = new Hero_SaveData();

        data.heroName = unitName;
        data.uniqueID = uniqueID;
        data.idGroupHeroIsIn = idGroupHeroIsIn;
        stats.SaveStats(data);

        heroInventory.SaveInventory(data);

        return data;
    }
    public void LoadHero(Hero_SaveData data)
    { 
        unitName = data.heroName;
        uniqueID = data.uniqueID;
        name = data.heroName;
        idGroupHeroIsIn = data.idGroupHeroIsIn;
        stats.LoadStats(data);
        heroInventory.LoadInventory(data);

        stats.AddInventoryStats();
        //add hero to designated group
        foreach (HeroGroup heroGroup in HeroGroupManager.instance.heroGroupList)
        {
            if (heroGroup.uniqueID == idGroupHeroIsIn)
            {
                HeroManager.instance.MoveHeroToGroup(this,heroGroup);
                break;
            }
        }
        
    }
}
