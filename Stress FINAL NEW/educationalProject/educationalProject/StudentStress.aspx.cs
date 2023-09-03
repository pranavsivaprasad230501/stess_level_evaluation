using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Collections;
using System.Threading;
using System.Configuration;

namespace educationalProject
{
    public partial class StudentStress : System.Web.UI.Page
    {
        public static OleDbConnection oledbConn;
        DataTable dt = new DataTable();
        DataTable dtDistinct = new DataTable();
        static ArrayList _arrayPatientsCnt = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    FIRadioButton1.Checked = true;

                    FIRadioButton6.Checked = true;

                    FIRadioButton11.Checked = true;

                    FIRadioButton16.Checked = true;

                    FIRadioButton19.Checked = true;

                    FIRadioButton21.Checked = true;

                    FIRadioButton25.Checked = true;
                }


                TrainingDS();                
            }
            catch
            {

            }
        }

        private void TrainingDS()
        {
            string FileName = "TrainingDataset.xls";

            string Extension = ".xls";

            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

            string _Location = "TrainingDataset";

            string FilePath = Server.MapPath(FolderPath + FileName);

            ImportTrainingDS(FilePath, Extension, _Location);
        }

        private void ImportTrainingDS(string FilePath, string Extension, string _Location)
        {
            string conStr = "";

            switch (Extension)
            {
                case ".xls": //Excel 97-03

                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]

                             .ConnectionString;

                    break;

                case ".xlsx": //Excel 07

                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]

                              .ConnectionString;

                    break;

            }

            conStr = String.Format(conStr, FilePath, _Location);

            OleDbConnection connExcel = new OleDbConnection(conStr);

            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbCommand cmdDistinct = new OleDbCommand();
            OleDbCommand cmdPatientsCnt = new OleDbCommand();

            OleDbDataAdapter oda = new OleDbDataAdapter();
            OleDbDataAdapter odaDistinct = new OleDbDataAdapter();

            cmdExcel.Connection = connExcel;
            cmdDistinct.Connection = connExcel;
            cmdPatientsCnt.Connection = connExcel;
            //Get the name of First Sheet

            connExcel.Open();

            DataTable dtExcelSchema;

            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

            connExcel.Close();

            //Read Data from First Sheet

            connExcel.Open();

            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            cmdDistinct.CommandText = "SELECT DISTINCT(Result) From [" + SheetName + "]";

            oda.SelectCommand = cmdExcel;
            odaDistinct.SelectCommand = cmdDistinct;

            oda.Fill(dt);
            odaDistinct.Fill(dtDistinct);

            //BLL obj = new BLL();

            if (dt.Rows.Count > 0)
            {
                if (dtDistinct.Rows.Count > 0)
                {
                    //for (int i = 0; i < dtDistinct.Rows.Count; i++)
                    //{
                    //    cmdPatientsCnt.CommandText = "SELECT COUNT(*) From [" + SheetName + "] where result=" + dtDistinct.Rows[i]["result"].ToString() + "";
                    //    _arrayPatientsCnt.Add(cmdPatientsCnt.ExecuteScalar());
                    //}
                }

                connExcel.Close();

            }
            else
            {               
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('No Training Dataset!!!')</script>");
            }
        }

       

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string _data = DropDownList1.SelectedValue + "," +
                                  DropDownList2.SelectedValue + "," +
                                 DropDownList3.SelectedValue + "," +
                                  DropDownList4.SelectedValue + "," +
                                  DropDownList5.SelectedValue + "," +
                                  DropDownList6.SelectedValue + "," +
                                  DropDownList7.SelectedValue + "," +
                                  DropDownList8.SelectedValue + "," +
                                  DropDownList9.SelectedValue + "," +
                                  DropDownList10.SelectedValue + "," +
                                  DropDownList11.SelectedValue + "," +
                                  DropDownList12.SelectedValue;


                string[] values = _data.Split(',');

                string _output = NaiveBayes(values);

                lblResult.ForeColor = System.Drawing.Color.Green;
                lblResult.Font.Bold = true;
                lblResult.Font.Size = 16;
                lblResult.Text = "Result: " + _output;

                _SolutionsRecc();

                BLL obj = new BLL();

                if (obj.CheckOutput(Session["RegNo"].ToString()))
                {
                    obj.InsertResult(Session["RegNo"].ToString(), DropDownList1.SelectedValue, DropDownList2.SelectedValue, DropDownList3.SelectedValue, DropDownList4.SelectedValue,
                        DropDownList5.SelectedValue, DropDownList6.SelectedValue, DropDownList7.SelectedValue,
                        DropDownList8.SelectedValue, DropDownList9.SelectedValue, DropDownList10.SelectedValue, DropDownList11.SelectedValue, DropDownList12.SelectedValue, _output);

                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Successful')</script>");
                }
                else
                {
                    DataTable tab = new DataTable();
                    tab = obj.GetResultsByRegNo(Session["RegNo"].ToString());

                    obj.UpdateResult(Session["RegNo"].ToString(), DropDownList1.SelectedValue, DropDownList2.SelectedValue, DropDownList3.SelectedValue, DropDownList4.SelectedValue,
                        DropDownList5.SelectedValue, DropDownList6.SelectedValue, DropDownList7.SelectedValue,
                        DropDownList8.SelectedValue, DropDownList9.SelectedValue, DropDownList10.SelectedValue, DropDownList11.SelectedValue, DropDownList12.SelectedValue, _output, int.Parse(tab.Rows[0]["SolutionId"].ToString()));

                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Successful')</script>");
                }

                //Response.Redirect(string.Format("StudentGraph.aspx?p1={0}", _output));
            }
            catch
            {

            }
        }

        private void _SolutionsRecc()
        {
            //family issues
            if (DropDownList3.SelectedIndex > 0)
            {
                if (FIRadioButton1.Checked == true)
                {
                    Label1.Text = "Family Issues: if you are staying alone away from your family then understand that you are staying away for a purpose to achieve something in your life, remember that it is normal and temporary, familiarize yourself with your new surroundings in your campus, establish routines that help you get through the day, stay in touch with friends and family, find opportunities to connect with other students through student clubs or on-campus jobs, volunteer for community service interactions or involvement, get yourself involved in some busy schedule so that you don't feel that you are alone.";
                }
                if (FIRadioButton2.Checked == true)
                {
                    Label2.Text = "Family Issues:discuss regarding the same with your parents, try to talk openly to your sibling on how you feel over their actions, if the situation becomes much more aggressive try not to get physical, try to be calm all the time and just learn to ignore few things if you are responsible for your actions then try to apologise for your behaviour.";
                }
                if (FIRadioButton3.Checked == true)
                {
                    Label3.Text = "Family Issues:if you are having any dependents then try to manage both studies as well as taking care of your dependents parallelly, if possible try to work part time after the college so that you can also manage the expenses. And at the same time that would also boost the morale of your family and help you discover your own potential, if money is not a constraint then you can also discuss with your dependents to hire a person to take care of those who are dependent on you. Discussing about the same with your mentor or college lecturers would also help you to read some benefits from them.";
                }
                if (FIRadioButton4.Checked == true)
                {
                    Label4.Text = "Family Issues:if you lost a close one or a relative then accept your feelings, you may experience a wide range of emotions from sadness, anger or even exhaustion all of these feelings are normal and it's important to recognise when you are feeling this way try to move on with your life, mourning the loss of a close friend or relative takes time but that is life, try to take care of yourself and your family, eat healthy food, exercise and get plenty of sleep in order to improve your physical and emotional health, remember and celebrate the lives of your loved ones, if the problem is too serious then consult a psychologist for faster recovery.";
                }
                if (FIRadioButton5.Checked == true)
                {
                    Label5.Text = "Family Issues:if you're experiencing these kinds of issues then try to talk to your parents, express your feelings to them if not try to talk to your close friends or speak to a counselor, take care of yourself don't focus much on these issues as you're not responsible for these things, try to change your focus towards studies, things will never be the same but the pain and sadness will eventually listen, don't suppress your emotions find new ways of dealing with these kind of issues. Be prepared for financial changes as well.";
                }
            }

            if (DropDownList2.SelectedIndex > 0)
            {
                //financial issues
                if (FIRadioButton6.Checked == true)
                {
                    Label6.Text = "Financial Issues: if you are involved in high uncontrolled spending, then try to use a notebook spreadsheet or a budgeting app to keep track of your expenses, do this for a minimum of one month or 2 months and you will observe the changes in your spending habits, try to create a budget for yourself as to where you are going to allocate your money, don't invest on unnecessary things, try to minimise your expenditures and maximise your savings, do not get into the trap of credit cards.";
                }
                if (FIRadioButton7.Checked == true)
                {
                    Label7.Text = "Financial Issues: the credit card instant loan app is a great tool to help you meet costs but it is a very bad idea when you have no proper income major risk is getting caught in a debt trap and only being able to pay off your interest while making little impact on the debt itself,the greatest approach to prevent this type of debt is to avoid it in the first place. If you do find yourself in trouble, prioritise paying off this debt cut back on everything you can seek financial aid from relatives and search for methods to generate extra money to pay off the debt.";
                }
                if (FIRadioButton8.Checked == true)
                {
                    Label8.Text = "Financial Issues: the practice of tracking your expenditure has proven to be very useful even for the most expert finance professional, we recommend you to keep a track of your spending for at least 2 weeks and you can absorb the sources where your money is majorly spent so that based on this particular analysis you can device a strategy for yourself to reduce your expenses and improve your savings.";
                }
                if (FIRadioButton9.Checked == true)
                {
                    Label9.Text = "Financial Issues: try to evaluate the financial crisis of your family which they are experiencing at the current moment, determine whether there is a need for you to find a part time job along with your college and support them financially, if you don't find that necessary then try to perform good in your studies in college and grab a good job offer during your placements, so that you can uplift the financial and social status of your family also don't try to spend unnecessarily and try to help them to downsize their financial burden by saving the money wherever possible, if you are financially aware try to create a budget for them so that they can improve upon their financial status and guide them to relocate to a cheaper house or apartment.";
                }
                if (FIRadioButton10.Checked == true)
                {
                    Label10.Text = "Financial Issues: if you are unable to afford the college fee then try to apply for institutional scholarships and fellowship programs because scholarships remain open most of the times provided that you meet the specified criteria, so enquire regarding the same with the institute. Along with that also apply for government funded scholarships if you are eligible to any, try to fund the amount on the basis of monthly installments, Try to obtain student loans to pay your fee, as many financial institutions offer collateral free loans to students nowadays.";
                }
            }

            //teaching method   
            if (DropDownList5.SelectedIndex > 0)
            {
                if (FIRadioButton11.Checked == true)
                {
                    Label11.Text = "Teaching Method: if you face difficulty in concentration then yoga and meditation is the tried and tested formula for improving concentration, it does not require much effort all you need to do is meditate in a calm and quiet room.When studying at home switch off all your electronic devices and try to fix a routine daily,set your goal for that particular day and take small breaks in between to refresh your mood.";
                }
                if (FIRadioButton12.Checked == true)
                {
                    Label2.Text = "Teaching Method: if you're studying in a noisy environment use noise cancelling headphones or listen to music through ear buds can also tune out distracting noises like people talking too loudly or construction work some students work best with a little background noise while others need complete quiet get to know your work style and the type of atmosphere you prefer are you the kind of a person who works better in silence at the library or do you prefer the campus or coffee shop with ambient noise try a few different spaces and see how each study session works out along with that wherever you are studying keep your study desk clean and reward yourself like watching a video or taking a nap as a kind of motivation to keep yourself studying for a long time.";
                }
                if (FIRadioButton13.Checked == true)
                {
                    Label3.Text = "Teaching Method: if you don't enjoy the subject which you are studying try to relate the content of that subject with your practical life might it be coding or any hardware subject or networking subject try to implement it on your own practically if you don't understand any topic of that subject try to discuss that topic with your faculty try to develop curiosity in that subject in order to develop more interest towards that subject and try to reward yourself when you complete studying that particular subject and establish a fixed routine for that subject.";
                }
                if (FIRadioButton14.Checked == true)
                {
                    Label4.Text = "Teaching Method: if you lack motivation to study reward yourself whenever you complete each and every small goals of your study schedule try to study with your friends as it is proud that a group of motivated friends will always be encouraging towards accomplishing a particular task and always remind yourself of your long term goals eliminate all the distractions develop interest in what you have to study take regular breaks and establish a comfortable environment and try to follow paroto's rule where you divide a 6 hour session into 45 minutes session with 15 minutes break so that you can concentrate much better towards your studies.";
                }
                if (FIRadioButton15.Checked == true)
                {
                    Label5.Text = "Teaching Method: focus your attention as attention is one of the major components of memory, avoid cramming, reachers research has continuously shown that students who study regularly remember the material far better than those who do all of their studying in one marathon session , always structure and organise your content, utilise mnemonic devices, try to create your own mind maps , elaborate and reverse whatever you have studied, try to visualise the concepts, try to read out aloud, pay extra attention to difficult information and always try to get yourself a good sound sleep.";
                }
            }

            //health issues  
            if (DropDownList6.SelectedIndex > 0)
            {
                if (FIRadioButton16.Checked == true)
                {
                    Label16.Text = "Health Issues: if you or anyone in your family is effected by COVID-19 then inform this to the college authorities, so that you can isolate yourself and consult yourself with a doctor and take proper medications so that you get recovered quickly as well as avoid the spread of virus to others , also try to wear face masks and maintain physical distancing limit your exposure to the outer world develop your immunity and keep your moral high.";
                }
                if (FIRadioButton17.Checked == true)
                {
                    Label17.Text = "Health Issues: if you are experiencing any chronic diseases then get yourself consulted with a doctor and follow proper medications and always try to eat healthy as it prevents, delays and immunes you from many diseases, get regular physical activity, consume water properly at least 4 litres a day get yourself through regular medical checkups and try to get enough sleep.";
                }
                if (FIRadioButton18.Checked == true)
                {
                    Label18.Text = "Health Issues: if you are addicted to any of this, try to talk about it with your mentor in your college, try to discuss it with your parents or you're well-wishers or brothers identify your triggers, reflect on your addiction, seek some professional support if needed try to develop some hobby so that you come out of this addiction educate yourself more about those addictions about their consequences and so on.";
                }
            }

            if (DropDownList7.SelectedIndex > 0)
            {
                //partiality                
                if (FIRadioButton19.Checked == true)
                {
                    Label19.Text = "Partiality: if you are facing any kind of issues of favoritism shown by your teacher then first go and discuss this matter with the concerned teacher maybe he or she didn't knew that you might get offended due to some particular activities if he/she admits then you are good to go. Discuss this matter with your guardians or parents about all that happened, don't ever hide this problems with them, maybe they will find you an adequate solutions or there might be any kind of misunderstanding by you also so try to become strong and perfect in the subject he/she is teaching so that you can save yourself from difficulties you might face during their classes.";
                }
                if (FIRadioButton20.Checked == true)
                {
                    Label20.Text = "Partiality: if you are experiencing any favoritism by your parents towards your siblings then try to have a talk with your parents and also evaluate whether your behaviour or actions are also responsible towards the contribution of your perception of favoritism, approach your parents when both of you are in good or calm moodes , open up with a talk, focus on your feelings, listen to their perspective and try to remain calm also try to talk to your siblings. Try to be responsible for your own tasks and have good manners and maintain healthy relationship with your siblings";
                }
            }

            if (DropDownList9.SelectedIndex > 0)
            {

                //friend issues
                if (FIRadioButton21.Checked == true)
                {
                    Label21.Text = "Friend Issues: if you are facing any bullying issue try to discuss regarding the same with any trusted adult like parents or teachers, ignore the bully and walk away if possible try to convey the same to your college grievance redressal cell, ignore the bully , walk tall and hold your head high, don't get into any kind of physical fights be confident also stand up for your friends and others if you see anyone being bullied.";
                }
                if (FIRadioButton22.Checked == true)
                {
                    Label22.Text = "Friend Issues: if you are involved in toxic friendship that only you can decide what is best for you, your friend might be happy but don't let guilt or pressure keep you from staying in a friendship that makes you unhappy, take some space if you are not ready to leave the friendship, but if you are hurting a lot consider taking a break from the friendship for a while, discuss regarding this matter with that particular friend find maybe he might change himself for you if it's a true friendship.";
                }
                if (FIRadioButton23.Checked == true)
                {
                    Label23.Text = "Friend Issues: if you are facing any kind of social exclusion then try to get yourself involved more in group activities, try to be friendly with all the others, try to mingle with others, if you still face social exclusion then discuss the same with your mentor , parent or sibling and try to identify yourself the reason behind your social exclusion.";
                }
                if (FIRadioButton24.Checked == true)
                {
                    Label24.Text = "Friend Issues: if you are facing any kind of harassment issue then try to talk to someone about the harassment might be your college lecturers or mentors or your parents stop blaming yourself , find a counselor , if you don't get suitable solutions from either of them, then file a complaint in the nearby grievance redressal office I'm learn to say no to deal with sensitive situations.";
                }
            }

            if (DropDownList10.SelectedIndex > 0)
            {

                //Pressure issues
                if (FIRadioButton25.Checked == true)
                {
                    Label25.Text = "Pressure Issues: first of all remember that you are all good , just as you are, what you choose to do with your life is important but it doesn't define your value as a person, try to understand your parents expectations what matters is how you solve the situation, their expectations are usually coming from the right place they just want you to succeed or to be happy, if you think that you can't meet their expectations, have a real talk with them and explain them your problems they will surely understand , you pick a right time when your parents are free and chilled and discuss the situation with them, listen to what they have to say, also check your own expectations having goals is great but if you put heaps of pressure on yourself will probably feel stressed.";
                }
                if (FIRadioButton26.Checked == true)
                {
                    Label26.Text = "Pressure Issues: pay attention to how you feel, if something doesn't feel right about a situation it probably isn't, even if your friend seems okay with what is going on the situation may not be right for you talk to the person who is pressurising, let him or her know how it makes you feel and tell the person to stop. Have friends with similar values and beliefs it is easier to say no if someone else is also saying it saying no together makes it easier for the both of you, get support from a trusted adult such as a parent teacher or a school counselor interested adult can listen to you and help you with strategies that might work in your situation.";
                }
                if (FIRadioButton27.Checked == true)
                {
                    Label27.Text = "Pressure Issues: try to use campus resources like the library facility available at your college, try to stay active all the time while your lecturers are teaching, learn new skills through practice, use the habit of positive self talk so that you remain confident all the time, take responsibility for your own mistakes, always forgive yourself for your actions, focus on what you can control and practice good self care.";
                }
            }

        }

        ArrayList output = new ArrayList();
        ArrayList mul = new ArrayList();

        //function to load subject
        public ArrayList GetSubject()
        {

            ArrayList s = new ArrayList();

            if (dtDistinct.Rows.Count > 0)
            {
                s.Clear();

                for (int i = 0; i < dtDistinct.Rows.Count; i++)
                {
                    if (dtDistinct.Rows[i]["Result"].Equals(""))
                    {
                    }
                    else
                    {
                        s.Add(dtDistinct.Rows[i]["Result"].ToString());
                    }
                }
            }

            return s;

        }

        double pi;
        int nc, n;
        double result;

        //function which contains the algorithm steps
        private string NaiveBayes(string[] values)
        {
            ArrayList s = new ArrayList();
            output.Clear();

            //try
            //{
            s = GetSubject();

            int m = 12;
            double numer = 1.0;
            double dino = double.Parse(s.Count.ToString());
            double p = numer / dino;

            string[] features = { "Gender", "Financial_Issues", "Family_Issues", "Study_Hours", "Teaching_Method", "Health_Issues", "Partiality_Fix", "Exam_Schedule", "Friends_Issue", "Pressure", "Regular", "Interaction" };

            for (int i = 0; i < s.Count; i++)
            {
                mul.Clear();

                for (int j = 0; j < features.Length; j++)
                {
                    n = 0;
                    nc = 0;

                    for (int d = 0; d < dt.Rows.Count; d++)
                    {
                        if (dt.Rows[d][j].ToString().Equals(values[j]))
                        {
                            ++n;

                            if (dt.Rows[d][m].ToString().Equals(s[i]))

                                ++nc;
                        }
                    }

                    double x = m * p;
                    double y = n + m;
                    double z = nc + x;

                    pi = z / y;
                    mul.Add(Math.Abs(pi));
                }

                double mulres = 1.0;

                for (int z = 0; z < mul.Count; z++)
                {
                    mulres *= double.Parse(mul[z].ToString());
                }

                result = mulres * p;
                output.Add(Math.Abs(result));
            }

            ArrayList list1 = new ArrayList();

            for (int x = 0; x < s.Count; x++)
            {
                list1.Add(output[x]);
            }

            list1.Sort();
            list1.Reverse();

            string _output = null;

            for (int y = 0; y < s.Count; y++)
            {
                if (output[y].Equals(list1[0]))
                {
                    _output = s[y].ToString();
                    return _output;
                }
            }
            //}
            //catch
            //{

            //}

            return _output;
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedIndex == 0)
            {
                Panel2.Visible = false;
            }
            else
            {
                Panel2.Visible = true;
            }
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList3.SelectedIndex == 0)
            {
                Panel3.Visible = false;
            }
            else
            {
                Panel3.Visible = true;
            }
        }

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList5.SelectedIndex == 0)
            {
                Panel4.Visible = false;
            }
            else
            {
                Panel4.Visible = true;
            }
        }

        protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList6.SelectedIndex == 0)
            {
                Panel5.Visible = false;
            }
            else
            {
                Panel5.Visible = true;
            }
        }

        protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList7.SelectedIndex == 0)
            {
                Panel6.Visible = false;
            }
            else
            {
                Panel6.Visible = true;
            }
        }

        protected void DropDownList9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList9.SelectedIndex == 0)
            {
                Panel7.Visible = false;
            }
            else
            {
                Panel7.Visible = true;
            }
        }

        protected void DropDownList10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList10.SelectedIndex == 0)
            {
                Panel8.Visible = false;
            }
            else
            {
                Panel8.Visible = true;
            }
        } 


    }
}