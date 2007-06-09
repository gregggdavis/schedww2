using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using SQLHelper.SqlHelpers;
using System.Data;
namespace Scheduler.BusinessLayer
{
    class clsContactInfo
    {
        public int ContactID;
        public string Phone1;
        public string Phone2;
        public string OtherPhone;
        public string Fax1;
        public string Fax2;
        public string Url;


        public void LoadData()
        {
            System.Data.SqlClient.SqlCommand command = SqlHelper.CreateCommand(DAC.Connection, "GetContactInfoByContactID");
            command.CommandType = CommandType.StoredProcedure;

            System.Data.SqlClient.SqlParameter pContactID = new System.Data.SqlClient.SqlParameter("@ContactID", System.Data.SqlDbType.Int);
            pContactID.Direction = System.Data.ParameterDirection.Input;
            pContactID.Value = ContactID;
            command.Parameters.Add(pContactID);

            if (DAC.Connection.State == ConnectionState.Closed)
            {
                DAC.Connection.Open();
            }
            System.Data.SqlClient.SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                this.Phone1 = reader["Phone1"].ToString();
                this.Phone2 = reader["Phone2"].ToString();
                this.OtherPhone = reader["PhoneOther"].ToString();
                this.Fax1 = reader["PhoneFax1"].ToString();
                this.Fax2 = reader["PhoneFax2"].ToString();
                this.Url = reader["Url"].ToString();
            }
            if (DAC.Connection.State == ConnectionState.Open)
            {
                DAC.Connection.Close();
            }

            
        }
    }
}

