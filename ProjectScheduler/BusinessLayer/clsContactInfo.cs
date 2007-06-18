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
        public string LastName, LastNamePhonetic, LastNameRomaji;
        public string FirstName, FirstNamePhonetic, FirstNameRomaji;
        public string ClosestStation1, ClosestStation2, ClosestLine1, ClosestLine2, MinutesToStation1, MinutesToStation2;
        public string Street1, Street2, Street3, City, State, PostalCode, Country, Block;

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
                this.FirstName = reader["FirstName"].ToString();
                this.FirstNamePhonetic = reader["FirstNamePhonetic"].ToString();
                this.FirstNameRomaji = reader["FirstNameRomaji"].ToString();
                this.LastName = reader["LastName"].ToString();
                this.LastNamePhonetic = reader["LastNamePhonetic"].ToString();
                this.LastNameRomaji = reader["LastNameRomaji"].ToString();

                this.Street1 = reader["Street1"].ToString();
                this.Street2 = reader["Street2"].ToString();
                this.Street3 = reader["Street3"].ToString();
                this.City = reader["City"].ToString();
                this.State = reader["State"].ToString();
                this.PostalCode = reader["PostalCode"].ToString();
                this.Country = reader["Country"].ToString();
                this.Block = reader["BlockCode"].ToString();

                this.ClosestStation1 = reader["ClosestStation1"].ToString();
                this.ClosestStation2 = reader["ClosestStation2"].ToString();
                this.ClosestLine1 = reader["ClosestLine1"].ToString();
                this.ClosestLine2 = reader["ClosestLine2"].ToString();
                this.MinutesToStation1 = reader["MinutesToStation1"].ToString();
                this.MinutesToStation2 = reader["MinutesToStation2"].ToString();
            }
            if (DAC.Connection.State == ConnectionState.Open)
            {
                DAC.Connection.Close();
            }

            
        }
    }
}

