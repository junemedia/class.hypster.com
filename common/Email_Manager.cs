using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Mail;
using System.Web;


namespace hypster_tv_DAL
{
    public class Email_Manager
    {
        private string fromPassword = "aLameda#503";


        public Email_Manager()
        {
        }


        public string GenerateConfirmString(string contact_email)
        {
            string email_conf_str = System.Uri.EscapeDataString(hypster_tv_DAL.EncryptionManager.EncryptString(contact_email, fromPassword));
            Random rand = new Random();
            return "http://hypster.com/hypster/Conf_Account?rid=" + email_conf_str + "&rnd=" + rand.Next(1, 100000).ToString();
        }


        //----------------------------------------------------------------------------------------------------------
        public bool SendPasswordRecoveryEMail(string user_email, string email_string)
        {
            bool send_success = true;
            try
            {
                //var fromAddress = new MailAddress("domainadmin@hypster.com", "Info Hypster");
                var fromAddress = new MailAddress("noreply@hypster.com", "Info Hypster");
                var toAddress = new MailAddress(user_email, "");
                

                string subject = "Hypster Password Recovery";

                string body_msg = "";
                body_msg += email_string;




                var smtp = new SmtpClient
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body_msg
                })
                {
                    smtp.Send(message);
                }

            }
            catch (Exception ex)
            {
                string tmp_str = ex.Message.ToString();
                send_success = false;
            }

            return send_success;
        }
        //----------------------------------------------------------------------------------------------------------


        
        //----------------------------------------------------------------------------------------------------------
        public bool SendUsernameChangesNotification(string username, string user_email)
        {
            bool send_success = true;
            try
            {
                //var fromAddress = new MailAddress("domainadmin@hypster.com", "Info Hypster");
                var fromAddress = new MailAddress("noreply@hypster.com", "Info Hypster");
                var toAddress = new MailAddress(user_email, "");


                string subject = "Hypster Username updates";

                string body_msg = "";

                body_msg += "Hey Hypster User,<br/><br/>";
                body_msg += "We're writing to let you know that your username has been changed. This is because it had special characters in it that are no longer compatible with hypster.com. We're updating the site in order to improve our users' experience and unfortunately part of this upgrade means we'll need to make this change.<br/><br/>";
                body_msg += "You new username is now: " + username + " <br/><br/>";
                body_msg += "We hope you understand that this change is necessary and if you have any questions make sure to contact us at info@hypster.com. <br/><br/>";
                body_msg += "Gratefully,<br/>";
                body_msg += "The Hypster Team <br/>";



                var smtp = new SmtpClient
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body_msg,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }

            }
            catch (Exception ex)
            {
                string tmp_str = ex.Message.ToString();
                send_success = false;
            }

            return send_success;
        }
        //----------------------------------------------------------------------------------------------------------





        //----------------------------------------------------------------------------------------------------------
        public bool SendContactUsEmail(string user_email_1, string user_email_2, string user_email_3, string email_subject, string contact_email, string email_body)
        {
            bool send_success = true;
            try
            {
                //var fromAddress = new MailAddress("domainadmin@hypster.com", contact_email);
                var fromAddress = new MailAddress("info@hypster.com", contact_email);
                //var toAddress = new MailAddress(user_email_1, ""); //will need to uncoment
                var toAddress = new MailAddress("viktor@baronsmedia.com", ""); //will need to comment
                

                string subject = email_subject;

                string body_msg = "";
                body_msg += contact_email + " :" + email_body;




                var smtp = new SmtpClient
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body_msg//,
                    //IsBodyHtml = true
                })
                {
                    
                    message.CC.Add(new MailAddress(user_email_2));
                    message.CC.Add(new MailAddress(user_email_3));
                    message.CC.Add(new MailAddress("karen@baronsmedia.com"));
                    message.CC.Add(new MailAddress("noah@baronsmedia.com"));
                    smtp.Send(message);
                }

            }
            catch (Exception ex)
            {
                string tmp_str = ex.Message.ToString();
                send_success = false;
            }

            return send_success;

        }
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        public bool SendGamersRewardsEmail(string YourName, string TwitchName, string HypsterName, string YourEmail, string ConfEmail, string Message)
        {
            bool send_success = true;
            try
            {

                var fromAddress = new MailAddress("info@hypster.com", YourEmail);
                var toAddress = new MailAddress("viktor@baronsmedia.com", ""); //will need to comment


                string subject = "GAMERS REWARDS PROGRAM";

                string body_msg = "";
                body_msg += " Name:" + YourName + " | Twitch:" + TwitchName + " | Hypster:" + HypsterName + " | Email:" + YourEmail + " | Message:" + Message;




                var smtp = new SmtpClient
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),

                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body_msg
                })
                {
                    message.CC.Add(new MailAddress("karen@baronsmedia.com"));
                    message.CC.Add(new MailAddress("jim@baronsmedia.com"));
                    smtp.Send(message);
                }

            }
            catch (Exception ex)
            {
                string tmp_str = ex.Message.ToString();
                send_success = false;
            }

            return send_success;

        }
        //----------------------------------------------------------------------------------------------------------






        //----------------------------------------------------------------------------------------------------------
        public bool SendFeedbackEmail(string email_subject, string contact_email, string email_body)
        {
            bool send_success = true;
            try
            {
                var fromAddress = new MailAddress("info@hypster.com", contact_email);
                var toAddress = new MailAddress("viktor@baronsmedia.com", ""); //will need to comment


                string subject = email_subject;

                string body_msg = "";
                body_msg += contact_email + " :" + email_body;




                var smtp = new SmtpClient
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),

                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = "Hypster Feedback Form: " + subject,
                    Body = body_msg//,
                    //IsBodyHtml = true
                })
                {
                    message.CC.Add(new MailAddress("jim@baronsmedia.com"));
                    message.CC.Add(new MailAddress("karen@baronsmedia.com"));
                    smtp.Send(message);
                }

            }
            catch (Exception ex)
            {
                string tmp_str = ex.Message.ToString();
                send_success = false;
            }

            return send_success;

        }
        //----------------------------------------------------------------------------------------------------------






        //----------------------------------------------------------------------------------------------------------
        public bool SendEmailessage(string email_subject, string contact_email, string email_body)
        {
            bool send_success = true;
            try
            {
                //var fromAddress = new MailAddress("domainadmin@hypster.com", contact_email);
                var fromAddress = new MailAddress("info@hypster.com", contact_email);
                var toAddress = new MailAddress(contact_email, "");
                


                string subject = email_subject;

                string body_msg = "";
                body_msg += contact_email + " :" + email_body;




                var smtp = new SmtpClient
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),

                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body_msg
                })
                {
                    smtp.Send(message);
                }

            }
            catch (Exception ex)
            {
                string tmp_str = ex.Message.ToString();
                send_success = false;
            }

            return send_success;
        }
        //----------------------------------------------------------------------------------------------------------



        // send welcome email after registration
        /*
        //----------------------------------------------------------------------------------------------------------
        public bool SendWelcomeEmail(string email_subject, string contact_email)
        {
            bool send_success = true;
            try
            {
                string email_conf_str = System.Uri.EscapeDataString(hypster_tv_DAL.EncryptionManager.EncryptString(contact_email, fromPassword));


                string EMAIL_BODY_STR = "";

                EMAIL_BODY_STR += "<div style='float:left; width:100%; min-height:350px; background-color:#42606f;'>";

                EMAIL_BODY_STR += "<div style='float:left; width:100%; height:50px; background-color:#2e2e2e; border-bottom:1px solid #1e1e1e; color:#DEDEDE;'>";
                EMAIL_BODY_STR += "<img style='float:left; width:33px; height:40px; margin:5px 0 0 25px; border:none;' src='http://hypster.com/imgs/shared/small_logo.png' />";
                EMAIL_BODY_STR += "<a href='http://hypster.com?rtg=e1011' style='float:left; margin:15px 0 0 10px; color:#DEDEDE; font-size:24px; text-decoration:none;'>HYPSTER</a>";
                EMAIL_BODY_STR += "<a href='http://hypster.com/Listen?rtg=e1011' style='float:left; margin:22px 0 0 23px; color:#DEDEDE; font-size:16px; text-decoration:none;'>Listen</a>";
                EMAIL_BODY_STR += "<a href='http://hypster.com/Create?rtg=e1011' style='float:left; margin:22px 0 0 17px; color:#DEDEDE; font-size:16px; text-decoration:none;'>Create</a>";
                EMAIL_BODY_STR += "<a href='http://hypster.com/Connect?rtg=e1011' style='float:left; margin:22px 0 0 17px; color:#DEDEDE; font-size:16px; text-decoration:none;'>Connect</a>";
                EMAIL_BODY_STR += "</div>";


                EMAIL_BODY_STR += "<div style='float:left; width:90%; min-height:50px; padding:1%; background-color:#2e2e2e; color:#FFFFFF; margin-top:13px; border-radius:3px; margin-left:-2px;'>";
                EMAIL_BODY_STR += "<div style='float:right; width:91%; font-size:14px; line-height:20px;'>";
                EMAIL_BODY_STR += "";
                EMAIL_BODY_STR += "<span style='font-size:16px;'>Welcome</span>,<br/>";
                EMAIL_BODY_STR += "<br/>";
                EMAIL_BODY_STR += "Click here to confirm your account <a style='color:#FFFFFF;' href='http://hypster.com/hypster/Conf_Account?rid=" + email_conf_str + "'>http://hypster.com/hypster/Conf_Account?rid=" + email_conf_str + "</a>";
                EMAIL_BODY_STR += "<br/>";
                EMAIL_BODY_STR += "We are happy to see that you’ve joined our site and we want to express our gratitude. We also have to let you know what you are in store for now that you’ve joined Hypster.com.<br/>";
                EMAIL_BODY_STR += "<br/>";
                EMAIL_BODY_STR += "Hypster has been evolving. While we still provide you with players for your blogs, Tumblrs and websites, we do a lot more. <br/>";
                EMAIL_BODY_STR += "</div>";
                EMAIL_BODY_STR += "</div>";

                EMAIL_BODY_STR += "<div style='float:right; width:90%; min-height:50px; padding:1%; background-color:#9da2a4; color:#333638; margin-top:13px; border-radius:3px; margin-right:-2px;'>";
                EMAIL_BODY_STR += "<div style='float:left; width:91%; font-size:14px; line-height:20px; '>";
                EMAIL_BODY_STR += "";
                EMAIL_BODY_STR += "We are a hub for music, both new and old. From our archives you can create and share playlists. On our connect page you can build a personalized music page, displaying your favorite music and sharing it with other users.<br/>";
                EMAIL_BODY_STR += "<br/>";
                EMAIL_BODY_STR += "With our extensive library, Hypster is the perfect venue for music discovery, keeping up with popular music and listening to radio stations.  Hope to see you soon!<br/>";
                EMAIL_BODY_STR += "<br/>";
                EMAIL_BODY_STR += "Gratefully,<br/>";
                EMAIL_BODY_STR += "The Hypster Team<br/>";
                EMAIL_BODY_STR += "</div>";
                EMAIL_BODY_STR += "</div>";


                EMAIL_BODY_STR += "<div style='float:left; width:100%; height:80px; line-height:30px; background-color:#2e2e2e; color:#FFFFFF; margin-top:13px;'>";
                EMAIL_BODY_STR += "<div style='margin:25px 0 0 20px;'>-let's be social- <a href='http://bit.ly/14dPHNr' style='color:#FFFFFF;'>Twitter</a>&nbsp;&nbsp;<a href='http://bit.ly/15K3GKU' style='color:#FFFFFF;'>Tumblr</a>&nbsp;&nbsp;<a href='http://on.fb.me/17OxK4p' style='color:#FFFFFF;'>Facebook</a> </div>";
                EMAIL_BODY_STR += "</div>";

                EMAIL_BODY_STR += "</div>";






                var fromAddress = new MailAddress("domainadmin@hypster.com", contact_email);
                var toAddress = new MailAddress(contact_email, "");
                


                string subject = email_subject;

                string body_msg = "";
                body_msg += EMAIL_BODY_STR;




                var smtp = new SmtpClient
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),

                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body_msg,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }

            }
            catch (Exception ex)
            {
                string tmp_str = ex.Message.ToString();
                send_success = false;
            }

            return send_success;
        }
        //----------------------------------------------------------------------------------------------------------
        */




        // send welcome email after registration
        //----------------------------------------------------------------------------------------------------------
        public bool SendWelcomeEmail(string email_subject, string contact_email)
        {
            bool send_success = true;
            try
            {
                string email_conf_str = System.Uri.EscapeDataString(hypster_tv_DAL.EncryptionManager.EncryptString(contact_email, fromPassword));


                string EMAIL_BODY_STR = "";

                EMAIL_BODY_STR += "<div style='float:left; width:100%; min-height:350px; background-color:#FFFFFF;'>";

                EMAIL_BODY_STR += "<div style=' width:740px; margin:auto;'>";
                EMAIL_BODY_STR += "<div style=' float:left; width:100%; min-height:500px; background-color:#FFFFFF;'>";
            


                EMAIL_BODY_STR += "<div style=' float:left; width:100%; text-align:center; '>";
                    EMAIL_BODY_STR += "<a href='http://hypster.com' target='_blank'>";
                        EMAIL_BODY_STR += "<img alt='' src='http://hypster.com/imgs/email/hypster_conf_header.jpg' style=' margin:auto; border:none; ' />";
                    EMAIL_BODY_STR += "</a>";
                EMAIL_BODY_STR += "</div>";

                EMAIL_BODY_STR += "<div style=' float:left; width:100%; text-align:center; '>";
                    EMAIL_BODY_STR += "<img alt='' src='http://hypster.com/imgs/email/hypster_conf_img.jpg' style=' margin:auto; width:500px; border:none;' />";
                EMAIL_BODY_STR += "</div>";


                EMAIL_BODY_STR += "<div style=' float:left; width:96%; text-align:center; margin:10px 0 0 2%; color:#333333; font-size:14px; line-height:23px; font-family:arial,helvetica neue,helvetica,sans-serif; '>";
                    EMAIL_BODY_STR += "This is to confirm that you just signed up on Hypster.com. (That was you, right?) Simply click below and your life will be enriched beyond imagination with #BREAKING news, music playlists, custom players, and a little bit of indescribable magic. And we could all use a little bit of that.";
                EMAIL_BODY_STR += "</div>";

                EMAIL_BODY_STR += "<div style=' float:left; width:96%; text-align:center; margin:15px 0 0 2%; padding:0 0 20px 0; border-bottom:1px solid #d9d9d9; color:#333333; '>";

                Random rand = new Random();

                EMAIL_BODY_STR += "<a href='http://hypster.com/hypster/Conf_Account?rid=" + email_conf_str + "&rnd=" + rand.Next(1, 100000).ToString() +"'>";
                    EMAIL_BODY_STR += "<img alt='' src='http://hypster.com/imgs/email/conf_btn.png' style=' margin:auto; cursor:pointer; border:none; ' />";
                EMAIL_BODY_STR += "</a>";

                EMAIL_BODY_STR += "</div>";


                EMAIL_BODY_STR += "<div style=' float:left; width:96%; text-align:center; margin:7px 0 0 2%; padding:6px 0 6px 0; color:#333333; font-size:14px; line-height:22px; border-top:1px solid #d9d9d9; border-bottom:1px solid #d9d9d9; font-family:arial,helvetica neue,helvetica,sans-serif; '>";
                    EMAIL_BODY_STR += "Hypster. More Music. Enjoy";
                EMAIL_BODY_STR += "</div>";


                EMAIL_BODY_STR += "<div style=' float:left; width:96%; text-align:center; margin:7px 0 0 2%; padding:6px 0 6px 0; color:#333333; font-size:14px; line-height:22px; border-top:1px solid #d9d9d9; border-bottom:1px solid #d9d9d9; font-family:arial,helvetica neue,helvetica,sans-serif; '>";
                
                    EMAIL_BODY_STR += "<a href='http://hypsterblog.tumblr.com/' target='_blank'>";
                        EMAIL_BODY_STR += "<img alt='' src='http://hypster.com/imgs/social_icons/tumblr_btn.png' style=' margin:auto; width:30px; padding:10px 10px 0 10px; cursor:pointer; border:none; ' />";
                    EMAIL_BODY_STR += "</a>";
                
                    EMAIL_BODY_STR += "<a href='https://twitter.com/Hypsterdotcom' target='_blank'>";
                        EMAIL_BODY_STR += "<img alt='' src='http://hypster.com/imgs/social_icons/twitter_btn.png' style=' margin:auto; width:30px; padding:10px 10px 0 10px; cursor:pointer; border:none; ' />";
                    EMAIL_BODY_STR += "</a>";
                
                    EMAIL_BODY_STR += "<a href='https://www.facebook.com/Hypster' target='_blank'>";
                        EMAIL_BODY_STR += "<img alt='' src='http://hypster.com/imgs/social_icons/facebook_btn.png' style=' margin:auto; width:30px; padding:10px 10px 0 10px; cursor:pointer; border:none; ' />";
                    EMAIL_BODY_STR += "</a>";

                EMAIL_BODY_STR += "</div>";


                EMAIL_BODY_STR += "</div>";
                EMAIL_BODY_STR += "</div>";






                
                var fromAddress = new MailAddress("domainadmin@hypster.com", contact_email);
                var toAddress = new MailAddress(contact_email, "");
                


                string subject = email_subject;

                string body_msg = "";
                body_msg += EMAIL_BODY_STR;




                var smtp = new SmtpClient
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),

                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body_msg,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }
               

            }
            catch (Exception ex)
            {
                string tmp_str = ex.Message.ToString();
                send_success = false;
            }

            return send_success;
        }
        //----------------------------------------------------------------------------------------------------------
        







        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++



        // send welcome email after registration
        //----------------------------------------------------------------------------------------------------------
        public bool SendSubscriberEmail_09_16_13(string email_subject, string email_body, string contact_email)
        {
            bool send_success = true;
            try
            {
                string email_conf_str = System.Uri.EscapeDataString(hypster_tv_DAL.EncryptionManager.EncryptString(contact_email, fromPassword));


                string EMAIL_BODY_STR = "";
                EMAIL_BODY_STR = email_body;


                var fromAddress = new MailAddress("domainadmin@hypster.com", "Hypster Updates");
                var toAddress = new MailAddress(contact_email, "");



                string subject = email_subject;

                string body_msg = "";
                body_msg += EMAIL_BODY_STR;




                var smtp = new SmtpClient
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),

                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body_msg,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }

            }
            catch (Exception ex)
            {
                string tmp_str = ex.Message.ToString();
                send_success = false;
            }

            return send_success;
        }
        //----------------------------------------------------------------------------------------------------------











        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        #region TEMP_COMMENT


        //TEMP
        //public bool SendPasswordRecoveryEMail(string user_email, string email_string, string nnp)
        //{
        //    bool send_success = true;
        //    try
        //    {
        //        var fromAddress = new MailAddress("domainadmin@hypster.com", "Info Hypster");
        //        var toAddress = new MailAddress(user_email, "");
        //        string fromPassword = "aLameda#503";

        //        string subject = "Hypster Password Recovery";

        //        string body_msg = "";
        //        body_msg += email_string;




        //        var smtp = new SmtpClient
        //        {
        //            UseDefaultCredentials = false,
        //            Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
        //            Host = "smtp.gmail.com",
        //            Port = 587,
        //            EnableSsl = true,
        //            DeliveryMethod = SmtpDeliveryMethod.Network
        //        };
        //        using (var message = new MailMessage(fromAddress, toAddress)
        //        {
        //            Subject = subject,
        //            Body = body_msg//,
        //            //IsBodyHtml = true
        //        })
        //        {
        //            smtp.Send(message);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        string tmp_str = ex.Message.ToString();
        //        send_success = false;
        //        //nsVVS.ErrorWriter.WriteError(ex, "RegisterUserControl.ascx:SendConfirmationEmail", ex.Message.ToString());
        //    }

        //    return send_success;

        //}


        //TEMP
        public bool SendConfirmationEMail(string p_email_to, string p_reg_guid)
        {
            //bool send_success = true;
            //try
            //{
            //    var fromAddress = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["Email_FromEmail"], "Info Fav-Links");
            //    var toAddress = new MailAddress(p_email_to, "");
            //    string fromPassword = System.Configuration.ConfigurationManager.AppSettings["Email_Pass"];

            //    string subject = "Fav-Links: Registration Confirmation";

            //    string body_msg = "";
            //    body_msg += "Thanks for signing up for Fav-Links. To activate your account, please click ";
            //    body_msg += "<a href='http://fav-links.org/Acct/Interface/ConfirmAcct.aspx?REGGUID=" + HttpUtility.UrlEncode(p_reg_guid) + "'>here</a> ";
            //    body_msg += "or copy and paste this url http://fav-links.org/Acct/Interface/ConfirmAcct.aspx?REGGUID=" + HttpUtility.UrlEncode(p_reg_guid) + " ";
            //    body_msg += Add_UnsubscribeMessage_to_email();
                


            //    var smtp = new SmtpClient
            //    {
            //        UseDefaultCredentials = false,
            //        Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
            //        Host = System.Configuration.ConfigurationManager.AppSettings["Email_SMTP"],
            //        Port = 587,
            //        EnableSsl = true,
            //        DeliveryMethod = SmtpDeliveryMethod.Network
            //    };
            //    using (var message = new MailMessage(fromAddress, toAddress)
            //    {
            //        Subject = subject,
            //        Body = body_msg,
            //        IsBodyHtml = true
            //    })
            //    {
            //        smtp.Send(message);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    send_success = false;
            //    //nsVVS.ErrorWriter.WriteError(ex, "RegisterUserControl.ascx:SendConfirmationEmail", ex.Message.ToString());
            //}

            //return send_success;


            //tmp
            return true;
        }

        //TEMP
        public string EmailSubscribers(string p_email_subject, string p_email_body)
        {
            //string o_restMessage = "";
            
            //try
            //{
            //    FavLinks_DAL.UserManagement o_userManager = new FavLinks_DAL.UserManagement();
            //    List<FavLinks_DAL.c_User> o_usersList = o_userManager.Get_Subscribers_List();



            //    foreach (FavLinks_DAL.c_User o_user in o_usersList)
            //    {

            //        var fromAddress = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["Email_FromEmail"], "Info Fav-Links");
            //        var toAddress = new MailAddress(o_user.Email, o_user.First_Name + " " + o_user.Last_Name);
            //        string fromPassword = System.Configuration.ConfigurationManager.AppSettings["Email_Pass"];


            //        string subject = p_email_subject;

            //        string body_msg = "";
            //        body_msg += p_email_body;
            //        body_msg += Add_UnsubscribeMessage_to_email();


            //        var smtp = new SmtpClient
            //        {
            //            UseDefaultCredentials = false,
            //            Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
            //            Host = System.Configuration.ConfigurationManager.AppSettings["Email_SMTP"],
            //            Port = 587,
            //            EnableSsl = true,
            //            DeliveryMethod = SmtpDeliveryMethod.Network
            //        };
            //        using (var message = new MailMessage(fromAddress, toAddress)
            //        {
            //            Subject = subject,
            //            Body = body_msg,
            //            IsBodyHtml = true
            //        })
            //        {
            //            smtp.Send(message);
            //        }



            //    }

            //}
            //catch (Exception ex)
            //{
            //    o_restMessage = "Exception Sending Eamil. Please Check logs.";
            //    //nsVVS.ErrorWriter.WriteError(ex, "Contacts.aspx:SendPasswordRecoveryEMail", ex.Message.ToString());
            //}


            //return o_restMessage;


            //tmp
            return "";
        }

        //-----------------------------------------------------------------------------------------------------------------
        // HELP FUNCTIONS

        //TEMP
        private string Add_UnsubscribeMessage_to_email()
        {
            //string o_retMessage = "<br/><br/>";

            //o_retMessage += " If you no longer wish to receive updates, you may <a href='http://" + System.Configuration.ConfigurationManager.AppSettings["WebsiteHostName"] + "/Public/Content/Contacts.aspx?Act=UNSB'>unsubscribe here</a>.";

            //return o_retMessage;

            //tmp
            return "";
        }
        //-----------------------------------------------------------------------------------------------------------------


        #endregion
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


    }
}
