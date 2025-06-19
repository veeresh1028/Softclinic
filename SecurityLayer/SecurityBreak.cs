using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace SecurityLayer
{
    public class SecurityBreak
    {
        public static SecurityResponse CheckLicense()
        {
            SecurityResponse _response = new SecurityResponse();

            try
            {
                if (ConfigurationManager.AppSettings["ConfigMethod"] != null)
                {
                    if (ConfigurationManager.AppSettings["ConfigMethod"].ToString().Equals("Offline"))
                    {
                        string[] lines = System.IO.File.ReadAllLines(@ConfigurationManager.AppSettings["ConfigPath"]);
                        string product_key = lines[0];
                        string act_date = lines[1];
                        string exp_date = lines[2];
                        string dis_date = lines[3];
                        string ex_days = lines[4];
                        string max_user = lines[5];
                        string proId = lines[6];
                        string cusId = lines[7];
                        string product_code = lines[8];

                        if (product_key.Equals(@ConfigurationManager.AppSettings["ProductKey"].ToString()))
                        {
                            string _productkey = Encryptions.Decrypt(Encryptions.GetHashKey("VISION LICENSE"), product_key);
                            string _product_code = string.Empty;
                            int _product_id = 0;
                            int _product_company = 0;

                            string[] _keys = _productkey.Split('|');

                            if (_keys.Length == 3)
                            {
                                _product_code = _keys[0].ToString().Trim();
                                _product_id = int.Parse(_keys[1].ToString().Trim());
                                _product_company = int.Parse(_keys[2].ToString().Trim());

                                if (!string.IsNullOrEmpty(_productkey) && !string.IsNullOrEmpty(_product_code) && _product_id > 0 && _product_company > 0)
                                {
                                    if (_product_code.Equals(Encryptions.Decrypt(Encryptions.GetHashKey("VISION LICENSE"), product_code)) &&
                                        _product_id == int.Parse(Encryptions.Decrypt(Encryptions.GetHashKey("VISION LICENSE"), proId)) &&
                                        _product_company == int.Parse(Encryptions.Decrypt(Encryptions.GetHashKey("VISION LICENSE"), cusId)))
                                    {
                                        DateTime _actDate = DateTime.Parse("1900-01-01");
                                        DateTime.TryParse(Encryptions.Decrypt(Encryptions.GetHashKey("VISION LICENSE"), act_date), out _actDate);
                                        DateTime _expDate = DateTime.Parse("1900-01-01");
                                        DateTime.TryParse(Encryptions.Decrypt(Encryptions.GetHashKey("VISION LICENSE"), exp_date), out _expDate);
                                        DateTime _dis_date = DateTime.Parse("1900-01-01");
                                        DateTime.TryParse(Encryptions.Decrypt(Encryptions.GetHashKey("VISION LICENSE"), dis_date), out _dis_date);

                                        _response = CheckActivation(_expDate, _dis_date);
                                    }
                                    else
                                    {
                                        _response.Status = "Error";
                                        _response.StatusCode = 500;
                                        _response.ProductStatus = "Error";
                                        _response.ErrorMessage = "";
                                        _response.DisplayMessage = "License Validation Error! Please contact Vision Technologies...";
                                    }
                                }
                                else
                                {
                                    _response.Status = "Error";
                                    _response.StatusCode = 500;
                                    _response.ProductStatus = "Error";
                                    _response.ErrorMessage = "";
                                    _response.DisplayMessage = "License Validation Error! Please contact Vision Technologies...";
                                }
                            }
                            else
                            {
                                _response.Status = "Error";
                                _response.StatusCode = 500;
                                _response.ProductStatus = "Error";
                                _response.ErrorMessage = "";
                                _response.DisplayMessage = "Export License Validation Error! Please contact Vision Technologies...";
                            }
                        }
                        else
                        {
                            _response.Status = "Error";
                            _response.StatusCode = 500;
                            _response.ProductStatus = "Error";
                            _response.ErrorMessage = "";
                            _response.DisplayMessage = "Invalid Product Key! Please contact Vision Technologies.";
                        }
                    }
                    else if (ConfigurationManager.AppSettings["ConfigMethod"].ToString().Equals("Online"))
                    {
                        using (var client = new HttpClient())
                        {
                            client.DefaultRequestHeaders.Add("ProductKey", @ConfigurationManager.AppSettings["ProductKey"]);
                            var response = client.GetAsync(@ConfigurationManager.AppSettings["ConfigPath"]).GetAwaiter().GetResult();
                            if (response.IsSuccessStatusCode)
                            {
                                var responseContent = response.Content;
                                string data = responseContent.ReadAsStringAsync().GetAwaiter().GetResult();

                                JavaScriptSerializer js = new JavaScriptSerializer();
                                _response = js.Deserialize<SecurityResponse>(data);
                            }
                        }
                    }
                }

                return _response;
            }
            catch (Exception ex)
            {
                _response.Status = "Error";
                _response.StatusCode = 500;
                _response.ProductStatus = "Error";
                _response.ErrorMessage = ex.Message;
                _response.DisplayMessage = ex.Message;

                return _response;
            }

        }

        private static SecurityResponse CheckActivation(DateTime _expDate, DateTime _forDate)
        {
            SecurityResponse response = new SecurityResponse();

            try
            {
                if (_forDate.Date == DateTime.Today.Date)
                {
                    response.StatusCode = 200;
                    response.Status = "Forbidden";
                    response.ProductStatus = "Stopped Today";
                    response.ErrorMessage = "";
                    response.DisplayMessage = "Dear Customer, Your License was Expired and your Service will be discontinued as of today. Please contact Vision Technologies to renew your license!";
                }
                else
                {
                    if (_forDate.Date < DateTime.Today.Date)
                    {

                        response.StatusCode = 403;
                        response.Status = "Forbidden";
                        response.ProductStatus = "Stopped";
                        response.ErrorMessage = "";
                        response.DisplayMessage = "Dear Customer, Your Service has been expired including your extension period. Please contact Vision Technologies to resume your service.";
                    }
                    else
                    {
                        double _dayCount = (_expDate.Date - DateTime.Today.Date).TotalDays;

                        if (_dayCount > 0)
                        {
                            if ((_expDate.Date - DateTime.Today.Date).TotalDays <= 14)
                            {
                                response.StatusCode = 200;
                                response.Status = "Forbidden";
                                response.ProductStatus = "Expiration in Two Weeks";
                                response.ErrorMessage = "";
                                response.DisplayMessage = "Dear Customer, Your License will expire in " + _dayCount + " Days. Please renew your license before " + _expDate.Date.ToLongDateString() + " to avoid service discontinuation!";
                            }
                            else if ((_expDate.Date - DateTime.Today.Date).TotalDays <= 7)
                            {
                                response.StatusCode = 200;
                                response.Status = "Forbidden";
                                response.ProductStatus = "Expiration in This week";
                                response.ErrorMessage = "";
                                response.DisplayMessage = "Dear Customer, Your License will expire in " + _dayCount + "Days. Please renew your license before " + _expDate.Date.ToLongDateString() + " to avoid the service discontinuation!";
                            }
                            else if (_expDate.Date == DateTime.Today.Date)
                            {
                                response.StatusCode = 200;
                                response.Status = "Forbidden";
                                response.ProductStatus = "Expiry Today";
                                response.ErrorMessage = "";
                                response.DisplayMessage = "Dear Customer, Your License is Expiring today. Please contact Vision Technologies to renew your license!";
                            }
                            else
                            {
                                response.StatusCode = 200;
                                response.Status = "Success";
                                response.ProductStatus = "Active";
                                response.ErrorMessage = "";
                                response.DisplayMessage = "";
                            }
                        }
                        else
                        {
                            response.StatusCode = 200;
                            response.Status = "Forbidden";
                            response.ProductStatus = "Extension Period";
                            response.ErrorMessage = "";
                            response.DisplayMessage = "Dear Customer, Your License was Expired " + (_dayCount * (-1)) + " day(s) ago, and your extenision period is going on. Your Service will be automatically discontinued on " + _forDate.Date.ToLongDateString() + ". Please contact Vision Technologies to renew your license now!";
                        }
                    }
                }

                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = 417;
                response.Status = "ExceptionFailed";
                response.ProductStatus = "";
                response.ErrorMessage = ex.Message;
                response.DisplayMessage = "";

                return response;
            }
        }
    }
}
