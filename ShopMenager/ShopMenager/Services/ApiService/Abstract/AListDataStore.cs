
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace ShopMenager.Services.ApiService.Abstract
{
    public abstract class AListDataStore<T> : IDataStore<T>
    {
        public List<T> items;
        public AListDataStore()
        {
        }
        public abstract Task Refresh();
        public abstract Task<bool> DeleteItemFromService(T item);
        public abstract Task<bool> UpdateItemInService(T item);
        public abstract Task<bool> AddItemToService(T item);
        public async Task<bool> AddItemAsync(T item)
        {
            await AddItemToService(item);
            await Refresh();
            return await Task.FromResult(true);
        }
        public abstract T Find(T item);
        public abstract T Find(int id);
        public async Task<bool> UpdateItemAsync(T item)
        {
            await UpdateItemInService(item);
            await Refresh();
            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = Find(id);
            await DeleteItemFromService(oldItem);
            await Refresh();
            return await Task.FromResult(true);
        }
        public async Task<T> GetItemAsync(int id)
            => await Task.FromResult(Find(id));
        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            await Refresh();
            return await Task.FromResult(items);

            //wydajniejsze rozwiązanie ale potrzeba rozbuudować wszystkie widoki dodawania 
            //    o zarządzanie odświeżaniem items (w planach )
            //if (forceRefresh || items == null || items.Count == 0)
            //    await Refresh();

            //return items;
        }
    }
}
