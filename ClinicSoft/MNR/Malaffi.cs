using BusinessEntities.MNR;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ClinicSoft.MNR
{
    public class Malaffi
    {
        public static async Task<MNRAck> SIUS12(int appId, int pat_code, int patId, int value)
        {
            MNRAck resultData = new MNRAck();
            if (pat_code > 0)
            {
                var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
                var msg_type = "SIUS12";
                var endPointUrl = baseAddress + "?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=&pat_code=" + pat_code;
                var client = new RestClient(baseAddress);
                var request = new RestRequest(endPointUrl, Method.Get);
                RestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    if (response.Content.Contains("MSA|AA|"))
                    {
                        resultData = new MNRAck
                        {
                            value = value,
                            message = "Appointment Booked Successfully and Data Sends to Malaffi"
                        };




                    }
                    else if (string.IsNullOrEmpty(response.Content))
                    {
                        resultData = new MNRAck
                        {
                            value = -2,
                            message = "Malaffi connectivity error ...check with EMR provider"
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
                        message = "Error While Conecting Malaffi"
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

        public static async Task<MNRAck> ADTA04(int appId, int pat_code, int patId, int value)
        {
            MNRAck resultData = new MNRAck();
            if (pat_code > 0)
            {
                var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
                var msg_type = "ADTA04";
                var endPointUrl = baseAddress + "?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=&pat_code=" + pat_code;
                var client = new RestClient(baseAddress);
                var request = new RestRequest(endPointUrl, Method.Get);
                RestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    if (response.Content.Contains("MSA|AA|"))
                    {
                        resultData = new MNRAck
                        {
                            value = value,
                            message = "Appointment Inserted Successfully and Data Sends to Malaffi"
                        };




                    }
                    else if (string.IsNullOrEmpty(response.Content))
                    {
                        resultData = new MNRAck
                        {
                            value = -2,
                            message = "Malaffi connectivity error ...check with EMR provider"
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
                        message = "Error While Conecting Malaffi"
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

        public static async Task<MNRAck> SIUS15(int appId, int pat_code, int patId, int value)
        {
            MNRAck resultData = new MNRAck();
            if (pat_code > 0)
            {
                var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
                var msg_type = "SIUS15";
                var endPointUrl = baseAddress + "?appId=" + appId.ToString() + "&patid=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=&pat_code=";
                var client = new RestClient(baseAddress);
                var request = new RestRequest(endPointUrl, Method.Get);
                RestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    if (response.Content.Contains("MSA|AA|"))
                    {
                        resultData = new MNRAck
                        {
                            value = value,
                            message = "Appointment Cancelled Successfully and Data Sends to Malaffi"
                        };




                    }
                    else if (string.IsNullOrEmpty(response.Content))
                    {
                        resultData = new MNRAck
                        {
                            value = -2,
                            message = "Malaffi connectivity error ...check with EMR provider"
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
                        message = "Error While Conecting Malaffi"
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

        public static async Task<MNRAck> SIUS17(int appId, int pat_code, int patId, int value)
        {
            MNRAck resultData = new MNRAck();
            if (pat_code > 0)
            {
                var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
                var msg_type = "SIUS17";
                var endPointUrl = baseAddress + "?appId=" + appId.ToString() + "&patid=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=&pat_code=";
                var client = new RestClient(baseAddress);
                var request = new RestRequest(endPointUrl, Method.Get);
                RestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    if (response.Content.Contains("MSA|AA|"))
                    {
                        resultData = new MNRAck
                        {
                            value = value,
                            message = "Appointment Deleted Successfully and Data Sends to Malaffi"
                        };




                    }
                    else if (string.IsNullOrEmpty(response.Content))
                    {
                        resultData = new MNRAck
                        {
                            value = -2,
                            message = "Malaffi connectivity error ...check with EMR provider"
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
                        message = "Error While Conecting Malaffi"
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

        public static async Task<MNRAck> SIUS26(int appId, int pat_code, int patId, int value)
        {
            MNRAck resultData = new MNRAck();
            if (pat_code > 0)
            {
                var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
                var msg_type = "SIUS26";
                var endPointUrl = baseAddress + "?appId=" + appId.ToString() + "&patid=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=&pat_code=";
                var client = new RestClient(baseAddress);
                var request = new RestRequest(endPointUrl, Method.Get);
                RestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    if (response.Content.Contains("MSA|AA|"))
                    {
                        resultData = new MNRAck
                        {
                            value = value,
                            message = "Appointment Deleted Successfully and Data Sends to Malaffi"
                        };




                    }
                    else if (string.IsNullOrEmpty(response.Content))
                    {
                        resultData = new MNRAck
                        {
                            value = -2,
                            message = "Malaffi connectivity error ...check with EMR provider"
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
                        message = "Error While Conecting Malaffi"
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
        public static async Task<MNRAck> SIUS13(int appId, int pat_code, int patId, int value)
        {
            MNRAck resultData = new MNRAck();
            if (pat_code > 0)
            {
                var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
                var msg_type = "SIUS13";
                var endPointUrl = baseAddress + "?appId=" + appId.ToString() + "&patid=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=&pat_code=";
                var client = new RestClient(baseAddress);
                var request = new RestRequest(endPointUrl, Method.Get);
                RestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    if (response.Content.Contains("MSA|AA|"))
                    {
                        resultData = new MNRAck
                        {
                            value = value,
                            message = "Appointment Deleted Successfully and Data Sends to Malaffi"
                        };




                    }
                    else if (string.IsNullOrEmpty(response.Content))
                    {
                        resultData = new MNRAck
                        {
                            value = -2,
                            message = "Malaffi connectivity error ...check with EMR provider"
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
                        message = "Error While Conecting Malaffi"
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

        public static async Task<MNRAck> ORUR01(int appId, int pat_code, int patId, string app_fdate_time, string set_permit_no, string Action)
        {
            MNRAck resultData = new MNRAck();

            var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
            var msg_type = "ORUR01";
            var endPointUrl = baseAddress + "?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=" + app_fdate_time + "&pat_code=" + pat_code + "&set_permit_no=" + set_permit_no;
            var client = new RestClient(baseAddress);
            var request = new RestRequest(endPointUrl, Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                if (response.Content.Contains("MSA|AA|"))
                {
                    resultData = new MNRAck
                    {
                        message = "Vitals " + Action + " Successfully and Data Sends to Riayati"
                    };

                }
                else if (string.IsNullOrEmpty(response.Content))
                {
                    resultData = new MNRAck
                    {
                        value = -2,
                        message = "Riayati connectivity error ...check with EMR provider"
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
                    message = "Error While Conecting Riayati"
                };


            }

            return resultData;
        }
        public static async Task<MNRAck> ADTA31(int appId, int pat_code, int patId, string app_fdate_time, string set_permit_no, string Action)
        {
            MNRAck resultData = new MNRAck();

            var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
            var msg_type = "ADTA31";
            var endPointUrl = baseAddress + "?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=" + app_fdate_time + "&pat_code=" + pat_code + "&set_permit_no=" + set_permit_no;
            var client = new RestClient(baseAddress);
            var request = new RestRequest(endPointUrl, Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                if (response.Content.Contains("MSA|AA|"))
                {
                    resultData = new MNRAck
                    {
                        message = "Allergies " + Action + " Successfully and Data Sends to Riayati"
                    };

                }
                else if (string.IsNullOrEmpty(response.Content))
                {
                    resultData = new MNRAck
                    {
                        value = -2,
                        message = "Riayati connectivity error ...check with EMR provider"
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
                    message = "Error While Conecting Riayati"
                };


            }

            return resultData;
        }
        public static async Task<MNRAck> ADTA08(int appId, int pat_code, int patId, string app_fdate_time,  string Action)
        {
            MNRAck resultData = new MNRAck();

            var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
            var msg_type = "ADTA08";
            var endPointUrl = baseAddress + "?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=" + app_fdate_time + "&pat_code=" + pat_code ;
            var client = new RestClient(baseAddress);
            var request = new RestRequest(endPointUrl, Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                if (response.Content.Contains("MSA|AA|"))
                {
                    resultData = new MNRAck
                    {
                        message = "Patient Diagnosis " + Action + " Successfully and Data Sends to Riayati"
                    };

                }
                else if (string.IsNullOrEmpty(response.Content))
                {
                    resultData = new MNRAck
                    {
                        value = -2,
                        message = "Riayati connectivity error ...check with EMR provider"
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
                    message = "Error While Conecting Riayati"
                };


            }

            return resultData;
        }
        public static async Task<MNRAck> OMP009(int appId, int pat_code, int patId, string app_fdate_time, string Action)
        {
            MNRAck resultData = new MNRAck();

            var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
            var msg_type = "OMP009";
            var endPointUrl = baseAddress + "?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=" + app_fdate_time + "&pat_code=" + pat_code ;
            var client = new RestClient(baseAddress);
            var request = new RestRequest(endPointUrl, Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                if (response.Content.Contains("MSA|AA|"))
                {
                    resultData = new MNRAck
                    {
                        message = "Prescription " + Action + " Successfully and Data Sends to Riayati"
                    };

                }
                else if (string.IsNullOrEmpty(response.Content))
                {
                    resultData = new MNRAck
                    {
                        value = -2,
                        message = "Riayati connectivity error ...check with EMR provider"
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
                    message = "Error While Conecting Riayati"
                };


            }

            return resultData;
        }

        public static async Task<MNRAck> ADTA03(int appId, int pat_code, int patId, string app_fdate_time, string Action)
        {
            MNRAck resultData = new MNRAck();

            var baseAddress = new RestClientOptions(ConfigurationManager.AppSettings["HL7EndPoint"].ToString() + ConfigurationManager.AppSettings["HL7Action"].ToString());
            var msg_type = "ADTA03";
            var endPointUrl = baseAddress + "?appId=" + appId.ToString() + "&patId=" + patId.ToString() + "&msg_type=" + msg_type + "&app_fdate=" + app_fdate_time + "&pat_code=" + pat_code;
            var client = new RestClient(baseAddress);
            var request = new RestRequest(endPointUrl, Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                if (response.Content.Contains("MSA|AA|"))
                {
                    resultData = new MNRAck
                    {
                        message = "Patient Treatments " + Action + " Successfully and Data Sends to Riayati"
                    };

                }
                else if (string.IsNullOrEmpty(response.Content))
                {
                    resultData = new MNRAck
                    {
                        value = -2,
                        message = "Riayati connectivity error ...check with EMR provider"
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
                    message = "Error While Conecting Riayati"
                };


            }

            return resultData;
        }
    }
}