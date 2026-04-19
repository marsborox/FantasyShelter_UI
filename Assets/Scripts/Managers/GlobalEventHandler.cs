using UnityEngine;

public class GlobalEventHandler : Singleton<GlobalEventHandler>
{
    public static new GlobalEventHandler instance => Singleton<GlobalEventHandler>.instance;

    public delegate void StashEvent();
    public event StashEvent OnStashChanged;

    public delegate void HeroListEvent();
    public event HeroListEvent OnHeroListChanged;
    public void StashChanged()
    {
        OnStashChanged?.Invoke();
    }
    public void HeroListChanged()
    {
        OnHeroListChanged?.Invoke();
    }

}
