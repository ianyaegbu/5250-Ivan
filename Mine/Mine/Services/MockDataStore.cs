using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mine.Models;

namespace Mine.Services
{
    public class MockDataStore : IDataStore<ItemModel>
    {
        readonly List<ItemModel> items;

        public MockDataStore()
        {
            items = new List<ItemModel>()
            {
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "X-ray Googles", Description="Wait, cars have skeleton?!", Value=2},
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Armored body", Description="With this I can take on the world!", Value=6},
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Hyper Drive Boosters", Description="Umm...can I get insurance with these?", Value=8 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "A simple pen", Description="Don't write while driving please!", Value=0 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Drift Supporters", Description="Fast & Furious here I come!", Value=7 }
            };
        }

        public async Task<bool> CreateAsync(ItemModel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(ItemModel item)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ItemModel> IndexAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ItemModel>> ReadAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}