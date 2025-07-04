using LPS_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;

namespace LPS_API.Helper
{
    public class GlobalFunction
    {

        public List<T> ConvertTo<T>(DataTable datatable) where T : new()
        {
            List<T> Temp = new List<T>();
            try
            {
                List<string> columnsNames = new List<string>();
                foreach (DataColumn DataColumn in datatable.Columns)
                    columnsNames.Add(DataColumn.ColumnName);
                Temp = datatable.AsEnumerable().ToList().ConvertAll<T>(row => getObject<T>(row, columnsNames));
                return Temp;
            }
            catch
            {
                return Temp;
            }

        }
        public T getObject<T>(DataRow row, List<string> columnsName) where T : new()
        {
            T obj = new T();
            try
            {
                string columnname = "";
                string value = "";
                PropertyInfo[] Properties;
                Properties = typeof(T).GetProperties();
                foreach (PropertyInfo objProperty in Properties)
                {
                    columnname = columnsName.Find(name => name.ToLower() == objProperty.Name.ToLower());
                    if (!string.IsNullOrEmpty(columnname))
                    {
                        value = row[columnname].ToString();
                        if (!string.IsNullOrEmpty(value))
                        {
                            if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null)
                            {
                                value = row[columnname].ToString().Replace("$", "").Replace(",", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);
                            }
                            else
                            {
                                value = row[columnname].ToString().Replace("%", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
                            }
                        }
                    }
                }
                return obj;
            }
            catch
            {
                return obj;
            }
        }

        public string Email(string Template , string email, string subject)
        {
            string sMessage;
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            try
            {

                string MailServer = ConfigurationManager.AppSettings["MailServer"].ToString();
                int MailServerPort = Convert.ToInt32(ConfigurationManager.AppSettings["MailServerPort"]);
                string MailerSenderName = ConfigurationManager.AppSettings["MailerSenderName"].ToString();
                string MailerSenderEMail = ConfigurationManager.AppSettings["MailerSenderEMail"].ToString();
                string MailServerUsername = ConfigurationManager.AppSettings["MailServerUsername"].ToString();
                string MailServerPassword = ConfigurationManager.AppSettings["MailServerPassword"].ToString();
                string MailServerSsl = ConfigurationManager.AppSettings["mailserverssl"].ToString();
                //you c"MailServerPassword"an provide invalid from address. but to address Should be valil
                MailAddress fromAddress = new MailAddress(MailerSenderEMail, MailerSenderName);


                //smtpClient.Host = "192.168.10.56";
                smtpClient.Port = MailServerPort;
                smtpClient.Host = MailServer;
                //smtpClient.Port = 587;
                if(MailServerSsl == "1") {
                    smtpClient.EnableSsl = true;
                }
                else
                {
                    smtpClient.EnableSsl = false;
                }
              

                //smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential(MailServerUsername, MailServerPassword);

                message.From = fromAddress;
                message.To.Add(email); //Recipent email 
                message.Subject = subject;
                message.Body = Template;
                message.IsBodyHtml = true;

                //smtpClient.EnableSsl = true; 

                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtpClient.Send(message);

                sMessage = "Email sent.";
            }
            catch (Exception ex)
            {
                sMessage = "Coudn't send the message!\n " + ex.Message;
            }

            return sMessage;
        }

        public DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
              TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
        
        public string ToRupiah(string angka)
        {
            string result = "";
            string F = "";
            string L1 = "";
            string L2 = "";
            string L3 = "";
            string L4 = "";
            string L5 = "";
            string L6 = "";

            if (angka.Length > 3)
            {
                L1 = "." + angka.Substring(angka.Length - 3, 3);
                F = angka.Substring(0, angka.Length - 3);
            }
            if(angka.Length > 6)
            {
                L2 = "." + angka.Substring(angka.Length - 6, 3);
                F = angka.Substring(0, angka.Length - 6);
            }
            if (angka.Length > 9)
            {
                L3 = "." + angka.Substring(angka.Length - 9, 3);
                F = angka.Substring(0, angka.Length - 9);
            }
            if (angka.Length > 12)
            {
                L4 = "." + angka.Substring(angka.Length - 12, 3);
                F = angka.Substring(0, angka.Length - 12);
            }
            if (angka.Length > 15)
            {
                L5 = "." + angka.Substring(angka.Length - 15, 3);
                F = angka.Substring(0, angka.Length - 15);
            }
            if (angka.Length > 18)
            {
                L6 = "." + angka.Substring(angka.Length - 18, 3);
                F = angka.Substring(0, angka.Length - 18);
            }

            if (angka.Length <= 3)
            {
                result = "Rp" + angka + ",-";
            }
            else
            {
                result = "Rp" + F + L6 + L5 + L4 + L3 + L2 + L1 + ",-";
            }

            return result;
            //return String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N}", angka);

        }
    }
}