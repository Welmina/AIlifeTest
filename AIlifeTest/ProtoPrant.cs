using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIlifeTest
{
    public  class ProtoPrant : AbstractLife
    {
        public static Random random = new Random(100);

        public override void 動作()
        {
            World.instance.栄養取得(this);

            if (this.栄養 > 100)
            {
                if (World.instance.産み付け(繁殖()))
                {
                    栄養 -= 20;
                }
            }
        }

        public override AbstractLife 繁殖()
        {
            var 新生命 = new ProtoPrant()
            {
                縦位置 = 縦位置 + random.Next(-1, 1) * 大きさ * 2,
                横位置 = 横位置 + random.Next(-1, 1) * 大きさ * 2,
                大きさ = 1,
                栄養 = 10
            };

            return 新生命;
        }

        public override void 描画(Mat mat)
        {
            mat.Circle((int)横位置, (int)縦位置, (int)大きさ, Scalar.Red);
        }

        public override void 食事(float 栄養)
        {
            this.栄養 += 栄養;
        }
    }
}
