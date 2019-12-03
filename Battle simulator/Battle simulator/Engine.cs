using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
namespace Battle_simulator
{
    public static class Engine
    {
        public static PictureBox Display;
        public static int rezX, rezY;
        public static Bitmap bmp;
        public static Graphics grp;
        public static Color backcolor = Color.LightGreen;
        public static Random rnd = new Random();
        public static PointF getrndpoint()
        {
            return new PointF(rnd.Next(rezX - 20) + 10, rnd.Next(rezY - 20) + 10);
        }

        public static void initgraf(PictureBox display)
        {

            Display = display;
            rezX = display.Width;
            rezY = display.Height;
            bmp = new Bitmap(rezX, rezY);
            grp = Graphics.FromImage(bmp);
            grp.Clear(backcolor);
            Display.Image = bmp;
        }
        public static List<Unit> army1 = new List<Unit>();
        public static List<Unit> army2 = new List<Unit>();
        public static void initdemo()
        {
            for (int i = 0; i < 10; i++)
            {
                Unit a = new Unit("peasent "+i, 3, 3, 3, 0, 50);
                a.FillColor = Color.White;
                a.size = 10;
                army1.Add(a);
            }
            for (int i = 0; i < 5; i++)
            {
                Unit b = new Unit("knight" + i, 10, 5, 5, 5, 200);
                b.FillColor = Color.LightGray;
                b.size = 15;
                army1.Add(b);
            }
            for (int i = 0; i < 5; i++)
            {
                Unit c = new Unit("orc" + i, 10,10,10,3,500);
                c.FillColor = Color.Green;
                c.size = 25;
                army2.Add(c);
            }

        }
        public static void DrawMap()
        {
            foreach (Unit a in army1)
                a.draw(grp);
            foreach (Unit a in army2)
                a.draw(grp);
            Display.Image = bmp;
        }
        public static bool amc(Unit a, Unit b)
        {
            int t = rnd.Next(a.As + b.Ds);
            if (t < a.As)
                return true;
            return false;
        }
        public static void battlewave(List<Unit> A,List <Unit> B)
        {
            if (A.Count >= 0 && B.Count >= 0)
            {
                foreach (Unit u in A)
                {

                    int Target = rnd.Next(B.Count);
                    if (amc(u, B[Target]))
                    {
                        int fp = u.Fp;
                        int ar = B[Target].Armor;
                        while (fp > 0 && ar > 0)
                        {
                            int t = rnd.Next(2);
                            if (t == 0)
                                fp--;
                            else
                                ar--;
                        }

                        if (fp > 0)
                        {
                            B[Target].HP -= fp;
                            if (B[Target].HP <= 0)
                            {
                                B[Target].destroy = true;
                            }
                        }

                    }
                }
            }
        }
        public static void BattleCycle()
        {
            battlewave(army1, army2);
            battlewave(army2, army1);
            army1 = army1.FindAll(delegate (Unit u) { return !u.destroy; });
            army2 = army2.FindAll(delegate (Unit u) { return !u.destroy; });
        }
    }
}
