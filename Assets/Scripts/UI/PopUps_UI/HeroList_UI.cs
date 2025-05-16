using UnityEngine;

public class HeroList_UI : UI
{
    [SerializeField] HeroManager _heroManager;
    [SerializeField] HeroInList_UI _heroInGroupPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DisplayHeroes()
    {
        foreach (Hero hero in _heroManager.heroList)
        { 
            Instantiate(_heroInGroupPrefab);
        }
    }
}
