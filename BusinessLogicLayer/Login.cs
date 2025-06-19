using BusinessEntities;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BusinessEntities.Common;
using System.IO;

namespace BusinessLogicLayer
{
    public class Login
    {
        #region Login Authentication
        public static CurrentUser Employees_Check_Login_Details(string username, string password)
        {
            DataTable dt = DataAccessLayer.Login.DAL_Employees_Check_Login_Details(username);
            CurrentUser user = new CurrentUser();
            string dbPassHash = string.Empty;
            string dbPassSalt = string.Empty;

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                dbPassHash = dr["el_key1"].ToString();
                dbPassSalt = dr["el_key2"].ToString();

                if (Encryptions.ValidatePassword(password, dbPassHash, dbPassSalt))
                {
                    user.isValid = true;
                    user.empId = Convert.ToInt32(dr["empId"]);
                    user.emp_name = dr["emp_name"].ToString();
                    user.emp_login = dr["emp_login"].ToString();
                    user.emp_desig = Convert.ToInt32(dr["emp_desig"]);
                    user.designation = dr["emp_desig_name"].ToString();
                    user.emp_dept = Convert.ToInt32(dr["emp_dept"]);
                    user.emp_dept_name = dr["emp_dept_name"].ToString();
                    user.emp_branch = Convert.ToInt32(dr["emp_branch"]);
                    user.emp_whatsappId = dr["emp_whatsappId"].ToString();
                    user.emp_photo = dr["emp_photo"].ToString();
                    user.set_company = dr["set_company"].ToString();
                    user.header_logo = dr["set_header_image"].ToString();
                    user.footer_logo = dr["set_footer_image"].ToString();
                    user.emp_outside_access = dr["emp_outside_access"].ToString();

                    int passwordValidityInDays = Convert.ToInt32(dr["el_passwordValidity"]);
                    DateTime passwordModifiedDateTime = Convert.ToDateTime(dr["el_modifiedDateTime"]);
                    DateTime expirationDate = passwordModifiedDateTime.AddDays(passwordValidityInDays);
                    DateTime currentDate = DateTime.Now;
                    user.password_validity = (expirationDate - currentDate).Days;
                }
                else
                {
                    user.isValid = false;
                }
            }
            else
            {
                user.isValid = false;
            }

            return user;
        }
        #endregion

        #region Change Password
        public static bool Employees_Check_First_Time_LogIn(int empId)
        {
            try
            {
                DataTable dt = DataAccessLayer.Login.DAL_Check_First_Time_LogIn(empId);

                if (dt.Rows.Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Employees_Change_Password(string hashpass, string saltpass, int empId)
        {
            try
            {
                int result = DataAccessLayer.Login.DAL_Employees_Change_Password(hashpass, saltpass, empId);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Employees_Password_History(string username, string password)
        {
            try
            {
                DataTable dt = DataAccessLayer.Login.DAL_Employees_Password_History(username);

                bool isUsed = false;
                string dbPassHash = string.Empty;
                string dbPassSalt = string.Empty;

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dbPassHash = dr["ela_key1"].ToString();
                        dbPassSalt = dr["ela_key2"].ToString();

                        if (Encryptions.ValidatePassword(password, dbPassHash, dbPassSalt))
                        {
                            isUsed = true;

                            break;
                        }
                    }
                }

                return isUsed;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Forgot Password
        public static mForgotPasswordResponse GetForgotPasswordDetails(string username)
        {
            mForgotPasswordResponse response = new mForgotPasswordResponse();

            try
            {
                DataTable dt = DataAccessLayer.Login.DAL_GetForgotPasswordDetails(username);

                string dbPassHash = string.Empty;
                string dbPassSalt = string.Empty;

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];

                    if (!string.IsNullOrEmpty(dr["el_recoverEmail"].ToString()))
                    {
                        string[] mask = dr["el_recoverEmail"].ToString().Split('@');

                        if (mask.Length == 2)
                        {
                            string htmlString = BusinessLogicLayer.Common.LogicHelpers.EmailTemplate(dr["empId"].ToString(), dr["emp_name"].ToString(), dr["el_recoverCode"].ToString());
                            string emailLogoLink = ConfigurationManager.AppSettings["EmailLogoLink"].ToString();

                            try
                            {
                                MailMessage message = new MailMessage();
                                SmtpClient smtp = new SmtpClient();
                                message.From = new MailAddress(dr["set_auth_user"].ToString().Trim());
                                message.To.Add(new MailAddress(dr["el_recoverEmail"].ToString()));
                                message.Subject = "Password Reset Request from ClinicSoft 9.0";
                                message.IsBodyHtml = true;
                                message.Body = htmlString;

                                // Attach Logo To Email
                                WebClient webClient = new WebClient();
                                byte[] imageBytes = webClient.DownloadData(emailLogoLink);
                                MemoryStream imageStream = new MemoryStream(imageBytes);
                                Attachment imageAttachment = new Attachment(imageStream, "logo.png");
                                imageAttachment.ContentId = "image1";
                                message.Attachments.Add(imageAttachment);

                                int _port = 587;
                                int.TryParse(dr["set_auth_port"].ToString(), out _port);
                                smtp.Port = _port;
                                smtp.Host = dr["set_auth_ip"].ToString();
                                smtp.EnableSsl = (dr["set_auth_ssl"].ToString() == "Yes") ? true : false;
                                smtp.UseDefaultCredentials = false;
                                smtp.Credentials = new NetworkCredential(dr["set_auth_user"].ToString().Trim(), dr["set_auth_pass"].ToString().Trim());
                                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                                smtp.Send(message);

                                string _mask_email = EmailMasker.MaskEmail(dr["el_recoverEmail"].ToString());

                                response.status = "success";
                                response.error_message = "We've sent the New Password to " + _mask_email + ". Check Inbox and Login with new Password! Please check spam incase if not received.";
                            }
                            catch (Exception ex)
                            {
                                response.status = "error";
                                response.error_message = "Email Sending Failed! " + ex.Message;
                            }
                        }
                        else
                        {
                            response.status = "error";
                            response.error_message = "E-mail address provided is not valid, Please contact your system administrator.";
                        }
                    }
                }
                else
                {
                    response.status = "error";
                    response.error_message = "Invalid email! No account found which is associated with this address, Please contact your system administrator.";
                }
            }
            catch (Exception ex)
            {
                response.status = "error";
                response.error_message = ex.Message;
            }

            return response;
        }
        #endregion

        #region Reset Password
        public static mForgotPasswordResponse ResetEmployeePassword(mResetPassword reset)
        {
            mForgotPasswordResponse response = new mForgotPasswordResponse();

            try
            {
                string saltpass;
                string hashpass = SecurityLayer.Encryptions.CreateHash(reset.emp_pass, out saltpass);

                int val = DataAccessLayer.Login.DAL_Reset_Password(reset.empId, saltpass, hashpass);

                if (val > 0)
                {
                    response.isReset = true;
                }
                else
                {
                    response.isReset = false;
                }
            }
            catch (Exception ex)
            {
                response.status = "error";
                response.error_message = ex.Message;
            }

            return response;
        }

        public static bool Employees_Password_History_Reset(int empId, string password)
        {
            try
            {
                DataTable dt = DataAccessLayer.Login.DAL_Employees_Password_History_Reset(empId);

                bool isUsed = false;
                string dbPassHash = string.Empty;
                string dbPassSalt = string.Empty;

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dbPassHash = dr["ela_key1"].ToString();
                        dbPassSalt = dr["ela_key2"].ToString();

                        if (Encryptions.ValidatePassword(password, dbPassHash, dbPassSalt))
                        {
                            isUsed = true;

                            break;
                        }
                    }
                }

                return isUsed;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Check_Reset_Requested(int empId)
        {
            try
            {
                DataTable dt = DataAccessLayer.Login.DAL_Check_Reset_Requested(empId);

                string emp_name = string.Empty;

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];

                    if (Convert.ToInt32(dr["el_resetStatus"]) == 1)
                    {
                        emp_name = dr["emp_name"].ToString();
                    }
                }

                return emp_name;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}