using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Collections;

namespace RandomNumberGame
{
    public partial class _Default : System.Web.UI.Page
    {
        public static int Try = 100;
        public static int[] GuessedNo = new int[100];
        public static int Guess = 0;
        public static NameValueCollection nvcScore = new NameValueCollection();
        public static ArrayList arr = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }

        protected void btnPlay_Click(object sender, EventArgs e)
        {
            Try = 100;
            Guess = 0;
            GuessedNo = new int[100];
            txtHighScore.Text = "";
            txtNickName.Text = "";
            txtNumber.Text = "";
            txtRandom.Text = "?";
            lblMsg.Text = "";
            lblScore.Text = "";

            Session["RandomNo"] = "0"; ;
            Panel1.Visible = true;
            Panel2.Visible = false;
            Random r = new Random();
            Session["RandomNo"] = r.Next(1, 100);
        }

        protected void btnTry_Click(object sender, EventArgs e)
        {
            int RandomNo = Convert.ToInt32(Session["RandomNo"].ToString());
            if (txtNumber.Text.ToString() != "")
            {
                int User_input = Convert.ToInt32(txtNumber.Text.ToString());
                lblMsg.ForeColor = System.Drawing.Color.FromArgb(0, 191, 253, 252);

                GuessedNo[Guess] = User_input;
                Guess++;

                if (Try > 0)
                {
                    if (User_input < RandomNo)
                    {
                        Try--;
                        lblMsg.Text = "You have " + Try.ToString() + " left. The number you Guessed is Too Low";
                    }
                    else if(User_input > RandomNo)
                    {
                        Try--;
                        lblMsg.Text = "You have " + Try.ToString() + " left. The number you Guessed is Too High";
                    }
                    else
                    {
                        txtRandom.Text = RandomNo.ToString();
                        lblMsg.Text = "Congratulations!!! You Win the Game.";
                        lblMsg.Text += "Your Score is: " + (100 - Guess);
                        Panel2.Visible = true;
                        txtHighScore.Text = (100 - Guess).ToString();
                    }
                }
                else
                {
                    lblMsg.Text = "Oops!! No more Try Left. Play Again.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                        
            }
            else
            {
                lblMsg.Text = "Please Enter your Guessed Number in TextBox.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnSaveHighScore_Click(object sender, EventArgs e)
        {
            arr.Clear();
            int i = 0;
            if (txtNickName.Text != "")
            {
                nvcScore.Add(txtNickName.Text.ToString(), txtHighScore.Text.ToString());
                foreach(string str in nvcScore)
                {
                    arr.Add(nvcScore[str].ToString());
                }

                //arr.Reverse();
                foreach(string str in arr)
                {
                    foreach (string key in nvcScore.Keys)
                    {
                        string[] values = nvcScore.GetValues(key);
                        foreach (string value in values)
                        {
                            if (value == str)
                            {
                                if (i <= 4)
                                {
                                    if (lblScore.Text == "")
                                        lblScore.Text = key + "-" + str;
                                    else
                                        lblScore.Text += "<br />" + key + "-" + str;

                                    i++;
                                    break;
                                }
                            }
                        }
                        
                    }
                }
                WriteTextFile();
            }
            else
            {
                lblMsg.Text = "Please Enter NickName to Save Score.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        public void WriteTextFile()
        {
            string FilePath = HttpContext.Current.Request.PhysicalApplicationPath +"\\Scores\\Score.txt";
            System.IO.StreamWriter file = new System.IO.StreamWriter(FilePath);          
            file.WriteLine(lblScore.Text.ToString());
            file.Close();
        }
    }
}
