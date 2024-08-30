using gestionaleMedeXpress.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestionaleMedeXpress.Services
{
    public class OrderService
    {
        private readonly IMongoCollection<Order> _ordersCollection;

        public OrderService(IOptions<MedeXpressDatabaseSettings> medeXpressDatabaseSettings)
        {
            var mongoClient = new MongoClient(medeXpressDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(medeXpressDatabaseSettings.Value.DatabaseName);
            _ordersCollection = mongoDatabase.GetCollection<Order>(medeXpressDatabaseSettings.Value.OrdersCollectionName);
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _ordersCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Order> GetOrderAsync(string id)
        {
            return await _ordersCollection.Find(order => order.Id == id).FirstOrDefaultAsync();
        }
    }
}
