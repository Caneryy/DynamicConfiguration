using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicConfiguration.Model
{
    public abstract class BaseModel
    {
        public ObjectId Id { get; set; }
    }
}
