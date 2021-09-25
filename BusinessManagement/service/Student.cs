using System;
using System.Collections.Generic;
using System.Text;
using DataManagement.access;
using DataManagement.model;

namespace BusinessManagement.service
{
    public class Student
    {
        DBManager dbManager = new DBManager();
        Response response = new Response();

        public String addNewStudent(String identifier, String firstName, String lastName)
        {
            String message = "";

            response = dbManager.openConnection();

            if (response.success)
            {
                response = dbManager.insertNewStudent(identifier,firstName,lastName);
                message = response.message;
                response = dbManager.closeConnection();
                if (!response.success)
                {
                    message += "<br>" + response.message;
                }
            }
            else
            {
                message = response.message;
            }
            return message;
        }
    }
}
