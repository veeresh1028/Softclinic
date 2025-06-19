using Antlr.Runtime.Misc;
using BusinessEntities.EMR;
using BusinessEntities.MNR;
using Google.Type;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;



namespace ClinicSoft.MNR
{
    public class Nabidh
    {
        public static async Task<MNRAck> ADTA04(int appId, int pat_code, int patId, string app_fdate_time, int value)
        {
            MNRAck resultData = new MNRAck();
            if (pat_code > 0)
            {
                var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
                var msg_type = "ADTA04";
                var endPointUrl = baseAddress.BaseUrl + "?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=" + app_fdate_time + "&pat_code=" + pat_code;
                var client = new RestClient(baseAddress);
                var request = new RestRequest(endPointUrl, Method.Get);
                RestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    if (response.Content.Contains("Success"))
                    {
                        resultData = new MNRAck
                        {
                            value = value,
                            message = "Appointment Inserted Successfully and Data Sends to Nabidh"
                        };
                    }
                    else if (string.IsNullOrEmpty(response.Content))
                    {
                        resultData = new MNRAck
                        {
                            value = -2,
                            message = "Nabidh connectivity error ...check with EMR provider"
                        };

                    }
                    else
                    {
                        resultData = new MNRAck
                        {
                            value = value,
                            message = response.Content
                        };
                    }
                }
                else
                {
                    resultData = new MNRAck
                    {
                        value = -2,
                        message = "Error While Conecting Nabidh"
                    };

                }
            }
            else
            {
                resultData = new MNRAck
                {
                    value = -2,
                    message = "Invalid Patient Code"
                };



            }

            return resultData;
        }

        public static async Task<MNRAck> ADTA03(int appId, int pat_code, int patId, int value, string app_fdate)
        {
            MNRAck resultData = new MNRAck();
            if (pat_code > 0)
            {
                var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
                var msg_type = "ADTA03";
                var endPointUrl = baseAddress.BaseUrl + "?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=" + app_fdate + "&pat_code=" + pat_code;
                var client = new RestClient(baseAddress);
                var request = new RestRequest(endPointUrl, Method.Get);
                RestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    if (response.Content.Contains("Success"))
                    {
                        resultData = new MNRAck
                        {
                            value = value,
                            message = "Appointment Discharged Successfully and Data Sends to Nabidh"
                        };

                    }
                    else if (string.IsNullOrEmpty(response.Content))
                    {
                        resultData = new MNRAck
                        {
                            value = -2,
                            message = "Nabidh connectivity error ...check with EMR provider"
                        };



                    }
                    else
                    {
                        resultData = new MNRAck
                        {
                            value = value,
                            message = response.Content
                        };



                    }
                }
                else
                {
                    resultData = new MNRAck
                    {
                        value = -2,
                        message = "Error While Conecting Nabidh"
                    };


                }
            }
            else
            {
                resultData = new MNRAck
                {
                    value = -2,
                    message = "Invalid Patient Code"
                };



            }

            return resultData;
        }
        public static async Task<MNRAck> ADTA11(int appId, int pat_code, int patId, string app_fdate_time, int value)
        {
            MNRAck resultData = new MNRAck();
            if (pat_code > 0)
            {
                var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
                var msg_type = "ADTA11";
                var endPointUrl = baseAddress.BaseUrl + "?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=" + app_fdate_time + "&pat_code=" + pat_code;
                var client = new RestClient(baseAddress);
                var request = new RestRequest(endPointUrl, Method.Get);
                RestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    if (response.Content.Contains("Success"))
                    {
                        resultData = new MNRAck
                        {
                            value = value,
                            message = "Appointment Cancelled Successfully and Data Sends to Nabidh"
                        };




                    }
                    else if (string.IsNullOrEmpty(response.Content))
                    {
                        resultData = new MNRAck
                        {
                            value = -2,
                            message = "Nabidh connectivity error ...check with EMR provider"
                        };



                    }
                    else
                    {
                        resultData = new MNRAck
                        {
                            value = value,
                            message = response.Content
                        };



                    }
                }
                else
                {
                    resultData = new MNRAck
                    {
                        value = -2,
                        message = "Error While Conecting Nabidh"
                    };


                }
            }
            else
            {
                resultData = new MNRAck
                {
                    value = -2,
                    message = "Invalid Patient Code"
                };



            }

            return resultData;
        }

        public static async Task<MNRAck> ADTA08_1(int appId, int pat_code, int patId, string app_fdate_time, string set_permit_no, string Action)
        {
            MNRAck resultData = new MNRAck();

            var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
            var msg_type = "ADTA08_1";
            // var endPointUrl = "http://localhost:54793/api/HL7/RealTimeMessage?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=" + app_fdate_time + "&pat_code=" + pat_code;

            var endPointUrl = baseAddress.BaseUrl + "?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=" + app_fdate_time + "&pat_code=" + pat_code + "&set_permit_no=" + set_permit_no;
            var client = new RestClient(baseAddress);
            var request = new RestRequest(endPointUrl, Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                if (response.Content.Contains("Success"))
                {
                    resultData = new MNRAck
                    {
                        message = "Vitals " + Action + " Successfully and Data Sends to Nabidh"
                    };



                }
                else if (string.IsNullOrEmpty(response.Content))
                {
                    resultData = new MNRAck
                    {
                        value = -2,
                        message = "Nabidh connectivity error ...check with EMR provider"
                    };



                }
                else
                {
                    resultData = new MNRAck
                    {
                        message = response.Content
                    };



                }
            }
            else
            {
                resultData = new MNRAck
                {
                    message = "Error While Conecting Nabidh"
                };


            }

            return resultData;
        }

        public static async Task<MNRAck> ADTA08_4(int appId, int pat_code, int patId, string app_fdate_time, string set_permit_no, string Action)
        {
            MNRAck resultData = new MNRAck();

            var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
            var msg_type = "ADTA08_4";
            var endPointUrl = baseAddress.BaseUrl + "?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=" + app_fdate_time + "&pat_code=" + pat_code + "&set_permit_no=" + set_permit_no;
            var client = new RestClient(baseAddress);
            var request = new RestRequest(endPointUrl, Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                if (response.Content.Contains("Success"))
                {
                    resultData = new MNRAck
                    {
                        message = "Allergies " + Action + " Successfully and Data Sends to Nabidh"
                    };



                }
                else if (string.IsNullOrEmpty(response.Content))
                {
                    resultData = new MNRAck
                    {
                        value = -2,
                        message = "Nabidh connectivity error ...check with EMR provider"
                    };



                }
                else
                {
                    resultData = new MNRAck
                    {
                        message = response.Content
                    };



                }
            }
            else
            {
                resultData = new MNRAck
                {
                    message = "Error While Conecting Nabidh"
                };


            }

            return resultData;
        }
        public static async Task<MNRAck> ADTA08_2(int appId, int pat_code, int patId, string app_fdate_time, string Action)
        {
            MNRAck resultData = new MNRAck();

            var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
            var msg_type = "ADTA08_2";
            var endPointUrl = baseAddress.BaseUrl + "?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=" + app_fdate_time + "&pat_code=" + pat_code;
            var client = new RestClient(baseAddress);
            var request = new RestRequest(endPointUrl, Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                if (response.Content.Contains("Success"))
                {
                    resultData = new MNRAck
                    {
                        message = "Past Family History " + Action + " Successfully and Data Sends to Nabidh"
                    };



                }
                else if (string.IsNullOrEmpty(response.Content))
                {
                    resultData = new MNRAck
                    {
                        value = -2,
                        message = "Nabidh connectivity error ...check with EMR provider"
                    };



                }
                else
                {
                    resultData = new MNRAck
                    {
                        message = response.Content
                    };



                }
            }
            else
            {
                resultData = new MNRAck
                {
                    message = "Error While Conecting Nabidh"
                };


            }

            return resultData;
        }

        public static async Task<MNRAck> PPRPC1(int appId, int pat_code, int patId, string app_fdate_time, string Action)
        {
            MNRAck resultData = new MNRAck();

            var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
            var msg_type = "PPRPC1";
            var endPointUrl = baseAddress.BaseUrl + "?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=" + app_fdate_time + "&pat_code=" + pat_code;
            var client = new RestClient(baseAddress);
            var request = new RestRequest(endPointUrl, Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                if (response.Content.Contains("Success"))
                {
                    resultData = new MNRAck
                    {
                        message = "Chronic Problems " + Action + " Successfully and Data Sends to Nabidh"
                    };



                }
                else if (string.IsNullOrEmpty(response.Content))
                {
                    resultData = new MNRAck
                    {
                        value = -2,
                        message = "Nabidh connectivity error ...check with EMR provider"
                    };



                }
                else
                {
                    resultData = new MNRAck
                    {
                        message = response.Content
                    };



                }
            }
            else
            {
                resultData = new MNRAck
                {
                    message = "Error While Conecting Nabidh"
                };


            }

            return resultData;
        }

        public static async Task<MNRAck> ADTA08_3(int appId, int pat_code, int patId, string app_fdate_time, string Action)
        {
            MNRAck resultData = new MNRAck();

            var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
            var msg_type = "ADTA08_3";
            var endPointUrl = baseAddress.BaseUrl + "?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=" + app_fdate_time + "&pat_code=" + pat_code;
            var client = new RestClient(baseAddress);
            var request = new RestRequest(endPointUrl, Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                if (response.Content.Contains("Success"))
                {
                    resultData = new MNRAck
                    {
                        message = "Patient Diagnosis " + Action + " Successfully and Data Sends to Nabidh"
                    };



                }
                else if (string.IsNullOrEmpty(response.Content))
                {
                    resultData = new MNRAck
                    {
                        value = -2,
                        message = "Nabidh connectivity error ...check with EMR provider"
                    };



                }
                else
                {
                    resultData = new MNRAck
                    {
                        message = response.Content
                    };



                }
            }
            else
            {
                resultData = new MNRAck
                {
                    message = "Error While Conecting Nabidh"
                };


            }

            return resultData;
        }

        public static async Task<MNRAck> OMP009(int appId, int pat_code, int patId, string app_fdate_time, string Action)
        {
            MNRAck resultData = new MNRAck();

            var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
            var msg_type = "OMP009";
            var endPointUrl = baseAddress.BaseUrl + "?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=" + app_fdate_time + "&pat_code=" + pat_code;
            var client = new RestClient(baseAddress);
            var request = new RestRequest(endPointUrl, Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                if (response.Content.Contains("Success"))
                {
                    resultData = new MNRAck
                    {
                        message = "Prescription " + Action + " Successfully and Data Sends to Nabidh"
                    };
                }
                else if (string.IsNullOrEmpty(response.Content))
                {
                    resultData = new MNRAck
                    {
                        value = -2,
                        message = "Nabidh connectivity error ...check with EMR provider"
                    };



                }
                else
                {
                    resultData = new MNRAck
                    {
                        message = "Data Sends to Nabidh! Invalid Health Datas"
                    };
                }
            }
            else
            {
                resultData = new MNRAck
                {
                    message = "Error While Conecting Nabidh"
                };


            }

            return resultData;
        }

        public static async Task<MNRAck> ADTA08(int appId, int pat_code, int patId, string app_fdate_time, string Action)
        {
            MNRAck resultData = new MNRAck();

            var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
            var msg_type = "ADTA08";
            var endPointUrl = baseAddress.BaseUrl + "?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=" + app_fdate_time + "&pat_code=" + pat_code;
            var client = new RestClient(baseAddress);
            var request = new RestRequest(endPointUrl, Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                if (response.Content.Contains("Success"))
                {
                    resultData = new MNRAck
                    {
                        message = "Patient Treatments " + Action + " Successfully and Data Sends to Nabidh"
                    };



                }
                else if (string.IsNullOrEmpty(response.Content))
                {
                    resultData = new MNRAck
                    {
                        value = -2,
                        message = "Nabidh connectivity error ...check with EMR provider"
                    };



                }
                else
                {
                    resultData = new MNRAck
                    {
                        message = response.Content
                    };



                }
            }
            else
            {
                resultData = new MNRAck
                {
                    message = "Error While Conecting Nabidh"
                };


            }

            return resultData;
        }

        public static async Task<MNRAck> ADTA31(int appId, int pat_code, int patId, string app_fdate_time, int value)
        {
            MNRAck resultData = new MNRAck();
            if (pat_code > 0)
            {
                var url = ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString();
                var baseAddress = new RestClientOptions(url);
                var msg_type = "ADTA31";
                //var endPointUrl = "http://localhost:54793/api/HL7/RealTimeMessage?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=" + app_fdate_time + "&pat_code=" + pat_code;
                var endPointUrl = baseAddress.BaseUrl + "?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=" + app_fdate_time + "&pat_code=" + pat_code;

                var client = new RestClient(baseAddress);
                var request = new RestRequest(endPointUrl, Method.Get);
                RestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    if (response.Content.Contains("Success"))
                    {
                        resultData = new MNRAck
                        {
                            value = value,
                            message = "Updated Patient Details Successfully and Data Sends to NABIDH"
                        };
                    }
                    else if (response.Content.Contains("201"))
                    {
                        if (response.Content.Contains("Error"))
                            resultData = new MNRAck
                            {
                                value = -2,
                                message = "Updated Patient Details Successfully and Data Sends to NABIDH,But Please Check Some Value Invalid"
                            };
                    }
                    else if (string.IsNullOrEmpty(response.Content))
                    {
                        resultData = new MNRAck
                        {
                            value = -2,
                            message = "Nabidh connectivity error ...check with EMR provider"
                        };

                    }
                    else
                    {
                        resultData = new MNRAck
                        {
                            value = value,
                            message = response.Content
                        };



                    }
                }
                else
                {
                    resultData = new MNRAck
                    {
                        value = -2,
                        message = "Error While Conecting Nabidh"
                    };


                }
            }
            else
            {
                resultData = new MNRAck
                {
                    value = -2,
                    message = "Invalid Patient Code"
                };



            }

            return resultData;
        }

        public static async Task<MNRAck> ADTA40(int appId, int patId, int value)
        {
            MNRAck resultData = new MNRAck();

            var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
            var msg_type = "ADTA40";
            var endPointUrl = baseAddress.BaseUrl + "?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=&pat_code=";
            var client = new RestClient(baseAddress);
            var request = new RestRequest(endPointUrl, Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                if (response.Content.Contains("Success"))
                {
                    resultData = new MNRAck
                    {
                        value = value,
                        message = "Patient Details Merged Successfully and Data Sends to NABIDH"
                    };




                }
                else if (string.IsNullOrEmpty(response.Content))
                {
                    resultData = new MNRAck
                    {
                        value = -2,
                        message = "Nabidh connectivity error ...check with EMR provider"
                    };



                }
                else
                {
                    resultData = new MNRAck
                    {
                        value = value,
                        message = response.Content
                    };



                }
            }
            else
            {
                resultData = new MNRAck
                {
                    value = -2,
                    message = "Error While Conecting Nabidh"
                };


            }


            return resultData;
        }

        public static async Task<MNRAck> MDMT02(int appId, int pat_code, int patId, string app_fdate_time, int value)
        {
            MNRAck resultData = new MNRAck();
            if (pat_code > 0)
            {
                var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
                var msg_type = "MDMT02";
                //var endPointUrl = "http://localhost:54793/api/HL7/RealTimeMessage?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=" + app_fdate_time + "&pat_code=" + pat_code;

                var endPointUrl = baseAddress.BaseUrl + "?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=" + app_fdate_time + "&pat_code=" + pat_code;
                var client = new RestClient(baseAddress);
                var request = new RestRequest(endPointUrl, Method.Get);
                RestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    if (response.Content.Contains("Success"))
                    {
                        resultData = new MNRAck
                        {
                            value = value,
                            message = "Clinical Documents Sended Successfully and Data Send to Nabidh"
                        };
                    }
                    else if (string.IsNullOrEmpty(response.Content))
                    {
                        resultData = new MNRAck
                        {
                            value = -2,
                            message = "Nabidh connectivity error ...check with EMR provider"
                        };
                    }
                    else
                    {
                        resultData = new MNRAck
                        {
                            value = value,
                            message = response.Content
                        };



                    }
                }
                else
                {
                    resultData = new MNRAck
                    {
                        value = -2,
                        message = "Error While Conecting Nabidh"
                    };


                }
            }
            else
            {
                resultData = new MNRAck
                {
                    value = -2,
                    message = "Invalid Patient Code"
                };



            }

            return resultData;
        }

        public static async Task<MNRAck> ORUR01_1(int appId, int pat_code, int patId, string app_fdate_time, int value)
        {
            MNRAck resultData = new MNRAck();
            if (pat_code > 0)
            {
                var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
                var msg_type = "ORUR01_1";
                var endPointUrl = baseAddress.BaseUrl + "?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=" + app_fdate_time + "&pat_code=" + pat_code;

                var client = new RestClient(baseAddress);
                var request = new RestRequest(endPointUrl, Method.Get);
                RestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    if (response.Content.Contains("Success"))
                    {
                        resultData = new MNRAck
                        {
                            value = value,
                            message = "Clinical Documents Sended Successfully and Data Send to Nabidh"
                        };




                    }
                    else if (string.IsNullOrEmpty(response.Content))
                    {
                        resultData = new MNRAck
                        {
                            value = -2,
                            message = "Nabidh connectivity error ...check with EMR provider"
                        };



                    }
                    else
                    {
                        resultData = new MNRAck
                        {
                            value = value,
                            message = response.Content
                        };



                    }
                }
                else
                {
                    resultData = new MNRAck
                    {
                        value = -2,
                        message = "Error While Conecting Nabidh"
                    };


                }
            }
            else
            {
                resultData = new MNRAck
                {
                    value = -2,
                    message = "Invalid Patient Code"
                };



            }

            return resultData;
        }

        public static async Task<MNRAck> ORUR01_2(int appId, int pat_code, int patId, string app_fdate_time, int value)
        {
            MNRAck resultData = new MNRAck();
            if (pat_code > 0)
            {
                var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
                var msg_type = "ORUR01_2";
                var endPointUrl = baseAddress.BaseUrl + "?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=" + app_fdate_time + "&pat_code=" + pat_code;
                var client = new RestClient(baseAddress);
                var request = new RestRequest(endPointUrl, Method.Get);
                RestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    if (response.Content.Contains("Success"))
                    {
                        resultData = new MNRAck
                        {
                            value = value,
                            message = "Clinical Documents Sended Successfully and Data Send to Nabidh"
                        };




                    }
                    else if (string.IsNullOrEmpty(response.Content))
                    {
                        resultData = new MNRAck
                        {
                            value = -2,
                            message = "Nabidh connectivity error ...check with EMR provider"
                        };



                    }
                    else
                    {
                        resultData = new MNRAck
                        {
                            value = value,
                            message = response.Content
                        };



                    }
                }
                else
                {
                    resultData = new MNRAck
                    {
                        value = -2,
                        message = "Error While Conecting Nabidh"
                    };


                }
            }
            else
            {
                resultData = new MNRAck
                {
                    value = -2,
                    message = "Invalid Patient Code"
                };



            }

            return resultData;
        }


        public static async Task<MNRAck> ORUR01_3(int appId, int pat_code, int patId, string app_fdate_time, int value)
        {
            MNRAck resultData = new MNRAck();
            if (pat_code > 0)
            {
                var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
                var msg_type = "ORUR01_3";
                var endPointUrl = baseAddress.BaseUrl + "?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=" + app_fdate_time + "&pat_code=" + pat_code;

                var client = new RestClient(baseAddress);
                var request = new RestRequest(endPointUrl, Method.Get);
                RestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    if (response.Content.Contains("Success"))
                    {
                        resultData = new MNRAck
                        {
                            value = value,
                            message = "Clinical Documents Sended Successfully and Data Send to Nabidh"
                        };
                    }
                    else if (string.IsNullOrEmpty(response.Content))
                    {
                        resultData = new MNRAck
                        {
                            value = -2,
                            message = "Nabidh connectivity error ...check with EMR provider"
                        };
                    }
                    else
                    {
                        resultData = new MNRAck
                        {
                            value = value,
                            message = response.Content
                        };
                    }
                }
                else
                {
                    resultData = new MNRAck
                    {
                        value = -2,
                        message = "Error While Conecting Nabidh"
                    };
                }
            }
            else
            {
                resultData = new MNRAck
                {
                    value = -2,
                    message = "Invalid Patient Code"
                };
            }

            return resultData;
        }
        //public static async Task<MNRAck> ADTA04(int appId,int pat_code,int patId,int value)
        //{
        //    MNRAck resultData = new MNRAck();
        //    if (pat_code > 0)
        //    {
        //        var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
        //        var msg_type = "ADTA04";
        //        var endPointUrl = baseAddress + "?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=&pat_code=" + pat_code;
        //        var client = new RestClient(baseAddress);
        //        var request = new RestRequest(endPointUrl, Method.Get);
        //        RestResponse response = await client.ExecuteAsync(request);

        //        if (response.IsSuccessful)
        //        {
        //            if (response.Content.Contains("MSA|AA|"))
        //            {
        //                resultData = new MNRAck
        //                {
        //                    value = value,
        //                    message = "Appointment Inserted Successfully and Data Sends to Nabidh" 
        //                };




        //            }
        //            else if (string.IsNullOrEmpty(response.Content))
        //            {
        //                resultData = new MNRAck
        //                {
        //                     value = -2,
        //                    message = "Nabidh connectivity error ...check with EMR provider"
        //                };



        //            }
        //            else
        //            {
        //                resultData = new MNRAck
        //                {
        //                    value = value,
        //                    message = response.Content
        //                };



        //            }
        //        }
        //        else
        //        {
        //             resultData = new MNRAck
        //            {
        //                 value = -2,
        //                message = "Error While Conecting Nabidh"
        //            };


        //        }
        //    }
        //    else
        //    {
        //         resultData = new MNRAck
        //        {
        //             value = -2,
        //            message = "Invalid Patient Code"
        //        };



        //    }

        //    return resultData;
        //}


    }
  
    
}