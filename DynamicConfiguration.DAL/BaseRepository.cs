﻿using DynamicConfiguration.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicConfiguration.DAL
{
    public abstract class BaseRepository<TModel> where TModel : BaseModel
    {
        protected IMongoCollection<TModel> mongoCollection;

        public BaseRepository(string mongoDBConnectionString, string dbName, string collectionName)
        {
            var client = new MongoClient(mongoDBConnectionString);
            var database = client.GetDatabase(dbName);
            mongoCollection = database.GetCollection<TModel>(collectionName);
        }

        public virtual List<TModel> GetList()
        {
            return mongoCollection.Find(m => true).ToList();
        }

        public virtual TModel GetById(string id)
        {
            var docId = new ObjectId(id);
            return mongoCollection.Find<TModel>(m => m.Id == id).FirstOrDefault();
        }

        public virtual TModel Create(TModel model)
        {
            mongoCollection.InsertOne(model);
            return model;
        }

        public virtual void Update(string id, TModel model)
        {
            var docId = new ObjectId(id);
            mongoCollection.ReplaceOne(m => m.Id == id, model);
        }

        public virtual void Delete(TModel model)
        {
            mongoCollection.DeleteOne(m => m.Id == model.Id);
        }

        public virtual void Delete(string id)
        {
            var docId = new ObjectId(id);
            mongoCollection.DeleteOne(m => m.Id == id);
        }
    }
}
