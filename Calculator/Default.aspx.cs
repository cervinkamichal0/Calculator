using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Globalization;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;

namespace Calculator
{
    
    public partial class Calculator : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);


        public static bool _globalDecimalMode = true;
        public static bool GlobalDecimalMode
        {
            get { return _globalDecimalMode; }
            set { _globalDecimalMode = value; }
        }

        void SendError(Exception exception)
        {
            try
            {
                StreamWriter sw = new StreamWriter("C:\\Calculator\\ErrorLog.txt");
                sw.WriteLine("==================================================================================");
                sw.WriteLine(exception.ToString() + "       " + DateTime.Now.ToString());
                sw.WriteLine("==================================================================================");
                sw.Close();
            }
            catch(System.IO.DirectoryNotFoundException)
            {
                Directory.CreateDirectory("C:\\Calculator");
                FileStream fs = File.Create("C:\\Calculator\\ErrorLog.txt");
                fs.Close();
                StreamWriter sw = new StreamWriter("C:\\Calculator\\ErrorLog.txt");
                sw.WriteLine("==================================================================================");
                sw.WriteLine(exception.ToString() + "       " + DateTime.Now.ToString());
                sw.WriteLine("==================================================================================");
                sw.WriteLine("==================================================================================");
                sw.WriteLine("Neexistující log chyb" + "       " + DateTime.Now.ToString());
                sw.WriteLine("==================================================================================");
                sw.Close();
            }
        }
        public int GenerateID() //Automatický generátor unikátního ID pro SQL databázy
        {
            SqlCommand cmd = new SqlCommand("SELECT id FROM HistoryTable ORDER BY id", con);
            SqlDataReader dr = cmd.ExecuteReader();
            string id = "";
            if (dr.HasRows == false)
            {
                dr.Close();
                return 1;
            }
            while (dr.Read())
            {
                id = dr["ID"].ToString();
            }

            int lastID = Convert.ToInt32(id);
            int newID = ++lastID;
            dr.Close();
            return newID;

        }
        static string UpdateDisplay(string oldDisplayText, string buttonText) //Aktualizace displeje
        {
            if ((oldDisplayText == "0" && buttonText != "+" && buttonText != "-" && buttonText != "*" && buttonText != "/" && buttonText !=".") || oldDisplayText.StartsWith("result:"))
            {
                return buttonText;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                if ((oldDisplayText.EndsWith("+") || oldDisplayText.EndsWith("-") || oldDisplayText.EndsWith("*") || oldDisplayText.EndsWith("/")) && buttonText ==".")
                {

                    sb.Append(oldDisplayText + "0" +buttonText);
                    return sb.ToString();
                }
                else
                {
                    sb.Append(oldDisplayText + buttonText);
                    return sb.ToString();
                }
            }
        }

        public string Calculate(string displayText) //Logika kalkulačky
        {
            try
            {
                string[] operands = Regex.Split(displayText, @"(?<=[+\-*/])|(?=[+\-*/])");
                double firstOperand = double.Parse(operands[0], CultureInfo.InvariantCulture);
                double secondOperand = double.Parse(operands[2], CultureInfo.InvariantCulture);
                char sign = char.Parse(operands[1]);
                double result;
                    if (secondOperand == 0 && sign == '/')
                        return "Not a number";
                switch (sign)
                {
                    case '+':
                        result = firstOperand + secondOperand;
                        if (GlobalDecimalMode == true)
                            return result.ToString(CultureInfo.GetCultureInfo("en-GB"));
                        else
                            return Math.Round(result).ToString();
                    case '-':
                        result = firstOperand - secondOperand;
                        if (GlobalDecimalMode == true)
                            return result.ToString(CultureInfo.GetCultureInfo("en-GB"));
                        else
                            return Math.Round(result).ToString();
                    case '*':
                        result = firstOperand * secondOperand;
                        if (GlobalDecimalMode == true)
                            return result.ToString(CultureInfo.GetCultureInfo("en-GB"));
                        else
                            return Math.Round(result).ToString();
                    case '/':
                        result = firstOperand / secondOperand;
                        if (GlobalDecimalMode == true)
                            return result.ToString(CultureInfo.GetCultureInfo("en-GB"));
                        else
                            return Math.Round(result).ToString();
                }
                return displayText;
            }
            catch (System.IndexOutOfRangeException)
            {
                Exception displayException = new Exception("Equation not complete");
                SendError(displayException);
                return displayText;
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void tB_display_TextChanged(object sender, EventArgs e)
        {

        }

        protected void b1_Click(object sender, EventArgs e)
        {
            tB_display.Text = UpdateDisplay(tB_display.Text, b1.Text);

            

        }

        protected void b2_Click(object sender, EventArgs e)
        {
            tB_display.Text = UpdateDisplay(tB_display.Text, b2.Text);

            
        }

        protected void b3_Click(object sender, EventArgs e)
        {
            tB_display.Text = UpdateDisplay(tB_display.Text, b3.Text);

            
        }

        protected void b4_Click(object sender, EventArgs e)
        {
            tB_display.Text = UpdateDisplay(tB_display.Text, b4.Text);

            
        }

        protected void b5_Click(object sender, EventArgs e)
        {
            tB_display.Text = UpdateDisplay(tB_display.Text, b5.Text);

            
        }

        protected void b6_Click(object sender, EventArgs e)
        {
            tB_display.Text = UpdateDisplay(tB_display.Text, b6.Text);

            
        }

        protected void b7_Click(object sender, EventArgs e)
        {
            tB_display.Text = UpdateDisplay(tB_display.Text, b7.Text);

            
        }

        protected void b8_Click(object sender, EventArgs e)
        {
            tB_display.Text = UpdateDisplay(tB_display.Text, b8.Text);

            
        }

        protected void b9_Click(object sender, EventArgs e)
        {
            tB_display.Text = UpdateDisplay(tB_display.Text, b9.Text);

            
        }

        protected void b0_Click(object sender, EventArgs e)
        {
            tB_display.Text = UpdateDisplay(tB_display.Text, b0.Text);

            
        }

        protected void bDot_Click(object sender, EventArgs e)
        {
            tB_display.Text = UpdateDisplay(tB_display.Text, bDot.Text);
            bDot.Enabled = false;
        }

        protected void bPlus_Click(object sender, EventArgs e)
        {
            tB_display.Text = UpdateDisplay(tB_display.Text, bPlus.Text);

            bDot.Enabled = true;
            bPlus.Enabled = false;
            bMinus.Enabled = false;
            bMultiply.Enabled = false;
            bDivide.Enabled = false;
        }

        protected void bMinus_Click(object sender, EventArgs e)
        {
            tB_display.Text = UpdateDisplay(tB_display.Text, bMinus.Text);

            bDot.Enabled = true;
            bPlus.Enabled = false;
            bMinus.Enabled = false;
            bMultiply.Enabled = false;
            bDivide.Enabled = false;
        }

        protected void bMultiply_Click(object sender, EventArgs e)
        {
            tB_display.Text = UpdateDisplay(tB_display.Text, bMultiply.Text);

            bDot.Enabled = true;
            bPlus.Enabled = false;
            bMinus.Enabled = false;
            bMultiply.Enabled = false;
            bDivide.Enabled = false;
        }

        protected void bDivide_Click(object sender, EventArgs e)
        {
            tB_display.Text = UpdateDisplay(tB_display.Text, bDivide.Text);

            bDot.Enabled = true;
            bPlus.Enabled = false;
            bMinus.Enabled = false;
            bMultiply.Enabled = false;
            bDivide.Enabled = false;
        }

        protected void bDelete_Click(object sender, EventArgs e)
        {
            tB_display.Text = "0";

            b1.Enabled = true;
            b2.Enabled = true;
            b3.Enabled = true;
            b4.Enabled = true;
            b5.Enabled = true;
            b6.Enabled = true;
            b7.Enabled = true;
            b8.Enabled = true;
            b9.Enabled = true;
            b0.Enabled = true;
            bDot.Enabled = true;
            bPlus.Enabled = true;
            bMinus.Enabled = true;
            bMultiply.Enabled = true;
            bDivide.Enabled = true;
            bEquals.Enabled = true;

        }

        protected void bEquals_Click(object sender, EventArgs e)
        {
            string result = Calculate(tB_display.Text.ToString());
            
            con.Open();
            int newID = GenerateID();
            SqlCommand cmd = new SqlCommand("INSERT INTO HistoryTable VALUES('" + newID + "','" + tB_display.Text + " = " + result + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();

            gVHistory.DataBind();
            calculatorPanel.Update();

            tB_display.Text = "result: " + result;

            b1.Enabled = false;
            b2.Enabled = false;
            b3.Enabled = false;
            b4.Enabled = false;
            b5.Enabled = false;
            b6.Enabled = false;
            b7.Enabled = false;
            b8.Enabled = false;
            b9.Enabled = false;
            b0.Enabled = false;
            bDot.Enabled = false;
            bPlus.Enabled = false;
            bMinus.Enabled = false;
            bMultiply.Enabled = false;
            bDivide.Enabled = false;
            bEquals.Enabled = false;
        }

        protected void bDecimal_Click(object sender, EventArgs e)
        {
            bDecimal.Enabled = false;
            bInteger.Enabled = true;
            lMode.Text = "RETURNING: DECIMAL";

            GlobalDecimalMode = true;
        }

        protected void bInteger_Click(object sender, EventArgs e)
        {
            bDecimal.Enabled = true;
            bInteger.Enabled = false;
            lMode.Text = "RETURNING: INTEGER";

            GlobalDecimalMode = false;
        }
    }
}