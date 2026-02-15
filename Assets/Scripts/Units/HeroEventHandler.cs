using UnityEngine;

public class HeroEventHandler : MonoBehaviour
{
    public delegate void StatEvent();

    public StatEvent OnStatsChanged;

    public void OnStatsChangedEvent()
    {
        OnStatsChanged?.Invoke();
    }
}
