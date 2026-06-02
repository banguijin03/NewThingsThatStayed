using UnityEngine;

public enum ItemType
{
    None,
    Book,           // 책
    Equipment,      // 의복
    Food,           // 요리
    Gem,            // 보석
    Hallucinogen,   // 환각제
    Herb,           // 약초
    Mineral,        // 광물
    Record,         // 기록
    Structure,      // 시설물
    Tool,           // 도구
    Misc,           // 기타
    Length
        //등급: 가죽/나무, 구리, 철, 은, 금, 백금, 미스릴, 오리하르콘, 아다만티움, 고대
}

//public enum ItemType
//{
//    Equipment, Consumable, Material, Miscellaneous, Quest, Impotrtant, Resource,
//    Length
//}

[CreateAssetMenu(fileName = "ItemContainer", menuName = "Item/ItemBase")]
public class ItemContainer : InfoContainer
{
    public ItemType type;
    public int maxStack;
    public float weight;
}