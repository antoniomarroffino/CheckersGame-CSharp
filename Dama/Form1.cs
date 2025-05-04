using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dama
{

    public partial class Form1 : Form
    {
        const int RIGHE = 8;
        const int COLONNE = 8;
        public PanelRC[,] tabella = new PanelRC[RIGHE, COLONNE];
        int tempR;
        int tempC;
        bool turnoGiocatore1 = true;
        public Form1()
        {
            InitializeComponent();
        }
        private void playGame(object sender, EventArgs e)
        {
            title.Visible = false;
            title2.Visible = false;
            buttonPlay.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;



            bool pedina = true;
            creaTabella(pedina);
        }
        private void creaTabella(bool pedina)
        {
            int startR = 0;
            int startC = 0;
            for (int r = 0; r < RIGHE; r++)
            {
                for (int c = 0; c < COLONNE; c++)
                {
                    tabella[r, c] = new PanelRC();
                    if ((r + c) % 2 == 0)
                    {
                        tabella[r, c].BackColor = Color.Black;
                        if (r < 3)
                        {
                            tabella[r, c].pedina = new Pedina();
                            if (pedina)
                            {
                                tabella[r, c].pedina.Image = Image.FromFile("pedina nera.png");
                                tabella[r, c].pedina.colore = Color.Black;
                            }

                            else
                            {
                                tabella[r, c].pedina.Image = Image.FromFile("pedina bianca.png");
                                tabella[r, c].pedina.colore = Color.White;
                            }


                            tabella[r, c].pedina.SizeMode = PictureBoxSizeMode.AutoSize;
                            tabella[r, c].pedinaPresente = true;
                            tabella[r, c].pedina.r = r;
                            tabella[r, c].pedina.c = c;

                            tabella[r, c].pedina.Click += new System.EventHandler(this.mostraMosse);

                            this.tabella[r, c].Controls.Add(tabella[r, c].pedina);
                        }
                        else if (r > 4)
                        {
                            tabella[r, c].pedina = new Pedina();
                            if (pedina)
                            {
                                tabella[r, c].pedina.Image = Image.FromFile("pedina bianca.png");
                                tabella[r, c].pedina.colore = Color.White;
                            }

                            else
                            {
                                tabella[r, c].pedina.Image = Image.FromFile("pedina nera.png");
                                tabella[r, c].pedina.colore = Color.Black;
                            }

                            tabella[r, c].pedina.SizeMode = PictureBoxSizeMode.AutoSize;
                            tabella[r, c].pedinaPresente = true;
                            tabella[r, c].pedina.r = r;
                            tabella[r, c].pedina.c = c;

                            tabella[r, c].pedina.Click += new System.EventHandler(this.mostraMosse);


                            this.tabella[r, c].Controls.Add(tabella[r, c].pedina);

                        }
                    }
                    else
                        tabella[r, c].BackColor = Color.White;



                    tabella[r, c].r = r;
                    tabella[r, c].c = c;

                    tabella[r, c].Width = 60;
                    tabella[r, c].Height = 60;
                    startC = r * tabella[r, c].Width + 50;
                    startR = c * tabella[r, c].Width + 50;
                    tabella[r, c].Location = new System.Drawing.Point(startR, startC);


                    tabella[r, c].colore = 0;

                    this.panel1.Controls.Add(tabella[r, c]);

                }
            }
        }
        private void mostraMosse(object sender, EventArgs e)
        {
            Pedina pedina = ((Pedina)sender);
            PanelRC cella = tabella[pedina.r, pedina.c];

            tempR = cella.r;
            tempC = cella.c;

            cancellaMosse();


            if (turnoGiocatore1 == true || pedina.damone)
            {
                if (tabella[cella.r, cella.c].pedina.colore == Color.White)
                {
                    if (cella.r > 0)
                    {
                        if (cella.c > 0)
                        {
                            if (tabella[cella.r - 1, cella.c - 1].pedina == null)
                            {
                                tabella[cella.r - 1, cella.c - 1].BackColor = Color.Green;
                                tabella[cella.r - 1, cella.c - 1].Click += new System.EventHandler(this.posizionaPedina);
                            }
                            else if (tabella[cella.r - 1, cella.c - 1].pedina.colore == Color.Black)
                            {
                                if (cella.r > 1)
                                {
                                    if (cella.c > 1)
                                    {
                                        if (tabella[cella.r - 2, cella.c - 2].pedina == null)
                                        {
                                            tabella[cella.r - 1, cella.c - 1].pedina.pedinaMangiata = true;
                                            tabella[cella.r - 2, cella.c - 2].BackColor = Color.Green;
                                            tabella[cella.r - 2, cella.c - 2].Click += new System.EventHandler(this.posizionaPedina);
                                        }
                                    }
                                }
                            }
                        }
                        if (cella.c < COLONNE - 1)
                        {
                            if (tabella[cella.r - 1, cella.c + 1].pedina == null)
                            {
                                tabella[cella.r - 1, cella.c + 1].BackColor = Color.Green;
                                tabella[cella.r - 1, cella.c + 1].Click += new System.EventHandler(this.posizionaPedina);
                            }
                            else if (tabella[cella.r - 1, cella.c + 1].pedina.colore == Color.Black)
                            {
                                if (cella.r > 1)
                                {
                                    if (cella.c < COLONNE - 2)
                                    {
                                        if (tabella[cella.r - 2, cella.c + 2].pedina == null)
                                        {
                                            tabella[cella.r - 1, cella.c + 1].pedina.pedinaMangiata = true;
                                            tabella[cella.r - 2, cella.c + 2].BackColor = Color.Green;
                                            tabella[cella.r - 2, cella.c + 2].Click += new System.EventHandler(this.posizionaPedina);
                                        }
                                    }
                                }
                            }
                        }

                    }
                }

            }

            if (turnoGiocatore1 == false || pedina.damone)
            {
                if (tabella[cella.r, cella.c].pedina.colore == Color.Black)
                {
                    if (cella.r < RIGHE)
                    {
                        if (cella.c > 0)
                        {
                            if (tabella[cella.r + 1, cella.c - 1].pedina == null)
                            {
                                tabella[cella.r + 1, cella.c - 1].BackColor = Color.Green;
                                tabella[cella.r + 1, cella.c - 1].Click += new System.EventHandler(this.posizionaPedina);
                            }
                            else if (tabella[cella.r + 1, cella.c - 1].pedina.colore == Color.White)
                            {
                                if (cella.r < RIGHE - 1)
                                {
                                    if (cella.c > 1)
                                    {
                                        if (tabella[cella.r + 2, cella.c - 2].pedina == null)
                                        {
                                            tabella[cella.r + 1, cella.c - 1].pedina.pedinaMangiata = true;
                                            tabella[cella.r + 2, cella.c - 2].BackColor = Color.Green;
                                            tabella[cella.r + 2, cella.c - 2].Click += new System.EventHandler(this.posizionaPedina);
                                        }
                                    }
                                }
                            }
                        }

                        if (cella.c < COLONNE - 1)
                        {
                            if (tabella[cella.r + 1, cella.c + 1].pedina == null)
                            {
                                tabella[cella.r + 1, cella.c + 1].BackColor = Color.Green;
                                tabella[cella.r + 1, cella.c + 1].Click += new System.EventHandler(this.posizionaPedina);
                            }
                            else if (tabella[cella.r + 1, cella.c + 1].pedina.colore == Color.White)
                            {
                                if (cella.r < RIGHE - 1)
                                {
                                    if (cella.c < COLONNE - 2)
                                    {
                                        if (tabella[cella.r + 2, cella.c + 2].pedina == null)
                                        {
                                            tabella[cella.r + 1, cella.c + 1].pedina.pedinaMangiata = true;
                                            tabella[cella.r + 2, cella.c + 2].BackColor = Color.Green;
                                            tabella[cella.r + 2, cella.c + 2].Click += new System.EventHandler(this.posizionaPedina);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        private void cancellaMosse()
        {
            for (int r = 0; r < RIGHE; r++)
            {
                for (int c = 0; c < COLONNE; c++)
                {
                    if (tabella[r, c].BackColor == Color.Green)
                    {
                        tabella[r, c].BackColor = Color.Black;
                        tabella[r, c].Click -= new System.EventHandler(this.posizionaPedina);
                    }
                }
            }
        }
        private void posizionaPedina(object sender, EventArgs e)
        {
            PanelRC cella = ((PanelRC)sender);
            int differenza = 0;
            int riga = 0, colonna = 0;
            cancellaMosse();

            trovaPedinaMangiata(ref riga, ref colonna);

            if (cella.r < tempR)
                differenza = tempR - cella.r;
            else
                differenza = cella.r - tempR;

            if (differenza == 2)
                pedinaMangiata(riga, colonna);
            else
                tabella[riga, colonna].pedina.pedinaMangiata = false;

            cella.pedina = tabella[tempR, tempC].pedina;
            cella.pedina.r = cella.r;
            cella.pedina.c = cella.c;


            cella.Controls.Add(tabella[tempR, tempC].pedina);
            tabella[tempR, tempC].pedina = null;


            if (turnoGiocatore1)
                turnoGiocatore1 = false;
            else
                turnoGiocatore1 = true;

            controllaDamone(cella);
            
            if (checkBox2.Checked)
                mossaCPU();
        }
        private void trovaPedinaMangiata(ref int riga, ref int colonna)
        {
            for (int r = 0; r < RIGHE; r++)
            {
                for (int c = 0; c < COLONNE; c++)
                {
                    if (tabella[r, c].pedina != null)
                        if (tabella[r, c].pedina.pedinaMangiata)
                        {
                            riga = tabella[r, c].r;
                            colonna = tabella[r, c].c;
                        }
                }
            }

        }
        private void pedinaMangiata(int riga, int colonna)
        {
            tabella[riga, colonna].pedina = null;
            tabella[riga, colonna].Controls.Clear();
        }
        private void cambioModalita(object sender, EventArgs e)
        {

            if ((sender as CheckBox).Name == "checkBox1")
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = true;
                checkBox1.Checked = true;
                checkBox2.Checked = false;

            }
            else if ((sender as CheckBox).Name == "checkBox2")
            {
                checkBox2.Enabled = false;
                checkBox1.Enabled = true;
                checkBox2.Checked = true;
                checkBox1.Checked = false;
            }



        }

        private void controllaDamone(PanelRC cella)
        {
            if (cella.r == 0 || cella.r == RIGHE - 1)
                cella.pedina.damone = true;

        }
        private void mossaCPU()
        {

        }
    }

    public class PanelRC : Panel
    {
        public Pedina pedina = null;
        public bool pedinaPresente;
        public int colore; //0 bianco, 1 nero
        public int r;
        public int c;
    }

    public class Pedina : PictureBox
    {
        public int r;
        public int c;
        public Color colore = Color.Red;
        public bool damone = false;
        public bool pedinaMangiata = false;
    }
}
