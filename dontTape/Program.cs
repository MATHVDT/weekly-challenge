

// See https://aka.ms/new-console-template for more information
using System.Drawing;


Console.WriteLine("Hello, World!");



//This is a replacement for Cursor.Position in WinForms
[System.Runtime.InteropServices.DllImport("user32.dll")]
static extern bool SetCursorPos(int x, int y);

[System.Runtime.InteropServices.DllImport("user32.dll")]
static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

const int MOUSEEVENTF_LEFTDOWN = 0x02;
const int MOUSEEVENTF_LEFTUP = 0x04;

SetCursorPos(0, 0);


dontTap.PrintScreen ps = new dontTap.PrintScreen();

Image screen = ps.CaptureScreen();
Bitmap bmp = new Bitmap(screen);

var hauteur = bmp.Height;
var largeur = bmp.Width;

Console.WriteLine($"Hauteur : {hauteur} et Largeur : {largeur}");

int nbLignes = 4, nbColonnes = 4;
int minX = 650, maxX = 1295;
int minY = 235, maxY = 875;
int largeurCase = (maxX - minX) / nbColonnes;
int hauteurCase = (maxY - minY) / nbLignes;

int[] listCoordX = new int[nbLignes];
int[] listCoordY = new int[nbColonnes];

for (int i = 0; i < nbColonnes; i++)
{
    listCoordX[i] = minX + i * largeurCase + largeurCase / 2;
}
for (int i = 0; i < nbLignes; i++)
{
    listCoordY[i] = minY + i * hauteurCase + hauteurCase / 2;
}

Console.WriteLine("Début dans 5s");
Thread.Sleep(5000);

SetCursorPos(900, 880);
mouse_event(MOUSEEVENTF_LEFTDOWN, 900, 880, 0, 0);
mouse_event(MOUSEEVENTF_LEFTUP, 900, 880, 0, 0);



Color caseCouleurNoire = Color.FromArgb(255, 0, 0, 0);
Color caseCouleurBlanche = Color.White;

int score = 0;
string path = "E:\\OneDrive - Université Clermont Auvergne\\dontTap\\";

int[] listScores = { 30, 50, 100, 222, 444, 8324, 8678, 9014, 9552, 9874, 10004, 12532, 15395, 205478, 30000, 40000, 80000, 1000000 };
int save = 0;

while (true)
{
    if (false && save < listScores.Count() && score >= listScores[save] - 10 && score <= listScores[save] + 10)
    {
        Console.WriteLine($"save : {save}, listScores : {listScores}, score : {score}");
        SetCursorPos(listCoordX[0], listCoordY[0]);
        mouse_event(MOUSEEVENTF_LEFTDOWN, listCoordX[0], listCoordY[0], 0, 0);
        mouse_event(MOUSEEVENTF_LEFTUP, listCoordX[0], listCoordY[0], 0, 0);
        mouse_event(MOUSEEVENTF_LEFTDOWN, listCoordX[0], listCoordY[0], 0, 0);
        mouse_event(MOUSEEVENTF_LEFTUP, listCoordX[0], listCoordY[0], 0, 0);
        mouse_event(MOUSEEVENTF_LEFTDOWN, listCoordX[0], listCoordY[0], 0, 0);
        mouse_event(MOUSEEVENTF_LEFTUP, listCoordX[0], listCoordY[0], 0, 0);
        Thread.Sleep(5000);
        SetCursorPos(0,0);

        ps.CaptureScreenToFile(path + score.ToString() + ".png", System.Drawing.Imaging.ImageFormat.Png);
        ++save;
        score = 0;

        SetCursorPos(900, 880);
        mouse_event(MOUSEEVENTF_LEFTDOWN, 900, 880, 0, 0);
        mouse_event(MOUSEEVENTF_LEFTUP, 900, 880, 0, 0);
        mouse_event(MOUSEEVENTF_LEFTDOWN, 900, 880, 0, 0);
        mouse_event(MOUSEEVENTF_LEFTUP, 900, 880, 0, 0);
        mouse_event(MOUSEEVENTF_LEFTDOWN, 900, 880, 0, 0);
        mouse_event(MOUSEEVENTF_LEFTUP, 900, 880, 0, 0);


    }

    Thread.Sleep(200);
    screen = ps.CaptureScreen();
    bmp = new Bitmap(screen);

    foreach (var coordY in listCoordY)
    {
        foreach (var coordX in listCoordX)
        {
            if (bmp.GetPixel(coordX, coordY) == caseCouleurNoire)
            {
                //Console.WriteLine("Couleur " + bmp.GetPixel(coordX, coordY));
                SetCursorPos(coordX, coordY);
                mouse_event(MOUSEEVENTF_LEFTDOWN, coordX, coordY, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, coordX, coordY, 0, 0);
                ++score;
            }
        }
    }
}


