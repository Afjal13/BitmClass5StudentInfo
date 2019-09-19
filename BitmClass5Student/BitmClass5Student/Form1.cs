using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitmClass5Student
{
    public partial class Form1 : Form
    {
        List<string> Names = new List<string> { };
        List<string> Ids = new List<string> { };
        List<string> Mobiles = new List<string> { };
        List<int> Ages = new List<int> { };
        List<string> Addresses = new List<string> { };
        List<double> GPAPoints = new List<double> { };
        int identity = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            AddStudentInfo();
        }
        private void AddStudentInfo()
        {
            try
            {
                if (idTextBox.Text == "" || nameTextBox.Text==""|| mobileTextBox.Text=="")
                {
                    if(idTextBox.Text == "")
                    {
                        idTextBox.Text = string.Empty;
                        MessageBox.Show("Student ID Required");
                    }
                    else if (nameTextBox.Text == "")
                    {
                        nameTextBox.Text = string.Empty;
                        MessageBox.Show("Student Name Required");
                    }
                    else if (mobileTextBox.Text == "")
                    {
                        mobileTextBox.Text = string.Empty;
                        MessageBox.Show("Student Mobile Required");
                    }
                }
                else
                {
                    try
                    {
                        int idLenght = (idTextBox.Text).Length;
                        int nameLenght = (nameTextBox.Text).Length;
                        int moblieLenght = (mobileTextBox.Text).Length;
                        if (idLenght == 4 && nameLenght <= 30 && moblieLenght == 11 && !Ids.Contains(idTextBox.Text) && !Mobiles.Contains(mobileTextBox.Text) && Convert.ToDouble(cpaPointTextBox.Text)<=4)
                        {

                            Ids.Add(idTextBox.Text);
                            Names.Add(nameTextBox.Text);
                            Mobiles.Add(mobileTextBox.Text);
                            Ages.Add(Convert.ToInt32(ageTextBox.Text));
                            GPAPoints.Add(Convert.ToDouble(cpaPointTextBox.Text));
                            Addresses.Add(addressTextBox.Text);
                            identity++;
                            MessageBox.Show("Add Successfully done");
                            SingleStudentInfo();

                        }
                        else
                        {
                            if (Ids.Contains(idTextBox.Text))
                            {
                                MessageBox.Show("Duplicate ID!");
                            }
                            else if (Mobiles.Contains(mobileTextBox.Text))
                            {
                                MessageBox.Show("Duplicate mobile number not allow!");
                            }
                            else
                            {
                                MessageBox.Show("Your Input is Invalid!");
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }
        private void SingleStudentInfo()
        {
            try
            {
                string message = "";
                for (int i = 0; i < Ids.Count(); i++)
                {
                    if (i == identity - 1)
                    {
                        message += "ID: " + Ids[i] + "\n" + "Name: " + Names[i] + "\n" + "Mobile: " + Mobiles[i] + "\n" + "Age: " + Ages[i] + "\n" + "Address: " + Addresses[i] + "\n" + "GPA Point: " + GPAPoints[i] + "\n";
                    }
                }
                displayRichTextBox.Text = message.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Single Show Wrong");
            }
        }
        private void ShowAllButton_Click(object sender, EventArgs e)
        {
            ShowAllStudentInfo();
        }
        private void ShowAllStudentInfo()
        {
            try
            {
                string message = "";
                string maxName = "";
                string minName = "";
                double total = 0.0;
                double max = GPAPoints.Max();
                int indexMax = GPAPoints.IndexOf(max);
                double min = GPAPoints.Min();
                int indexMin = GPAPoints.IndexOf(min);
                double avg = GPAPoints.Average();

                for (int i = 0; i < Ids.Count(); i++)
                {
                    message += "ID: " + Ids[i] + "\n" + "Name: " + Names[i] + "\n" + "Mobile: " + Mobiles[i] + "\n" + "Age: " + Ages[i] + "\n" + "Address: " + Addresses[i] + "\n" + "GPA Point: " + GPAPoints[i] + "\n";
                    if (indexMax == i)
                    {
                        maxName = Names[i];
                    }
                    if (indexMin == i)
                    {
                        minName = Names[i];
                    }
                    total += GPAPoints[i];
                }
                displayRichTextBox.Text = message.ToString();
                maxTextBox.Text = Convert.ToString(max);
                maxNameTextBox.Text = maxName;
                minTextBox.Text = Convert.ToString(min);
                minNameTextBox.Text = minName;
                avgTextBox.Text = Convert.ToString(avg);
                totalTextBox.Text = Convert.ToString(total);
            }
            catch (Exception)
            {
                MessageBox.Show("All Show Wrong");
            }
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchStudent();
        }
        private void SearchStudent()
        {
            string message = "";
            try
            {
                if (StudentRadioButton.Checked == true)
                {
                    for(int i=0; i < Ids.Count(); i++)
                    {
                        if (Ids[i].Equals(idTextBox.Text))
                        {
                            message += "ID: " + Ids[i] + "\n" + "Name: " + Names[i] + "\n" + "Mobile: " + Mobiles[i] + "\n" + "Age: " + Ages[i] + "\n" + "Address: " + Addresses[i] + "\n" + "GPA Point: " + GPAPoints[i] + "\n";
                        }
                    }
                }
                else if (nameRadioButton.Checked == true)
                {
                    for (int i = 0; i < Names.Count(); i++)
                    {
                        if (Names[i].Equals(nameTextBox.Text))
                        {
                            message += "ID: " + Ids[i] + "\n" + "Name: " + Names[i] + "\n" + "Mobile: " + Mobiles[i] + "\n" + "Age: " + Ages[i] + "\n" + "Address: " + Addresses[i] + "\n" + "GPA Point: " + GPAPoints[i] + "\n";
                        }
                    }
                }
                else if (mobileRadioButton.Checked == true)
                {
                    for (int i = 0; i < Mobiles.Count(); i++)
                    {
                        if (Mobiles[i].Equals(mobileTextBox.Text))
                        {
                            message += "ID: " + Ids[i] + "\n" + "Name: " + Names[i] + "\n" + "Mobile: " + Mobiles[i] + "\n" + "Age: " + Ages[i] + "\n" + "Address: " + Addresses[i] + "\n" + "GPA Point: " + GPAPoints[i] + "\n";
                        }
                    }
                }
                else
                {

                }
                displayRichTextBox.Text = message.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
