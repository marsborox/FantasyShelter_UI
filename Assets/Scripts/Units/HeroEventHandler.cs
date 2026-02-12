using UnityEngine;

public class HeroEventHandler : MonoBehaviour
{
    public delegate void StatEvent();

    public static StatEvent OnStatsChanged;

    public void OnStatsChangedEvent()
    {
        OnStatsChanged?.Invoke();
    }
}
