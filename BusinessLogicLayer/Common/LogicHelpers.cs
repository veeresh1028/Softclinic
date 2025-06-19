using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLogicLayer.Common
{
    public class LogicHelpers
    {
        public static void SaveLogFile(string emp_name, string enc_pass)
        {
            string hiddenFolderPath = ConfigurationManager.AppSettings["LogPath"];

            if (!string.IsNullOrEmpty(hiddenFolderPath))
            {
                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, hiddenFolderPath);

                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                    System.IO.File.SetAttributes(fullPath, FileAttributes.Directory | FileAttributes.Hidden);
                }

                string filePath = Path.Combine(fullPath, $"log_{emp_name}.txt");

                try
                {
                    if (System.IO.File.Exists(filePath))
                    {
                        string content = "\n";
                        content += "--------------------------------------------------------------------------------------";
                        content += "\n";
                        content += $"Log Date & Time : {System.DateTime.Now}";
                        content += "\n";
                        content += $"Encryption : {enc_pass}";
                        content += "\n";
                        content += "--------------------------------------------------------------------------------------";
                        System.IO.File.AppendAllText(filePath, content);

                        Console.WriteLine("Text added to the existing file in the hidden folder.");
                    }
                    else
                    {
                        string content = "--------------------------------------------------------------------------------------";
                        content += "\n";
                        content += $"Log Date & Time : {System.DateTime.Now}";
                        content += "\n";
                        content += $"Encryption : {enc_pass}";
                        content += "\n";
                        content += "--------------------------------------------------------------------------------------";
                        System.IO.File.WriteAllText(filePath, content);

                        Console.WriteLine("New text file created in the hidden folder.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        public static string EmailTemplate(string empId, string name, string recoveryCode)
        {
            string resetPasswordLink = ConfigurationManager.AppSettings["ResetPasswordLink"].ToString();

            string key = empId + "_" + DateTime.Now.AddMinutes(30) + "_" + recoveryCode;

            string token = SecurityLayer.Encryptions.Encrypt(SecurityLayer.Encryptions.GetHashKey("VisionLicense"), key);

            resetPasswordLink = resetPasswordLink + "?token=" + HttpUtility.UrlEncode(token);

            string content = "Dear " + name.ToUpper() + ",<br><br>Trouble while signing in for ClinicSoft 9.0 account?. Resetting your password is easy.<br/>" +
                    " Just press the button below and follow the instructions. We’ll have you up and running in no time. ";

            string content2 = "If you didn't request this password reset, please ignore this email or if you need further assistance, please contact our support team.<br><br>This password reset link is only valid for the next 30 minutes.";


            string html = "<div style='background-color: #f6f6f6; font-family: sans-serif; -webkit-font-smoothing: antialiased; font-size: 14px; line-height: 1.4; margin: 0; padding: 0; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;'>" +
            "<table role='presentation' border='0' cellpadding='0' cellspacing='0' class='body' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%; background-color: #f6f6f6;'>" +
                "<tr>" +
                    "<td style='font-family: sans-serif; font-size: 14px; vertical-align: top;'>&nbsp;</td>" +
                    "<td class='container' style='font-family: sans-serif; font-size: 14px; vertical-align: top; display: block; Margin: 0 auto; max-width: 580px; padding: 10px; width: 580px;'>" +
                        "<div class='content' style='box-sizing: border-box; display: block; Margin: 0 auto; max-width: 580px; padding: 10px;'>" +
                            "<table role='presentation' class='main' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%; background: #ffffff; border-radius: 3px;'>" +
                                "<tr>" +
                                    "<td class='wrapper' style='font-family: sans-serif; font-size: 14px; vertical-align: top; box-sizing: border-box; padding: 20px;'>" +
                                        "<table role='presentation' border='0' cellpadding='0' cellspacing='0' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%;'>" +
                                            "<tr>" +
                                                "<td style='font-family: sans-serif; font-size: 14px; vertical-align: top;'>" +
                                                    "<img src='cid:image1' style = 'width:40%;margin-left: 28%;'> " +
                                                    "<p style='font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; Margin-bottom: 15px;'>" +
                                                        content +
                                                    "</p> " +
                                                    "<table role='presentation' border='0' cellpadding='0' cellspacing='0' class='btn btn-primary' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%; box-sizing: border-box;'>" +
                                                        "<tbody>" +
                                                            "<tr>" +
                                                                "<td align='left' style='font-family: sans-serif; font-size: 14px; vertical-align: top; padding-bottom: 15px;'>" +
                                                                    "<table role='presentation' border='0' cellpadding='0' cellspacing='0' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: auto;'>" +
                                                                        "<tbody>" +
                                                                            "<tr>" +
                                                                                "<td style='font-family: sans-serif; font-size: 14px; vertical-align: top; background-color: #6c9b34; border-radius: 5px; text-align: center;'>" +
                                                                                    "<a href='" + resetPasswordLink + "' target='_blank' style='display: inline-block; color: #ffffff; background-color: #6c9b34; border: solid 1px #6c9b34; border-radius: 5px; box-sizing: border-box; cursor: pointer; text-decoration: none; font-size: 14px; font-weight: bold; margin: 0; padding: 12px 25px; text-transform: capitalize; border-color: #6c9b34;'>Reset Password</a></td>" +
                                                                            "</tr>" +
                                                                        "</tbody>" +
                                                                    "</table>" +
                                                                "</td>" +
                                                            "</tr>" +
                                                        "</tbody>" +
                                                    "</table>" +
                                                    "<p style='font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; Margin-bottom: 15px;'>" +
                                                        content2 +
                                                    "</p> " +

                                                    "<p style='font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; Margin-bottom: 15px;'>" +
                                                        "Best Regards,</p>" +
                                                    "<p style='font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; Margin-bottom: 15px;'>" +
                                                        "ClinicSoft 9.0</p>" +
                                                "</td>" +
                                            "</tr>" +
                                        "</table>" +
                                    "</td>" +
                            "</tr>" +
                            "</table>" +
                            "<div class='footer' style='clear: both; Margin-top: 10px; text-align: center; width: 100%;'>" +
                                "<table role='presentation' border='0' cellpadding='0' cellspacing='0' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%;'>" +
                                    "<tr>" +
                                        "<td class='content-block' style='font-family: sans-serif; vertical-align: top; padding-bottom: 10px; padding-top: 10px; font-size: 12px; color: #999999; text-align: center;'>" +
                                            "<span class='apple-link' style='color: #999999; font-size: 12px; text-align: center;'> " +
                                                "(Contents in this email are confidential to the intended recipient. If you are not the intended recipient, " +
                                                "be advised that you have received this e-mail in error and that any use, dissemination, forwarding, " +
                                                "printing or copying of this e-mail is strictly prohibited. It may not be disclosed to or used by anyone other than its intended recipient, " +
                                                "nor may it be copied in any way. If received in error please email a reply to the sender, then delete it from your system.) " +
                                            "</span>" +
                                        "</td>" +
                                    "</tr>" +
                                "</table>" +
                            "</div>" +
                            "<div class='footer1' style='text-align:center;margin:auto;margin-top:-2%;'>" +
                                "<div style='margin-top:0%'><p style='font-size:0.7vw; color:gray;'>PO Box 95675, Office # 347 & 349, 3rd Floor, Damas Tower (2000 Burj), Rolla, Sharjah<br><a href='mailto:support@visionsoftwares.com' style='color: #66952c; text-decoration: none;'>support@visionsoftwares.com</a> | Call us on : +971 65634883 | <a href='https://www.visionsoftwares.com/' style='color: #66952c; text-decoration: none;'>www.visionsoftwares.com</a><br></div>" +
                                "<div> <p style='font-size:0.7vw; color:gray;'>Powered by <a href='https://www.visionsoftwares.com/' style='text-decoration: none; color: #66952c;' target='blank'> <b>Vision Technologies</b> </a></p></div>" +
                                "</div>" +
                            "</div>" +
                    "</td>" +
                    "<td style='font-family: sans-serif; font-size: 14px; vertical-align: top;'>&nbsp;</td>" +
                "</tr>" +
            "</table>";

            return html;
        }
    }
}
