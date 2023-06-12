





using AIlifeTest;
using OpenCvSharp;


Window window = new Window();

Mat image = new Mat(500, 500, MatType.CV_8UC3);
while (true)
{

    World.instance.初期化();
    World.instance.時間();
    World.instance.描画(image);

    await Task.Run(() => {
        window.ShowImage(image);
    });
    Thread.Sleep(100);
}



