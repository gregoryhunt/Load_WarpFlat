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
            //LoadSpdata();
            GetMenu();        
        }
        private static void GetMenu()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Demo");
            var collection = database.GetCollection<CellInfo>("spdata").AsQueryable();
            var query = from s in collection
                        select s;
            var menuRecords = collection
                .Where(c => (c.lit.StartsWith("+F1") || c.lit.StartsWith("+T1")) && (c.hmenucode.Equals("1") || c.hmenucode.Equals("2") || c.hmenucode.Equals("3")))
                .OrderBy(c => c.hmenucode)
                .ThenBy(c => c.menu)
                .ToList();


            var t = menuRecords.Where(c => c.menu.StartsWith("CI5") && c.hmenucode.Equals("3")).ToList();
            List<Menu> menus = new List<Menu>();
            foreach (var menuRecord in menuRecords.Where(c => c.hmenucode.Equals("1")))
            {
                Menu menu = new Menu
                {
                    Code = menuRecord.menu,
                    Title = menuRecord.lit.Substring(3)
                };
                if (menuRecord.lit.Substring(0,3).Equals("+F1"))
                {
                    var subMenuRecords = menuRecords.Where(s => s.menu.StartsWith(menu.Code.Substring(0, 2)) && s.hmenucode.Equals("2"));
                    if (subMenuRecords.Count() > 0)
                    {
                        menu.Children = new List<Menu>();
                        foreach (var subMenuRecord in subMenuRecords)
                        {
                            var subMenu = new Menu
                            {
                                Code = subMenuRecord.menu,
                                Title = subMenuRecord.lit.Substring(3)
                            };
                            if (subMenuRecord.lit.Substring(0, 3).Equals("+F1"))
                            {
   
                                var subSubMenuRecords = menuRecords.Where(s => s.menu.StartsWith(subMenu.Code.Substring(0, 3)) && s.hmenucode.Equals("3"));
                                if (subSubMenuRecords.Count() > 0)
                                {
                                    subMenu.Children = new List<Menu>();
                                    foreach (var subSubMenuRecord in subSubMenuRecords)
                                    {
                                        var subSubMenu = new Menu
                                        {
                                            Code = subSubMenuRecord.menu,
                                            Title = subSubMenuRecord.lit.Substring(3)
                                        };
                                        if (subSubMenuRecord.lit.Substring(0, 3).Equals("+T1"))
                                        {
                                            subSubMenu.Script = subSubMenuRecord.selcalcstr.Trim('"');
                                        }
                                        subMenu.Children.Add(subSubMenu);
                                    }
                                }

                            }
                            else if (subMenuRecord.lit.Substring(0, 3).Equals("+T1"))
                            {
                                subMenu.Script = subMenuRecord.selcalcstr.Trim('"');
                            }
                            menu.Children.Add(subMenu);
                        }
                    }

                }
                else if (menuRecord.lit.Substring(0, 3).Equals("+T1"))
                {
                    menu.Script = menuRecord.selcalcstr.Trim('"');
                }
                menus.Add(menu);
            }
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
