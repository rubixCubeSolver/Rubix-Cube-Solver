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
        //The cube is in a fixed position, white on top, red in front

        #region variables

        Color draw_color = Color.Black;
        cubit s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12;
        cubit cnr1, cnr2, cnr3, cnr4, cnr5, cnr6, cnr7, cnr8;
        Color[,] whiteC;
        Color[,] greenC;
        Color[,] redC;
        Color[,] yellowC;
        Color[,] blueC;
        Color[,] orangeC;
        #endregion

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
            Update();

            #region setting the side cubits

            s1 = new cubit(blueC[0, 1], whiteC[1, 2]);
            s2 = new cubit(blueC[1, 2], orangeC[1, 0]);
            s3 = new cubit(blueC[1, 0], redC[1, 2]);
            s4 = new cubit(blueC[2, 1], yellowC[1, 2]);
            s5 = new cubit(redC[0, 1], whiteC[2, 1]);
            s6 = new cubit(redC[1, 0], greenC[1, 2]);
            s7 = new cubit(redC[2, 1], yellowC[0, 1]);
            s8 = new cubit(greenC[0, 1], whiteC[1, 0]);
            s9 = new cubit(greenC[1, 0], orangeC[1, 2]);
            s10 = new cubit(greenC[2, 1], yellowC[1, 0]);
            s11 = new cubit(orangeC[0, 1], whiteC[0, 1]);
            s12 = new cubit(orangeC[2, 1], yellowC[2, 1]);

            cubit[] sides = { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12};



            #endregion

            #region setting the corner cubits

            cnr1 = new cubit(yellowC[2,2], blueC[2,2], orangeC[2,0]);
            cnr2 = new cubit(yellowC[2,0], orangeC[2,2], greenC[2,0]);
            cnr3 = new cubit(yellowC[0,0], greenC[2,2], redC[2,0]);
            cnr4 = new cubit(yellowC[0,2], redC[2,2], blueC[2,0]);

            cnr5 = new cubit(whiteC[0,2], orangeC[0,0], blueC[0,2]);
            cnr6 = new cubit(whiteC[2,2],blueC[0,0], redC[0,2]);
            cnr7 = new cubit(whiteC[2, 0], redC[0, 0], greenC[0, 2]);
            cnr8 = new cubit(whiteC[0, 0], greenC[0, 0], orangeC[0, 2]);

            cubit[] corners = { cnr1, cnr2, cnr3, cnr4, cnr5, cnr6, cnr7, cnr8 };

            #endregion

            front();


        }

        private new void Update()
        {
            //whtie center
            whiteC = new Color[,] { { ctc(a1), ctc(a2), ctc(a3) },
                                             { ctc(b1), ctc(b2), ctc(b3) },
                                             { ctc(c1), ctc(c2),  ctc(c3)} };
            //green center
            greenC = new Color[,] { { ctc(d1), ctc(d2), ctc(d3) },
                                             { ctc(e1), ctc(e2), ctc(e3) },
                                             { ctc(f1), ctc(f2),  ctc(f3)} };
            //red center
            redC = new Color[,] { { ctc(d4), ctc(d5), ctc(d6) },
                                             { ctc(e4), ctc(e5), ctc(e6) },
                                             { ctc(f4), ctc(f5),  ctc(f6)} };
            //yellow center
            yellowC = new Color[,] { { ctc(g1), ctc(g2), ctc(g3) },
                                             { ctc(h1), ctc(h2), ctc(h3) },
                                             { ctc(i1), ctc(i2),  ctc(i3)} };
            //blue center
            blueC = new Color[,] { { ctc(d7), ctc(d8), ctc(d9) },
                                             { ctc(e7), ctc(e8), ctc(e9) },
                                             { ctc(f7), ctc(f8),  ctc(f9)} };
            //orange center
            orangeC = new Color[,] { { ctc(d10), ctc(d11), ctc(d12) },
                                             { ctc(e10), ctc(e11), ctc(e12) },
                                             { ctc(f10), ctc(f11),  ctc(f12)} };
        }

        private void front()
        {
            for (int i = 0; i <= 2; i++)
            {
                blueC[i, 0] = whiteC[0, i];
                MessageBox.Show(blueC[i, 0].ToString());
            }

        }

        private Color ctc(PictureBox pc)
        {
            return pc.BackColor;
        }
    }
}
