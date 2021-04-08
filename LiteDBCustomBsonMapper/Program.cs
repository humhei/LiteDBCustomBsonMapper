using LiteDB;
using System;
using System.IO;

namespace LiteDBCustomBsonMapper
{
    public class MyBsonMapper : BsonMapper
    {

        public override object ToObject(Type type, BsonDocument doc)
        {
            /// this code never get invoked
            throw new NotSupportedException();
        }

        public override T ToObject<T>(BsonDocument doc)
        {
            /// this code never get invoked
            throw new NotSupportedException();
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            var myBsonMapper = new MyBsonMapper();
            var liteDB = new LiteDatabase(new MemoryStream(), myBsonMapper);
            var peopleCol = liteDB.GetCollection<People>();

            peopleCol.Insert(new People() { Id = ObjectId.NewObjectId(), Age = 20, Name = "Mike" });

            var findedPeople = peopleCol.Find(m => m.Name == "Mike");

            Console.WriteLine("Hello World!");
        }
    }

    public class People
    {
        public ObjectId Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
