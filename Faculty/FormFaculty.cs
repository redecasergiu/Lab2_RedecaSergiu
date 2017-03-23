using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faculty
{
    public partial class FormFaculty : Form
    {
        public FormFaculty()
        {
            InitializeComponent();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            try
            {
                Student student = RetrieveStudentInformation();

                IDBManager db = new MySQLDBManager();
                db.AddStudent(student);
                EmptyControls();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditStudent_Click(object sender, EventArgs e)
        {
            try
            {
                Student student = RetrieveStudentInformation();

                IDBManager db = new MySQLDBManager();
                db.UpdateStudent(student);
                EmptyControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                IDBManager dbManager = new MySQLDBManager();

                gridStudents.DataSource = dbManager.RetrieveStudents();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EmptyControls()
        {
            txtStudentID.Text = string.Empty;
            txtStudentName.Text = string.Empty;
            dtpStudentBirthDate.Value = DateTime.Now;
            txtStudentAddress.Text = string.Empty;
            gridStudents.SelectedRows[0].Selected = false;
        }

        private Student RetrieveStudentInformation()
        {
            Student student = new Student();
            student.ID = Convert.ToInt32(txtStudentID.Text);
            student.Name = txtStudentName.Text;
            student.BirthDate = dtpStudentBirthDate.Value;
            student.Address = txtStudentAddress.Text;
            return student;
        }

        private void gridStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (gridStudents.SelectedRows.Count > 0)
            {
                Student student = gridStudents.SelectedRows[0].DataBoundItem as Student;
                if (student != null)
                {
                    txtStudentName.Text = student.Name;
                    txtStudentID.Text = student.ID.ToString();
                    dtpStudentBirthDate.Value = student.BirthDate;
                    txtStudentAddress.Text = student.Address;
                }
            }
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            try
            {
                Student student = RetrieveStudentInformation();

                IDBManager db = new MySQLDBManager();
                db.DeleteStudent(student);
                EmptyControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
