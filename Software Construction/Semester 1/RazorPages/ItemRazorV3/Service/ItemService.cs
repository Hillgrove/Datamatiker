﻿using ItemRazorV1.MockData;
using ItemRazorV1.Models;

namespace ItemRazorV1.Service
{
    public class ItemService : IItemService
    {
        private List<Item> _items;

        public ItemService()
        {
            _items = MockItems.GetMockItems();
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public List<Item> GetItems() { return _items; }

        public IEnumerable<Item> NameSearch(string str)
        {
            List<Item> nameSearch = new List<Item>();
            foreach (Item item in  _items)
            {
                if (string.IsNullOrEmpty(str) || item.Name.ToLower().Contains(str.ToLower()))
                {
                    nameSearch.Add(item);
                }
            }
            return nameSearch;
        }

        public IEnumerable<Item> PriceFilter(int maxPrice, int minPrice = 0)
        {
            List<Item> filterList = new List<Item>();
            foreach (Item item in _items)
            {
                if (minPrice == 0 && item.Price <= maxPrice ||
                    maxPrice == 0 && item.Price >= minPrice ||
                    minPrice <= item.Price && item.Price <= maxPrice)
                {
                    filterList.Add(item);
                }
            }
            return filterList;
		}
	}
}
