using System;
using System.Collections.Generic;
using System.Text;

namespace Load_WarpFlat.Model
{
    public class Menu
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public List<Menu> Children { get; set; }
        public string Script { get; set; }
    }
}
