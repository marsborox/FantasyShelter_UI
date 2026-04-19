using UnityEngine;
using System.Collections.Generic;
public class StatField_List : MonoBehaviour
{
    public const string HERO_NAME = "HeroName";
    public const string LEVEL = "Level";
    public const string ACTIVITY = "Activity";
    public const string HEALTH = "Health";
    public const string DAMAGE = "Damage";
    public const string DEFENSE = "Defense";
    public const string ENERGY = "Energy";
    public const string GROUP = "Group";
    public const string PROFESSION_SKILL = "ProfessionSkill";
    public const string STATUS = "Status";

    public List<StatField> statFieldList = new List<StatField>();
    public StatField heroNameField = new StatField("HeroName",HERO_NAME,UI_Constants.BASIC_TEXT_CONTAINER_LARGE);
    public StatField heroLevelField = new StatField("LVL",LEVEL,UI_Constants.BASIC_TEXT_CONTAINER_SMALL);
    public StatField heroActivityField = new StatField("Activity",ACTIVITY,UI_Constants.BASIC_TEXT_CONTAINER_MEDIUM);
    public StatField heroHealthField = new StatField("HP",HEALTH,UI_Constants.BASIC_TEXT_CONTAINER_SMALL);
    public StatField heroDamageField = new StatField("DMG",DAMAGE,UI_Constants.BASIC_TEXT_CONTAINER_SMALL);
    public StatField heroDefenseField = new StatField("DEF",DEFENSE,UI_Constants.BASIC_TEXT_CONTAINER_SMALL);
    public StatField heroEnergyField = new StatField("EN",ENERGY,UI_Constants.BASIC_TEXT_CONTAINER_SMALL);
    public StatField heroGroupField = new StatField("Group",GROUP,UI_Constants.BASIC_TEXT_CONTAINER_MEDIUM);
    public StatField heroProfSkillField = new StatField("Prof. Skill",PROFESSION_SKILL,UI_Constants.BASIC_TEXT_CONTAINER_MEDIUM);
    public StatField heroStatusField = new StatField("Status",STATUS,UI_Constants.BASIC_TEXT_CONTAINER_MEDIUM);
    //add statFields to list, in heroList change referencies here and add moethods for herolist creation w header

    void Start()
    {
        AddStatFieldsToList();
    }
        private void AddStatFieldsToList()
    {
        statFieldList.Add(heroNameField);
        statFieldList.Add(heroStatusField);
        statFieldList.Add(heroLevelField);
        statFieldList.Add(heroActivityField);
        statFieldList.Add(heroHealthField);
        statFieldList.Add(heroDamageField);
        statFieldList.Add(heroDefenseField);
        statFieldList.Add(heroEnergyField);
        statFieldList.Add(heroGroupField);
        statFieldList.Add(heroProfSkillField);
    }
}
