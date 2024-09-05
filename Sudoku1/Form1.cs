using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace Sudoku1
{
    public partial class Form1 : Form
    {

        public int[,] grila2 = new int[9, 9];
        public int[,] solutie = new int[9, 9];
        public int rtbClicked=0;
        public List<Control> listaRtb;
        public string defaultValueRtb = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void setRtbNull()
        {
            int i = 0, j = 0;
            foreach (RichTextBox rtb in listaRtb)
            {
                //rtb.BackColor = Color.AntiqueWhite;
                int.TryParse(rtb.Name.Replace("rtb", ""), out i);

                if (i != 0)//s-a facut parse-ul cu succes !!!
                {
                    j = i % 10;
                    i = i / 10;
                    
                        rtb.Enabled = true;
                    //  rtb.ForeColor = Color.DarkBlue;
                    rtb.Text =  this.defaultValueRtb;
                }//if parsed corectly
            }
        }
    

        private void setEnabledRtb() //seteaza enabled si forecolor pt rtb-uri 
        {
            int i=0, j=0;
            foreach(RichTextBox rtb in listaRtb)
            {
               int.TryParse(rtb.Name.Replace("rtb", ""), out i);

                if (i != 0)//s-a facut parse-ul cu succes !!!
                {
                    j = i % 10;
                    i = i / 10;
                    if (solutie[i - 1, j - 1] == 0)
                    { 
                        rtb.Enabled = true;
                        rtb.ForeColor = Color.DarkBlue;
                     }
                   else
                  {
                    rtb.Enabled = false;
                    rtb.ForeColor = Color.Black;
                   }
                }//if parsed corectly
            }
        }

        private void getGridAndSol(int pozmax)
        {
            int i, j;
            bool gasit = false;
            
           
            //Thread.Sleep(1000 * 60 * 1); ///1000=1 secunda
            gasit =Sudoku1.GetSudoku.GetNextSudoku(ref this.grila2, ref this.solutie, pozmax);
            
            if (gasit)
            {
                //1
                i = 1; j = 1; rtb11.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 1; j = 2; rtb12.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 1; j = 3; rtb13.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 1; j = 4; rtb14.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 1; j = 5; rtb15.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 1; j = 6; rtb16.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 1; j = 7; rtb17.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 1; j = 8; rtb18.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 1; j = 9; rtb19.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();

                //2
                i = 2; j = 1; rtb21.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 2; j = 2; rtb22.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 2; j = 3; rtb23.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 2; j = 4; rtb24.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 2; j = 5; rtb25.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 2; j = 6; rtb26.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 2; j = 7; rtb27.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 2; j = 8; rtb28.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 2; j = 9; rtb29.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();

                //3
                i = 3; j = 1; rtb31.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 3; j = 2; rtb32.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 3; j = 3; rtb33.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 3; j = 4; rtb34.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 3; j = 5; rtb35.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 3; j = 6; rtb36.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 3; j = 7; rtb37.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 3; j = 8; rtb38.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 3; j = 9; rtb39.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();

                //4
                i = 4; j = 1; rtb41.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 4; j = 2; rtb42.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 4; j = 3; rtb43.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 4; j = 4; rtb44.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 4; j = 5; rtb45.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 4; j = 6; rtb46.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 4; j = 7; rtb47.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 4; j = 8; rtb48.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 4; j = 9; rtb49.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();

                //5
                i = 5; j = 1; rtb51.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 5; j = 2; rtb52.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 5; j = 3; rtb53.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 5; j = 4; rtb54.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 5; j = 5; rtb55.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 5; j = 6; rtb56.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 5; j = 7; rtb57.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 5; j = 8; rtb58.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 5; j = 9; rtb59.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();

                //6
                i = 6; j = 1; rtb61.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 6; j = 2; rtb62.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 6; j = 3; rtb63.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 6; j = 4; rtb64.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 6; j = 5; rtb65.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 6; j = 6; rtb66.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 6; j = 7; rtb67.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 6; j = 8; rtb68.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 6; j = 9; rtb69.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
               
                //7
                i = 7; j = 1; rtb71.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 7; j = 2; rtb72.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 7; j = 3; rtb73.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 7; j = 4; rtb74.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 7; j = 5; rtb75.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 7; j = 6; rtb76.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 7; j = 7; rtb77.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 7; j = 8; rtb78.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 7; j = 9; rtb79.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();

                //8
                i = 8; j = 1; rtb81.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 8; j = 2; rtb82.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 8; j = 3; rtb83.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 8; j = 4; rtb84.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 8; j = 5; rtb85.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 8; j = 6; rtb86.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 8; j = 7; rtb87.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 8; j = 8; rtb88.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 8; j = 9; rtb89.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();

                //9
                i = 9; j = 1; rtb91.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 9; j = 2; rtb92.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 9; j = 3; rtb93.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 9; j = 4; rtb94.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 9; j = 5; rtb95.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 9; j = 6; rtb96.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 9; j = 7; rtb97.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 9; j = 8; rtb98.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();
                i = 9; j = 9; rtb99.Text = this.solutie[i - 1, j - 1] == 0 ? this.defaultValueRtb : this.solutie[i - 1, j - 1].ToString();

                setEnabledRtb();
            }
            else
            {
                //nu am gasit 
                setRtbNull();
            }
          //  this.BackColor = c;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.rtbClicked = 11;
            /*
            rtb11.SelectAll();
            rtb11.SelectionAlignment = HorizontalAlignment.Center;
            rtb11.DeselectAll();
            */
            List<Control> l = new List<Control>();
            Type t = Type.GetType("System.Windows.Forms.GroupBox");//nu nimeresc tipurile --- le-am eliminat din functie
            Type t2 = Type.GetType("System.Windows.Forms.RichTextBox");
            l = GetAllControls(l,t,t2,this);
            listaRtb = l;
            //MessageBox.Show(l.Count().ToString());//81 de rtb-uri sa nu denumesc alte rtb-uri cu rtb !!!!
           // setRtbNull();
            foreach (RichTextBox r in l)
            {
                r.SelectAll();
                r.SelectionAlignment = HorizontalAlignment.Center;
                r.DeselectAll();
            }
            //MessageBox.Show("End form load...");
          
        }

        public static List<Control> GetAllControls(List<Control> controls, Type t, Type t2,
            Control parent /* can be Page */)
        {
            foreach (Control c in parent.Controls)
            {
               // if (c.GetType() == t)
                //{
                    foreach (Control c2 in c.Controls)
                    {
                        if //(c2.GetType() == t2)//&&
                           (c2.Name.StartsWith("rtb"))
                        {
                            controls.Add(c2);
                        }
                    }
                //}
            }
            return controls;
        }

        private void button1_Click(object sender, EventArgs e)//btn afis grid(grila) rezolvata
        {
           

            //Afiseaza grila rezolvata 
            int i = 0;
            int j = 0;
            this.rtbClicked = 0;//obligatoriu pe toate butoanele
            if (grila2[0, 0] != 0)//--- avem o grila si o solutie
            {
                foreach (RichTextBox rtb in listaRtb)
                {
                   
                    i = 0;j = 0;
                    int.TryParse(rtb.Name.Replace("rtb",""),out i);
                    if (i != 0)
                    {
                        //get i j 
                        j = i % 10;
                        i = i / 10;
                       
                        if (solutie[i - 1, j - 1] == 0)
                        {
                            rtb.Text = grila2[i - 1, j - 1].ToString();
                            rtb.ForeColor = Color.DarkBlue;
                        }
                    }
                    //rtb.Text = grila2[i - 1, j - 1];
                    //set forecolor pt solutie=0 si grila2<>0 to dark blue ---- de analizat daca trebuie
                }
            }
        }

        private void buttonGenGrid_Click(object sender, EventArgs e)//btn genereaza grila noua finala si partiala
        {
            //Color c;
            // this.grila2 = new int[9, 9];
            // this.solutie = new int[9, 9];
            // c = this.BackColor;
            
          //  this.label1.Text = "Status: Asteptati! Se genereaza grila noua....";
            MessageBox.Show("Se genereaza un nou sudoku (53) ...");
            this.buttonGenGrid.Enabled = false;
            getGridAndSol(53);
               
           // MessageBox.Show("Done!");
            this.buttonGenGrid.Enabled = true;
           // this.label1.Text = "Status: Finalizat! A fost generata o grila noua!";
            //this.BackColor = c;      // this.BackColor = Color.Aqua;


            this.rtbClicked = 0;

        }

        private void completeazaRtb(int v)
        {
            if (this.rtbClicked != 0)
            {
                if (v == 0)
                {
                    foreach(RichTextBox rtb in listaRtb)
                        if (rtb.Name=="rtb"+this.rtbClicked.ToString())
                        { 
                            rtb.Text = this.defaultValueRtb;
                            break;
                        }

                }

                else
                        {
                            switch (this.rtbClicked)
                            {
                                case 11: rtb11.Text = v.ToString(); break;
                                case 12: rtb12.Text = v.ToString(); break;
                                case 13: rtb13.Text = v.ToString(); break;
                                case 14: rtb14.Text = v.ToString(); break;
                                case 15: rtb15.Text = v.ToString(); break;
                                case 16: rtb16.Text = v.ToString(); break;
                                case 17: rtb17.Text = v.ToString(); break;
                                case 18: rtb18.Text = v.ToString(); break;
                                case 19: rtb19.Text = v.ToString(); break;

                                //2

                                case 21: rtb21.Text = v.ToString(); break;
                                case 22: rtb22.Text = v.ToString(); break;
                                case 23: rtb23.Text = v.ToString(); break;
                                case 24: rtb24.Text = v.ToString(); break;
                                case 25: rtb25.Text = v.ToString(); break;
                                case 26: rtb26.Text = v.ToString(); break;
                                case 27: rtb27.Text = v.ToString(); break;
                                case 28: rtb28.Text = v.ToString(); break;
                                case 29: rtb29.Text = v.ToString(); break;

                                //3

                                case 31: rtb31.Text = v.ToString(); break;
                                case 32: rtb32.Text = v.ToString(); break;
                                case 33: rtb33.Text = v.ToString(); break;
                                case 34: rtb34.Text = v.ToString(); break;
                                case 35: rtb35.Text = v.ToString(); break;
                                case 36: rtb36.Text = v.ToString(); break;
                                case 37: rtb37.Text = v.ToString(); break;
                                case 38: rtb38.Text = v.ToString(); break;
                                case 39: rtb39.Text = v.ToString(); break;

                                //4

                                case 41: rtb41.Text = v.ToString(); break;
                                case 42: rtb42.Text = v.ToString(); break;
                                case 43: rtb43.Text = v.ToString(); break;
                                case 44: rtb44.Text = v.ToString(); break;
                                case 45: rtb45.Text = v.ToString(); break;
                                case 46: rtb46.Text = v.ToString(); break;
                                case 47: rtb47.Text = v.ToString(); break;
                                case 48: rtb48.Text = v.ToString(); break;
                                case 49: rtb49.Text = v.ToString(); break;

                                //5

                                case 51: rtb51.Text = v.ToString(); break;
                                case 52: rtb52.Text = v.ToString(); break;
                                case 53: rtb53.Text = v.ToString(); break;
                                case 54: rtb54.Text = v.ToString(); break;
                                case 55: rtb55.Text = v.ToString(); break;
                                case 56: rtb56.Text = v.ToString(); break;
                                case 57: rtb57.Text = v.ToString(); break;
                                case 58: rtb58.Text = v.ToString(); break;
                                case 59: rtb59.Text = v.ToString(); break;

                                //6
                                case 61: rtb61.Text = v.ToString(); break;
                                case 62: rtb62.Text = v.ToString(); break;
                                case 63: rtb63.Text = v.ToString(); break;
                                case 64: rtb64.Text = v.ToString(); break;
                                case 65: rtb65.Text = v.ToString(); break;
                                case 66: rtb66.Text = v.ToString(); break;
                                case 67: rtb67.Text = v.ToString(); break;
                                case 68: rtb68.Text = v.ToString(); break;
                                case 69: rtb69.Text = v.ToString(); break;

                                //7
                                case 71: rtb71.Text = v.ToString(); break;
                                case 72: rtb72.Text = v.ToString(); break;
                                case 73: rtb73.Text = v.ToString(); break;
                                case 74: rtb74.Text = v.ToString(); break;
                                case 75: rtb75.Text = v.ToString(); break;
                                case 76: rtb76.Text = v.ToString(); break;
                                case 77: rtb77.Text = v.ToString(); break;
                                case 78: rtb78.Text = v.ToString(); break;
                                case 79: rtb79.Text = v.ToString(); break;

                                //8
                                case 81: rtb81.Text = v.ToString(); break;
                                case 82: rtb82.Text = v.ToString(); break;
                                case 83: rtb83.Text = v.ToString(); break;
                                case 84: rtb84.Text = v.ToString(); break;
                                case 85: rtb85.Text = v.ToString(); break;
                                case 86: rtb86.Text = v.ToString(); break;
                                case 87: rtb87.Text = v.ToString(); break;
                                case 88: rtb88.Text = v.ToString(); break;
                                case 89: rtb89.Text = v.ToString(); break;

                                //9
                                case 91: rtb91.Text = v.ToString(); break;
                                case 92: rtb92.Text = v.ToString(); break;
                                case 93: rtb93.Text = v.ToString(); break;
                                case 94: rtb94.Text = v.ToString(); break;
                                case 95: rtb95.Text = v.ToString(); break;
                                case 96: rtb96.Text = v.ToString(); break;
                                case 97: rtb97.Text = v.ToString(); break;
                                case 98: rtb98.Text = v.ToString(); break;
                                case 99: rtb99.Text = v.ToString(); break;


                            }

                        }//else --- cazul v<>0 aplic switchul cazul v=0 pun null
                this.rtbClicked = 0; // si pentru if si pentru else
            }
        }

        private void btn1_Click(object sender, EventArgs e)//am apasat cifra 1
        {
            int v = 1;
            completeazaRtb(v);
        }

        private void rtbAll_TextChanged(object sender, EventArgs e)
        {
               int i = 0, j = 0;
               int[] arr = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
               RichTextBox rtbCurrent = (RichTextBox)sender;

            //if (rtbCurrent.Text == "") rtbCurrent.BackColor = Color.LightGreen;
            //else rtbCurrent.BackColor = Color.Blue;
               
               int.TryParse(rtbCurrent.Name.Replace("rtb",""), out i);

               if (i != 0)
               {
                   j = i % 10;
                   i = i / 10;

                   if ((i >= 1) && (i <= 9) && (j >= 1) && (j <= 9))
                   {
                       if ((rtbCurrent.Text == grila2[i - 1, j - 1].ToString())&&(grila2[i-1,j-1]!=0))//si avem grila
                       {
                           if (solutie[i - 1, j - 1] == 0)
                           { rtbCurrent.ForeColor = Color.DarkBlue; }
                           else
                           { rtbCurrent.ForeColor = Color.Black; }

                       }
                       else
                       {
                           if (grila2[0, 0] != 0) { rtbCurrent.ForeColor = Color.Red; }
                           if ((rtbCurrent.Text != this.defaultValueRtb)||
                            ((this.defaultValueRtb is null)&&(rtbCurrent.Text is null)))
                           { 
                               i = 0; 
                               int.TryParse(rtbCurrent.Text, out i);
                            if (i == 0) { rtbCurrent.Text = this.defaultValueRtb; }
                            else if (!(arr.Contains(i)))
                            {
                                rtbCurrent.Text = this.defaultValueRtb;
                            }

                           }

                       }
                   }

               }//if parsed corectly
               
            /*
            bool grilaFinalizata = true;
            i = 0; j = 0;
            foreach(RichTextBox rtb in listaRtb)
            {
                int.TryParse(rtb.Name.Replace("rtb", ""), out i);

                if (i != 0)
                {
                    j = i % 10;
                    i = i / 10;

                    if ((i >= 1) && (i <= 9) && (j >= 1) && (j <= 9))
                    {
                        if (rtb.Text != grila2[i - 1, j - 1].ToString())
                        {
                            grilaFinalizata = false; break;
                        }
                    }
                    else
                    {
                        grilaFinalizata = false; break;
                    }
                }//if parsed corectly
                else
                {
                    grilaFinalizata = false; break;
                }
            }//foreach

            if (grilaFinalizata) { MessageBox.Show("Grila este rezolvata corect!"); }
            */
            return;
        }


        private void btn2_Click(object sender, EventArgs e)
        {
            int v = 2;
            completeazaRtb(v);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            int v = 3;
            completeazaRtb(v);
        }

       

        private void btnX_Click(object sender, EventArgs e)
        {
            int v = 0;
            completeazaRtb(v);
            //this.rtbClicked = 0; // este deja pus in procedura
        }

       

        private void rtb15_MouseClick(object sender, MouseEventArgs e)
        {  
            RichTextBox focusedTextbox = (RichTextBox)sender;
            string s=focusedTextbox.Name;
            s.Replace("rtb", "");
            this.rtbClicked = int.Parse(s);
            MessageBox.Show(this.rtbClicked.ToString());
        }

        private void rtbAll_MouseClick(object sender, MouseEventArgs e)
        {
            //am pus la toate cele 81 de casute pe mouseClick eveniment 
            RichTextBox focusedTextbox = (RichTextBox)sender;
            string s = focusedTextbox.Name;
            s=s.Replace("rtb", "");
            int a = 0;
            Int32.TryParse(s, out a);
            // MessageBox.Show(a.ToString());
            if (a!=0)
            {
                this.rtbClicked = a;
                //continua s-a gasit textbox-ul rtb+a
            }
           
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            int v = 4;
            completeazaRtb(v);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            int v = 5;
            completeazaRtb(v);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            int v = 6;
            completeazaRtb(v);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            int v = 7;
            completeazaRtb(v);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            int v = 8;
            completeazaRtb(v);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            int v = 9;
            completeazaRtb(v);
        }

        private void button1_Click_1(object sender, EventArgs e)//generare grila usoara
        {
            //Color c;
            // this.grila2 = new int[9, 9];
            // this.solutie = new int[9, 9];
            // c = this.BackColor;
           // this.label1.Text = "Status: Asteptati! Se genereaza grila noua usoara....";
             MessageBox.Show("Se genereaza un nou sudoku (52) ...");
            this.button1.Enabled = false;
            getGridAndSol(52);

            // MessageBox.Show("Done!");
            this.button1.Enabled = true;
            //this.label1.Text = "Status: Finalizat! A fost generata o grila noua usoara!";
            //this.BackColor = c;      // this.BackColor = Color.Aqua;

            this.rtbClicked = 0;
        }
    }
}
