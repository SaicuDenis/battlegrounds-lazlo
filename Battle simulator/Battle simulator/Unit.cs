using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Battle_simulator
{
    public class Unit
    {
        public int As, Ds, Fp, Armor, HP;
        public PointF maploc;
        public int size;
        public string name;
        public Color FillColor;
        public bool destroy;
        public Unit(string name,int As,int Ds,int Fp,int armor,int hp)
        {
            this.name = name;
            this.As = As;
            this.Ds = Ds;
            this.Fp = Fp;
            Armor = armor;
            HP = hp;
            maploc = Engine.getrndpoint();
            destroy = false;
        }
        public void draw(Graphics grp)
        {
            grp.FillEllipse(new SolidBrush(FillColor), maploc.X - size / 2, maploc.Y - size / 2, size + 1, size + 1);
            grp.DrawEllipse(Pens.Black, maploc.X - size / 2, maploc.Y - size / 2, size + 1, size + 1);
            grp.DrawString(HP.ToString(), new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.Black), maploc);
        }
    }
}
