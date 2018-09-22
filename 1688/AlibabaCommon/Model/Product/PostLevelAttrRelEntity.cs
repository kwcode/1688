using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Product
{
    public class PostLevelAttrRelEntity
    {
        public int fid { get; set; }
        public int[] subFids { get; set; }
        public int attrType { get; set; }
    }
}
