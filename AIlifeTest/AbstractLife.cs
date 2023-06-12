using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIlifeTest
{
    public abstract class AbstractLife
    {
        public float 横位置 { get; set; } 
        public float 縦位置 { get; set; }
        public float 大きさ { get; set; }
        public float 栄養 { get; set; }

        public abstract void 動作();
        public abstract void 食事(float 栄養);
        public abstract void 描画(Mat mat);
        public abstract AbstractLife 繁殖();
    }
}
