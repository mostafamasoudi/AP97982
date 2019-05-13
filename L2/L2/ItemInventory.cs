using System;
using System.Collections.Generic;

namespace L2
{
    public class ItemInventory
    {
        public List<Item> Items;

        public ItemInventory()
        {
            this.Items = new List<Item>();
        }

        public List<Item> Filter(List<IFilter> filters)
        {
            List<Item> filterItem = new List<Item>();
            foreach (var i in Items)
            {
                bool isOk = true;
                foreach (var f in filters)
                {
                    if (!(f.Filter(i)))
                        isOk = false;
                }
                if (isOk)
                    Items.Add(i);
            }
            return filterItem;
        }

        public Item GetItemById(int id)
        {
            if (id < Items.Count)
                return Items[id];
            else
                return null;
        }
        public int AddItem(Item item)
        {
            Items.Add(item);
            return Items.Count;
        }

        public bool RemoveItem(Item item)
        {
            Items.Remove(item);
            return Items.Contains(item);
        }

    }
}