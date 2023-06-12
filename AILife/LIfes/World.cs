using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;


namespace AILife.LIfes
{
    public class World
    {
        public static World instance = new World();

        public const int 縦幅 = 500;
        public const int 横幅 = 500;

        Mat 栄養マップ = new Mat(縦幅, 横幅, MatType.CV_16UC1);
        List<AbstractLife> 生命リスト = new List<AbstractLife>();

        public void 初期化()
        {
            生命リスト.Add(new ProtoPrant()
            {
                縦位置 = 250,
                横位置 = 250,
                大きさ = 5,
            });

            栄養マップ.Rectangle(new Rect()
            {
                X = 0,
                Y = 0,
                Height = 500,
                Width = 500
            }, new Scalar(1000), -1);
        }
        public void 時間()
        {
            for (int i = 0; i < 生命リスト.Count; i++)
            {
                生命リスト[i].動作();
            }
        }
        public void 後時間()
        {
            for (int i = 0; i < 生命リスト.Count; i++)
            {
                生命リスト[i].後動作();
            }
        }

        public void 描画(Mat mat)
        {
            mat.Rectangle(new Rect(0, 0, 横幅, 縦幅), Scalar.Black);
            foreach (var 生命 in 生命リスト)
            {
                生命.描画(mat);
            }
        }


        public bool 産み付け(AbstractLife newPop)
        {
            if (newPop.縦位置 < 0 || newPop.縦位置 > 縦幅 || newPop.横位置 < 0 || newPop.横位置 > 横幅)
            {
                return false;
            }


            foreach (var 生命 in 生命リスト)
            {
                var 縦距離 = Math.Pow(生命.縦位置 - newPop.縦位置, 2);
                var 横距離 = Math.Pow(生命.横位置 - newPop.横位置, 2);
                var 距離 = Math.Pow(生命.大きさ + newPop.大きさ, 2);

                if (縦距離 + 横距離 < 距離)
                {
                    return false;
                }
            }

            生命リスト.Add(newPop);
            return true;
        }

        public void 栄養取得(AbstractLife life)
        {
            var 栄養 = 栄養マップ.Get<ushort>((int)life.横位置, (int)life.縦位置, 0);
            if (栄養 > 0)
            {
                life.食事(10);
                栄養マップ.Set((int)life.横位置, (int)life.縦位置, 0, 栄養 - 10);
            }
        }


    }
}
