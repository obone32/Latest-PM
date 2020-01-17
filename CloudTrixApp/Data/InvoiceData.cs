using System;
using System.Data;
using System.Data.SqlClient;
using CloudTrixApp.Models;

namespace CloudTrixApp.Data
{
    public class InvoiceData
    {

        public static DataTable SelectAll()
        {
            SqlConnection connection = PMMSData.GetConnection();
            string selectProcedure = "[InvoiceSelectAll]";
            SqlCommand selectCommand = new SqlCommand(selectProcedure, connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (SqlException)
            {
                return dt;
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static DataTable Search(string sField, string sCondition, string sValue)
        {
            SqlConnection connection = PMMSData.GetConnection();
            string selectProcedure = "[InvoiceSearch]";
            SqlCommand selectCommand = new SqlCommand(selectProcedure, connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            if (sField == "Invoice I D")
            {
                selectCommand.Parameters.AddWithValue("@InvoiceID", sValue);
            }
            else
            {
                selectCommand.Parameters.AddWithValue("@InvoiceID", DBNull.Value);
            }
            if (sField == "Invoice No")
            {
                selectCommand.Parameters.AddWithValue("@InvoiceNo", sValue);
            }
            else
            {
                selectCommand.Parameters.AddWithValue("@InvoiceNo", DBNull.Value);
            }
            if (sField == "Invoice Date")
            {
                selectCommand.Parameters.AddWithValue("@InvoiceDate", sValue);
            }
            else
            {
                selectCommand.Parameters.AddWithValue("@InvoiceDate", DBNull.Value);
            }
            if (sField == "Project I D")
            {
                selectCommand.Parameters.AddWithValue("@ProjectName", sValue);
            }
            else
            {
                selectCommand.Parameters.AddWithValue("@ProjectName", DBNull.Value);
            }
            if (sField == "Client I D")
            {
                selectCommand.Parameters.AddWithValue("@ClientName", sValue);
            }
            else
            {
                selectCommand.Parameters.AddWithValue("@ClientName", DBNull.Value);
            }
            if (sField == "Client Name")
            {
                selectCommand.Parameters.AddWithValue("@ClientName", sValue);
            }
            else
            {
                selectCommand.Parameters.AddWithValue("@ClientName", DBNull.Value);
            }
            if (sField == "Client Address")
            {
                selectCommand.Parameters.AddWithValue("@ClientAddress", sValue);
            }
            else
            {
                selectCommand.Parameters.AddWithValue("@ClientAddress", DBNull.Value);
            }
            if (sField == "Client G S T I N")
            {
                selectCommand.Parameters.AddWithValue("@ClientGSTIN", sValue);
            }
            else
            {
                selectCommand.Parameters.AddWithValue("@ClientGSTIN", DBNull.Value);
            }
            if (sField == "Client Contact No")
            {
                selectCommand.Parameters.AddWithValue("@ClientContactNo", sValue);
            }
            else
            {
                selectCommand.Parameters.AddWithValue("@ClientContactNo", DBNull.Value);
            }
            if (sField == "Client E Mail")
            {
                selectCommand.Parameters.AddWithValue("@ClientEMail", sValue);
            }
            else
            {
                selectCommand.Parameters.AddWithValue("@ClientEMail", DBNull.Value);
            }
            if (sField == "Additional Discount")
            {
                selectCommand.Parameters.AddWithValue("@AdditionalDiscount", sValue);
            }
            else
            {
                selectCommand.Parameters.AddWithValue("@AdditionalDiscount", DBNull.Value);
            }
            if (sField == "Remarks")
            {
                selectCommand.Parameters.AddWithValue("@Remarks", sValue);
            }
            else
            {
                selectCommand.Parameters.AddWithValue("@Remarks", DBNull.Value);
            }
            if (sField == "P D F Url")
            {
                selectCommand.Parameters.AddWithValue("@PDFUrl", sValue);
            }
            else
            {
                selectCommand.Parameters.AddWithValue("@PDFUrl", DBNull.Value);
            }
            if (sField == "Company I D")
            {
                selectCommand.Parameters.AddWithValue("@CompanyID", sValue);
            }
            else
            {
                selectCommand.Parameters.AddWithValue("@CompanyID", DBNull.Value);
            }
            if (sField == "Add User I D")
            {
                selectCommand.Parameters.AddWithValue("@AddUserID", sValue);
            }
            else
            {
                selectCommand.Parameters.AddWithValue("@AddUserID", DBNull.Value);
            }
            if (sField == "Add Date")
            {
                selectCommand.Parameters.AddWithValue("@AddDate", sValue);
            }
            else
            {
                selectCommand.Parameters.AddWithValue("@AddDate", DBNull.Value);
            }
            if (sField == "Archive User I D")
            {
                selectCommand.Parameters.AddWithValue("@ArchiveUserID", sValue);
            }
            else
            {
                selectCommand.Parameters.AddWithValue("@ArchiveUserID", DBNull.Value);
            }
            if (sField == "Archive Date")
            {
                selectCommand.Parameters.AddWithValue("@ArchiveDate", sValue);
            }
            else
            {
                selectCommand.Parameters.AddWithValue("@ArchiveDate", DBNull.Value);
            }
            selectCommand.Parameters.AddWithValue("@SearchCondition", sCondition);
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (SqlException)
            {
                return dt;
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static Invoice Select_Record(Invoice InvoicePara)
        {
            Invoice Invoice = new Invoice();
            SqlConnection connection = PMMSData.GetConnection();
            string selectProcedure = "[InvoiceSelect]";
            SqlCommand selectCommand = new SqlCommand(selectProcedure, connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@InvoiceID", InvoicePara.InvoiceID);
            try
            {
                connection.Open();
                SqlDataReader reader
                    = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    Invoice.InvoiceID = System.Convert.ToInt32(reader["InvoiceID"]);
                    Invoice.InvoiceNo = System.Convert.ToString(reader["InvoiceNo"]);
                    Invoice.InvoiceDate = System.Convert.ToDateTime(reader["InvoiceDate"]);
                    Invoice.ProjectID = reader["ProjectID"] is DBNull ? null : (Int32?)reader["ProjectID"];
                    Invoice.ClientID = System.Convert.ToInt32(reader["ClientID"]);
                    Invoice.ClientName = System.Convert.ToString(reader["ClientName"]);
                    Invoice.ClientAddress = reader["ClientAddress"] is DBNull ? null : reader["ClientAddress"].ToString();
                    Invoice.ClientGSTIN = reader["ClientGSTIN"] is DBNull ? null : reader["ClientGSTIN"].ToString();
                    Invoice.ClientContactNo = reader["ClientContactNo"] is DBNull ? null : reader["ClientContactNo"].ToString();
                    Invoice.ClientEMail = reader["ClientEMail"] is DBNull ? null : reader["ClientEMail"].ToString();
                    Invoice.AdditionalDiscount = System.Convert.ToDecimal(reader["AdditionalDiscount"]);
                    Invoice.Remarks = reader["Remarks"] is DBNull ? null : reader["Remarks"].ToString();
                    Invoice.PDFUrl = reader["PDFUrl"] is DBNull ? null : reader["PDFUrl"].ToString();
                    Invoice.CompanyID = System.Convert.ToInt32(reader["CompanyID"]);
                    Invoice.AddUserID = System.Convert.ToInt32(reader["AddUserID"]);
                    Invoice.AddDate = System.Convert.ToDateTime(reader["AddDate"]);
                    Invoice.ArchiveUserID = reader["ArchiveUserID"] is DBNull ? null : (Int32?)reader["ArchiveUserID"];
                    Invoice.ArchiveDate = reader["ArchiveDate"] is DBNull ? null : (DateTime?)reader["ArchiveDate"];
                }
                else
                {
                    Invoice = null;
                }
                reader.Close();
            }
            catch (SqlException)
            {
                return Invoice;
            }
            finally
            {
                connection.Close();
            }
            return Invoice;
        }

        public static bool Add(Invoice Invoice)
        {
            SqlConnection connection = PMMSData.GetConnection();
            string insertProcedure = "[InvoiceInsert]";
            SqlCommand insertCommand = new SqlCommand(insertProcedure, connection);
            insertCommand.CommandType = CommandType.StoredProcedure;
            insertCommand.Parameters.AddWithValue("@InvoiceNo", Invoice.InvoiceNo);
            insertCommand.Parameters.AddWithValue("@InvoiceDate", Invoice.InvoiceDate);
            if (Invoice.ProjectID.HasValue == true)
            {
                insertCommand.Parameters.AddWithValue("@ProjectID", Invoice.ProjectID);
            }
            else
            {
                insertCommand.Parameters.AddWithValue("@ProjectID", DBNull.Value);
            }
            insertCommand.Parameters.AddWithValue("@ClientID", Invoice.ClientID);
            insertCommand.Parameters.AddWithValue("@ClientName", Invoice.ClientName);
            if (Invoice.ClientAddress != null)
            {
                insertCommand.Parameters.AddWithValue("@ClientAddress", Invoice.ClientAddress);
            }
            else
            {
                insertCommand.Parameters.AddWithValue("@ClientAddress", DBNull.Value);
            }
            if (Invoice.ClientGSTIN != null)
            {
                insertCommand.Parameters.AddWithValue("@ClientGSTIN", Invoice.ClientGSTIN);
            }
            else
            {
                insertCommand.Parameters.AddWithValue("@ClientGSTIN", DBNull.Value);
            }
            if (Invoice.ClientContactNo != null)
            {
                insertCommand.Parameters.AddWithValue("@ClientContactNo", Invoice.ClientContactNo);
            }
            else
            {
                insertCommand.Parameters.AddWithValue("@ClientContactNo", DBNull.Value);
            }
            if (Invoice.ClientEMail != null)
            {
                insertCommand.Parameters.AddWithValue("@ClientEMail", Invoice.ClientEMail);
            }
            else
            {
                insertCommand.Parameters.AddWithValue("@ClientEMail", DBNull.Value);
            }
            insertCommand.Parameters.AddWithValue("@AdditionalDiscount", Invoice.AdditionalDiscount);
            if (Invoice.Remarks != null)
            {
                insertCommand.Parameters.AddWithValue("@Remarks", Invoice.Remarks);
            }
            else
            {
                insertCommand.Parameters.AddWithValue("@Remarks", DBNull.Value);
            }
            if (Invoice.PDFUrl != null)
            {
                insertCommand.Parameters.AddWithValue("@PDFUrl", Invoice.PDFUrl);
            }
            else
            {
                insertCommand.Parameters.AddWithValue("@PDFUrl", DBNull.Value);
            }
            insertCommand.Parameters.AddWithValue("@CompanyID", Invoice.CompanyID);
            insertCommand.Parameters.AddWithValue("@AddUserID", Invoice.AddUserID);
            insertCommand.Parameters.AddWithValue("@AddDate", Invoice.AddDate);
            if (Invoice.ArchiveUserID.HasValue == true)
            {
                insertCommand.Parameters.AddWithValue("@ArchiveUserID", Invoice.ArchiveUserID);
            }
            else
            {
                insertCommand.Parameters.AddWithValue("@ArchiveUserID", DBNull.Value);
            }
            if (Invoice.ArchiveDate.HasValue == true)
            {
                insertCommand.Parameters.AddWithValue("@ArchiveDate", Invoice.ArchiveDate);
            }
            else
            {
                insertCommand.Parameters.AddWithValue("@ArchiveDate", DBNull.Value);
            }
            insertCommand.Parameters.Add("@ReturnValue", System.Data.SqlDbType.Int);
            insertCommand.Parameters["@ReturnValue"].Direction = ParameterDirection.Output;
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                int count = System.Convert.ToInt32(insertCommand.Parameters["@ReturnValue"].Value);
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool Update(Invoice oldInvoice,
               Invoice newInvoice)
        {
            SqlConnection connection = PMMSData.GetConnection();
            string updateProcedure = "[InvoiceUpdate]";
            SqlCommand updateCommand = new SqlCommand(updateProcedure, connection);
            updateCommand.CommandType = CommandType.StoredProcedure;
            updateCommand.Parameters.AddWithValue("@NewInvoiceNo", newInvoice.InvoiceNo);
            updateCommand.Parameters.AddWithValue("@NewInvoiceDate", newInvoice.InvoiceDate);
            if (newInvoice.ProjectID.HasValue == true)
            {
                updateCommand.Parameters.AddWithValue("@NewProjectID", newInvoice.ProjectID);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@NewProjectID", DBNull.Value);
            }
            updateCommand.Parameters.AddWithValue("@NewClientID", newInvoice.ClientID);
            updateCommand.Parameters.AddWithValue("@NewClientName", newInvoice.ClientName);
            if (newInvoice.ClientAddress != null)
            {
                updateCommand.Parameters.AddWithValue("@NewClientAddress", newInvoice.ClientAddress);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@NewClientAddress", DBNull.Value);
            }
            if (newInvoice.ClientGSTIN != null)
            {
                updateCommand.Parameters.AddWithValue("@NewClientGSTIN", newInvoice.ClientGSTIN);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@NewClientGSTIN", DBNull.Value);
            }
            if (newInvoice.ClientContactNo != null)
            {
                updateCommand.Parameters.AddWithValue("@NewClientContactNo", newInvoice.ClientContactNo);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@NewClientContactNo", DBNull.Value);
            }
            if (newInvoice.ClientEMail != null)
            {
                updateCommand.Parameters.AddWithValue("@NewClientEMail", newInvoice.ClientEMail);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@NewClientEMail", DBNull.Value);
            }
            updateCommand.Parameters.AddWithValue("@NewAdditionalDiscount", newInvoice.AdditionalDiscount);
            if (newInvoice.Remarks != null)
            {
                updateCommand.Parameters.AddWithValue("@NewRemarks", newInvoice.Remarks);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@NewRemarks", DBNull.Value);
            }
            if (newInvoice.PDFUrl != null)
            {
                updateCommand.Parameters.AddWithValue("@NewPDFUrl", newInvoice.PDFUrl);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@NewPDFUrl", DBNull.Value);
            }
            updateCommand.Parameters.AddWithValue("@NewCompanyID", newInvoice.CompanyID);
            updateCommand.Parameters.AddWithValue("@NewAddUserID", newInvoice.AddUserID);
            updateCommand.Parameters.AddWithValue("@NewAddDate", newInvoice.AddDate);
            if (newInvoice.ArchiveUserID.HasValue == true)
            {
                updateCommand.Parameters.AddWithValue("@NewArchiveUserID", newInvoice.ArchiveUserID);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@NewArchiveUserID", DBNull.Value);
            }
            if (newInvoice.ArchiveDate.HasValue == true)
            {
                updateCommand.Parameters.AddWithValue("@NewArchiveDate", newInvoice.ArchiveDate);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@NewArchiveDate", DBNull.Value);
            }
            updateCommand.Parameters.AddWithValue("@OldInvoiceID", oldInvoice.InvoiceID);
            updateCommand.Parameters.AddWithValue("@OldInvoiceNo", oldInvoice.InvoiceNo);
            updateCommand.Parameters.AddWithValue("@OldInvoiceDate", oldInvoice.InvoiceDate);
            if (oldInvoice.ProjectID.HasValue == true)
            {
                updateCommand.Parameters.AddWithValue("@OldProjectID", oldInvoice.ProjectID);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@OldProjectID", DBNull.Value);
            }
            updateCommand.Parameters.AddWithValue("@OldClientID", oldInvoice.ClientID);
            updateCommand.Parameters.AddWithValue("@OldClientName", oldInvoice.ClientName);
            if (oldInvoice.ClientAddress != null)
            {
                updateCommand.Parameters.AddWithValue("@OldClientAddress", oldInvoice.ClientAddress);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@OldClientAddress", DBNull.Value);
            }
            if (oldInvoice.ClientGSTIN != null)
            {
                updateCommand.Parameters.AddWithValue("@OldClientGSTIN", oldInvoice.ClientGSTIN);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@OldClientGSTIN", DBNull.Value);
            }
            if (oldInvoice.ClientContactNo != null)
            {
                updateCommand.Parameters.AddWithValue("@OldClientContactNo", oldInvoice.ClientContactNo);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@OldClientContactNo", DBNull.Value);
            }
            if (oldInvoice.ClientEMail != null)
            {
                updateCommand.Parameters.AddWithValue("@OldClientEMail", oldInvoice.ClientEMail);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@OldClientEMail", DBNull.Value);
            }
            updateCommand.Parameters.AddWithValue("@OldAdditionalDiscount", oldInvoice.AdditionalDiscount);
            if (oldInvoice.Remarks != null)
            {
                updateCommand.Parameters.AddWithValue("@OldRemarks", oldInvoice.Remarks);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@OldRemarks", DBNull.Value);
            }
            if (oldInvoice.PDFUrl != null)
            {
                updateCommand.Parameters.AddWithValue("@OldPDFUrl", oldInvoice.PDFUrl);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@OldPDFUrl", DBNull.Value);
            }
            updateCommand.Parameters.AddWithValue("@OldCompanyID", oldInvoice.CompanyID);
            updateCommand.Parameters.AddWithValue("@OldAddUserID", oldInvoice.AddUserID);
            updateCommand.Parameters.AddWithValue("@OldAddDate", oldInvoice.AddDate);
            if (oldInvoice.ArchiveUserID.HasValue == true)
            {
                updateCommand.Parameters.AddWithValue("@OldArchiveUserID", oldInvoice.ArchiveUserID);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@OldArchiveUserID", DBNull.Value);
            }
            if (oldInvoice.ArchiveDate.HasValue == true)
            {
                updateCommand.Parameters.AddWithValue("@OldArchiveDate", oldInvoice.ArchiveDate);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@OldArchiveDate", DBNull.Value);
            }
            updateCommand.Parameters.Add("@ReturnValue", System.Data.SqlDbType.Int);
            updateCommand.Parameters["@ReturnValue"].Direction = ParameterDirection.Output;
            try
            {
                connection.Open();
                updateCommand.ExecuteNonQuery();
                int count = System.Convert.ToInt32(updateCommand.Parameters["@ReturnValue"].Value);
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool Delete(Invoice Invoice)
        {
            SqlConnection connection = PMMSData.GetConnection();
            string deleteProcedure = "[InvoiceDelete]";
            SqlCommand deleteCommand = new SqlCommand(deleteProcedure, connection);
            deleteCommand.CommandType = CommandType.StoredProcedure;
            deleteCommand.Parameters.AddWithValue("@OldInvoiceID", Invoice.InvoiceID);
            deleteCommand.Parameters.AddWithValue("@OldInvoiceNo", Invoice.InvoiceNo);
            deleteCommand.Parameters.AddWithValue("@OldInvoiceDate", Invoice.InvoiceDate);
            if (Invoice.ProjectID.HasValue == true)
            {
                deleteCommand.Parameters.AddWithValue("@OldProjectID", Invoice.ProjectID);
            }
            else
            {
                deleteCommand.Parameters.AddWithValue("@OldProjectID", DBNull.Value);
            }
            deleteCommand.Parameters.AddWithValue("@OldClientID", Invoice.ClientID);
            deleteCommand.Parameters.AddWithValue("@OldClientName", Invoice.ClientName);
            if (Invoice.ClientAddress != null)
            {
                deleteCommand.Parameters.AddWithValue("@OldClientAddress", Invoice.ClientAddress);
            }
            else
            {
                deleteCommand.Parameters.AddWithValue("@OldClientAddress", DBNull.Value);
            }
            if (Invoice.ClientGSTIN != null)
            {
                deleteCommand.Parameters.AddWithValue("@OldClientGSTIN", Invoice.ClientGSTIN);
            }
            else
            {
                deleteCommand.Parameters.AddWithValue("@OldClientGSTIN", DBNull.Value);
            }
            if (Invoice.ClientContactNo != null)
            {
                deleteCommand.Parameters.AddWithValue("@OldClientContactNo", Invoice.ClientContactNo);
            }
            else
            {
                deleteCommand.Parameters.AddWithValue("@OldClientContactNo", DBNull.Value);
            }
            if (Invoice.ClientEMail != null)
            {
                deleteCommand.Parameters.AddWithValue("@OldClientEMail", Invoice.ClientEMail);
            }
            else
            {
                deleteCommand.Parameters.AddWithValue("@OldClientEMail", DBNull.Value);
            }
            deleteCommand.Parameters.AddWithValue("@OldAdditionalDiscount", Invoice.AdditionalDiscount);
            if (Invoice.Remarks != null)
            {
                deleteCommand.Parameters.AddWithValue("@OldRemarks", Invoice.Remarks);
            }
            else
            {
                deleteCommand.Parameters.AddWithValue("@OldRemarks", DBNull.Value);
            }
            if (Invoice.PDFUrl != null)
            {
                deleteCommand.Parameters.AddWithValue("@OldPDFUrl", Invoice.PDFUrl);
            }
            else
            {
                deleteCommand.Parameters.AddWithValue("@OldPDFUrl", DBNull.Value);
            }
            deleteCommand.Parameters.AddWithValue("@OldCompanyID", Invoice.CompanyID);
            deleteCommand.Parameters.AddWithValue("@OldAddUserID", Invoice.AddUserID);
            deleteCommand.Parameters.AddWithValue("@OldAddDate", Invoice.AddDate);
            if (Invoice.ArchiveUserID.HasValue == true)
            {
                deleteCommand.Parameters.AddWithValue("@OldArchiveUserID", Invoice.ArchiveUserID);
            }
            else
            {
                deleteCommand.Parameters.AddWithValue("@OldArchiveUserID", DBNull.Value);
            }
            if (Invoice.ArchiveDate.HasValue == true)
            {
                deleteCommand.Parameters.AddWithValue("@OldArchiveDate", Invoice.ArchiveDate);
            }
            else
            {
                deleteCommand.Parameters.AddWithValue("@OldArchiveDate", DBNull.Value);
            }
            deleteCommand.Parameters.Add("@ReturnValue", System.Data.SqlDbType.Int);
            deleteCommand.Parameters["@ReturnValue"].Direction = ParameterDirection.Output;
            try
            {
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                int count = System.Convert.ToInt32(deleteCommand.Parameters["@ReturnValue"].Value);
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}

