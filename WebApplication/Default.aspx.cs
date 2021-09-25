using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessManagement.service;

namespace WebApplication
{
    public partial class _Default : Page
    {
        public Student studentService = new Student();
        public String message = "Iniciado...";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void saveStudent_Click(object sender, EventArgs e)
        {
            this.message = this.studentService.addNewStudent(txtId.Text, txtFirstName.Text, txtLastName.Text);
        }
    }
}