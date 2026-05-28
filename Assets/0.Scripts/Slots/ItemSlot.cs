using UnityEngine;

public delegate void ItemSlotChangeEvent(ItemSlot changedSlot);

public class ItemSlot
{
    //이 칸에 들어있는 아이템의 정보
    [SerializeField] ItemContainer item;
    //이 칸 만의 정보
    [SerializeField] int currentStack;

    public event ItemSlotChangeEvent OnItemSlotChanged;

    public void NoticeChanged() => OnItemSlotChanged?.Invoke(this);

    public virtual bool Containable(ItemContainer wantItem)
    {
        if (!wantItem)                  return false;
        if (item && item != wantItem)   return false;
        if (GetIsMax())                 return false;

        return true;
    }
    public ItemContainer GetItem()  => item;
    public int GetStack()           => currentStack;
    public bool GetIsMax()          => item ? currentStack >= item.maxStack : false;
    public bool GetIsEmpty()        => !item || currentStack <= 0;

    public int Clear()
    {
        item = null;
        //  현재스택
        int removed = currentStack;
        currentStack = 0;
        return removed;
    }

    public int AddItem(ItemContainer wantItem, int amount)
    {
        if (amount <= 0) return 0;
        else if (!Containable(wantItem)) return amount;

        item = wantItem;
        int stackable = Mathf.Min(item.maxStack - currentStack, amount);
        currentStack += stackable;
        Debug.Log($"{item.displayName}({currentStack})");

        return amount - stackable;
    }

    public int RemoveItem(ItemContainer wantItem)
    {
        if (!wantItem) return 0;
        if (GetIsEmpty()) return 0;
        if(item != wantItem) return 0;

        return Clear();
    }
    public int RemoveItem(ItemContainer wantItem, int amount)
    {
        if (!wantItem) return amount;
        if (GetIsEmpty()) return amount;
        if (item != wantItem) return amount;
        if (amount >= currentStack) return amount - Clear();
        currentStack -= amount;
        return 0;
    }
}