using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Skladala.Core.Interfaces;
using Skladala.Persistence.Models;
using Skladala.Persistence.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skladala.Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : IProduct
    {
        private readonly IMongoCollection<T> _collection;

        public Repository(IOptions<DBSetings> dbSetings)
        {
            var mongoClient = new MongoClient(dbSetings.Value.ConnectionString);
            var mongoDB = mongoClient.GetDatabase(dbSetings.Value.DBName);
            _collection = mongoDB.GetCollection<T>(dbSetings.Value.ColectionName);
        }

        public async Task CreateAsync(T model)
        {
            await _collection.InsertOneAsync(model);
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken)
        {
            await _collection.DeleteOneAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<T> GetAsync(string id, CancellationToken cancellationToken)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAsync(CancellationToken cancellationToken)
        {
            return await _collection.Find(_ => true).ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(T model)
        {
            await _collection.ReplaceOneAsync(x => x.Id == model.Id, model);
        }
    }
}
