using UnityEngine;

public class HeroList_UI : UI
{
    [SerializeField] HeroManager _heroManager;
    [SerializeField] HeroInList_UI _heroInListPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        DestroyHeroes();
        DisplayHeroes();
    }
    private void OnDisable()
    {

    }
    private void DisplayHeroes()
    {
        foreach (Unit hero in _heroManager.heroList)
        { 
            var heroInList= Instantiate(_heroInListPrefab);
            heroInList.transform.parent = this.transform;
            heroInList.hero = hero;
            heroInList.stats = hero.stats;
        }
    }
    private void DestroyHeroes()
    {
        while (transform.childCount > 0)
        { 
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }
}
