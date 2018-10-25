using Load_WarpFlat.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Load_WarpFlat
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadSpdata();
        }
        private static void LoadSpdata()
        {
            var spdata = File.ReadAllBytes("spdataflat.dat");
            List<BsonDocument> spdatas = new List<BsonDocument>();

            for (int i = 0; i < spdata.Length; i += 512)
            {
                byte[] row = spdata.Slice(i, 512);
                char[] line = row.Select(b => (char)b).ToArray();

                CellInfo cell = new CellInfo(row);
                var bs = cell.ToBsonDocument();
                spdatas.Add(bs);
            }
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Demo");
            database.DropCollection("spdata");
            var collection = database.GetCollection<BsonDocument>("spdata");
            collection.InsertMany(spdatas);
        }

        private static List<SpdataMapItem> GenerateMap(string filename)
        {
            List<SpdataMapItem> list = new List<SpdataMapItem>();
            foreach (string line in File.ReadAllLines(filename).Skip(1))
            {
                var vals = line.Split(',');
                list.Add(
                    new SpdataMapItem()
                    {
                        Name = vals[0],
                        StartingPosition = Int32.Parse(vals[1]),
                        Length = Int32.Parse(vals[2]),
                        Type = (FieldType)Enum.Parse(typeof(FieldType), vals[3])
                    });
            }
            return list.OrderBy(i => i.StartingPosition).ToList();
        }
    }
}
