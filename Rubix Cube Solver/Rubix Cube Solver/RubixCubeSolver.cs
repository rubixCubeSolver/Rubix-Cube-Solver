using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rubix_Cube_Solver
{
    public partial class RubixCubeSolver : Form
    {
        public RubixCubeSolver()
        {
            InitializeComponent();
        }

        Color draw_color = Color.Black;

        private void pick_color(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Button[] colors = {White, Yellow, Red, Orange, Green, Blue};
            foreach (Button c in colors)
                c.FlatAppearance.BorderSize = 1;

            btn.FlatAppearance.BorderSize = 3;
            draw_color = btn.BackColor;
        }

        private void Bchange_color(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            if(draw_color != Color.Black)
                pb.BackColor = draw_color;
        }

        private void Breset_Click(object sender, EventArgs e)
        {
            //White
            PictureBox[] whites = { a1, a2, a3, b1, b2, b3, c1, c2, c3 };
            foreach (PictureBox w in whites)
                w.BackColor = Color.White;

            //Yellows
            PictureBox[] yellows = { g1, g2, g3, h1, h2, h3, i1, i2, i3 };
            foreach (PictureBox y in yellows)
                y.BackColor = Color.Yellow;

            //Red
            PictureBox[] reds = { d4, d5, d6, e4, e5, e6, f4, f5, f6 };
            foreach (PictureBox r in reds)
                r.BackColor = Color.Red;

            //Orange
            PictureBox[] oranges = { d10, d11, d12, e10, e11, e12, f10, f11, f12 };
            foreach (PictureBox o in oranges)
                o.BackColor = Color.Orange;

            //Green
            PictureBox[] green = { d1, d2, d3, e1, e2, e3, f1, f2, f3 };
            foreach (PictureBox g in green)
                g.BackColor = Color.Green;

            //Blue
            PictureBox[] blues = { d7, d8, d9, e7, e8, e9, f7, f8, f9 };
            foreach (PictureBox b in blues)
                b.BackColor = Color.Blue;
        }

        private void Solve_Click(object sender, EventArgs e)
        {
            //Making the side arrays
            //----------------------

            //whtie center
            Color[,] whiteC = new Color[,] { { ctc(a1), ctc(a2), ctc(a3) },
                                             { ctc(b1), ctc(b2), ctc(b3) },
                                             { ctc(c1), ctc(c2),  ctc(c3)} };
            //grean center
            Color[,] greenC = new Color[,] { { ctc(d1), ctc(d2), ctc(d3) },
                                             { ctc(e1), ctc(e2), ctc(e3) },
                                             { ctc(f1), ctc(f2),  ctc(f3)} };
            //red center
            Color[,] redC = new Color[,] { { ctc(d4), ctc(d5), ctc(d6) },
                                             { ctc(e4), ctc(e5), ctc(e6) },
                                             { ctc(f4), ctc(f5),  ctc(f6)} };
            //yellow center
            Color[,] yellowC = new Color[,] { { ctc(g1), ctc(g2), ctc(g3) },
                                             { ctc(h1), ctc(h2), ctc(h3) },
                                             { ctc(i1), ctc(i2),  ctc(i3)} };
            //blue center
            Color[,] blueC = new Color[,] { { ctc(d7), ctc(d8), ctc(d9) },
                                             { ctc(e7), ctc(e8), ctc(e9) },
                                             { ctc(f7), ctc(f8),  ctc(f9)} };
            //orange center
            Color[,] orangeC = new Color[,] { { ctc(d10), ctc(d11), ctc(d12) },
                                             { ctc(e10), ctc(e11), ctc(e12) },
                                             { ctc(f10), ctc(f11),  ctc(f12)} };


            //setting the side cubits

        }

        private Color ctc(PictureBox pc)
        {
            return pc.BackColor;
        }

    }
}
