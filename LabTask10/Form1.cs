using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabTask10
{
    public partial class Form1 : Form
    {
        List<string> Name_List = new List<string>();
        List<string> Last_Name_List = new List<string>();
        List<string> ID_List = new List<string>();
        List<string> Email_List = new List<string>();
        List<string> Phone_List = new List<string>();
        List<string> Date_List = new List<string>();
        List<string> Commission_List = new List<string>();
        List<string> Manager_ID_List = new List<string>();
        List<string> Dept_ID_List = new List<string>();
        List<string> Job_ID_List = new List<string>();
        List<string> Salary_List = new List<string>();
        public Form1()
        {
            InitializeComponent();
            using (var reader = new StreamReader(@"C:\employees.csv"))
            {
                
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    ID_List.Add(values[0]);
                    Name_List.Add(values[1]);
                    Last_Name_List.Add(values[2]);
                    Email_List.Add(values[3]);
                    Phone_List.Add(values[4]);
                    Date_List.Add(values[5]);
                    Job_ID_List.Add(values[6]);
                    Salary_List.Add(values[7]);
                    Commission_List.Add(values[8]);
                    Manager_ID_List.Add(values[9]);
                    Dept_ID_List.Add (values[10]);
                }
                reader.Close();
                for(int i = 0; i < Name_List.Count; i++)
                {
                    if(i==0)
                    {
                        string dummy = ID_List[i] + "\t" + Name_List[i];
                        Employee_List_ID_Name.Items.Add(dummy);
                    }
                    else
                    {
                        string dummy = ID_List[i] + "\t" + "\t" + Name_List[i];
                        Employee_List_ID_Name.Items.Add(dummy);
                    }
                }
            }

        }

        private void Search_OnClick(object sender, EventArgs e)
        {
            var id = Employee_ID_Input.Text;
            int i, flag = 0;
            string ID = id.ToString();
            for(i=0; i < ID_List.Count; i++)
            {
                if(id == ID_List[i])
                {
                    flag = 1;
                    Name_Output.Text = Name_List[i] +" " + Last_Name_List[i];
                    ID_Output.Text = ID_List[i];
                    Email_Output.Text = Email_List[i];
                    Phone_Output.Text = Phone_List[i];
                    Date_Output.Text = Date_List[i];
                    Job_Output.Text = Job_ID_List[i];
                    Salary_Output.Text = Salary_List[i];
                    PCT_Output.Text = Commission_List[i];
                    Manager_Output.Text = Manager_ID_List[i];
                    Department_Output.Text = Dept_ID_List[i];

                    StreamWriter s = File.AppendText("d:\\log.txt");
                    s.WriteLine(ID_List[i] + "," + Name_List[i] + " " + Last_Name_List[i] + "," + Email_List[i] + "," + Phone_List[i] + "," + Date_List[i] + "," + Job_ID_List[i] + "," + Salary_List[i] + "," + Commission_List[i] + "," + Manager_ID_List[i] + "," + Dept_ID_List[i]);
                    s.Close();
                }
            }
            if(flag == 0)
            {
                MessageBox.Show("ID does not exist");
                StreamWriter s = File.AppendText("d:\\log.txt");
                s.WriteLine(ID + "," + "ID doesn't exist");
                s.Close();
            }
        }
    }

}
