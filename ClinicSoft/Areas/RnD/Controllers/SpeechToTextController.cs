using Google.Apis.Auth.OAuth2;
using Google.Cloud.Speech.V1;
using Grpc.Auth;
using Grpc.Core;
using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace ClinicSoft.Areas.RnD.Controllers
{
    public class SpeechToTextController : Controller
    {
        // GET: RnD/SpeechToText
        public ActionResult RnD_SpeechToText()
        {
            return View();
        }

        

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult SaveAudio()
        {
            ResponseOutput output = new ResponseOutput();

            if (Request.Files.Count > 0)
            {
                HttpFileCollectionBase files = Request.Files;
                HttpPostedFileBase file = files[0];

                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".wav";
                string filePath = Server.MapPath("~/Documents/recordings/");
                string publicPath = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "Documents/recordings/";

                if (!Directory.Exists(Path.Combine(filePath, DateTime.Now.ToString("yyyy"))))
                {
                    filePath = Path.Combine(filePath, DateTime.Now.ToString("yyyy"));
                    publicPath += "/" + DateTime.Now.ToString("yyyy");
                    Directory.CreateDirectory(filePath);
                }
                else
                {
                    filePath = Path.Combine(filePath, DateTime.Now.ToString("yyyy"));
                    publicPath += "/" + DateTime.Now.ToString("yyyy");
                }

                if (!Directory.Exists(Path.Combine(filePath, DateTime.Now.ToString("MMMM"))))
                {
                    filePath = Path.Combine(filePath, DateTime.Now.ToString("MMMM"));
                    publicPath += "/" + DateTime.Now.ToString("MMMM");
                    Directory.CreateDirectory(filePath);
                }
                else
                {
                    filePath = Path.Combine(filePath, DateTime.Now.ToString("MMMM"));
                    publicPath += "/" + DateTime.Now.ToString("MMMM");
                }

                if (!Directory.Exists(Path.Combine(filePath, DateTime.Now.ToString("dd"))))
                {
                    filePath = Path.Combine(filePath, DateTime.Now.ToString("dd"));
                    publicPath += "/" + DateTime.Now.ToString("dd");
                    Directory.CreateDirectory(filePath);
                }
                else
                {
                    filePath = Path.Combine(filePath, DateTime.Now.ToString("dd"));
                    publicPath += "/" + DateTime.Now.ToString("dd");
                }

                string _path = Path.Combine(filePath, fileName);
                if (System.IO.File.Exists(_path))
                {
                    System.IO.File.Delete(_path);
                }

                file.SaveAs(_path);

                

                if (System.IO.File.Exists(_path))
                {
                    output = SpeechToText(_path);

                    if (string.IsNullOrEmpty(output.error))
                    {
                        if (!string.IsNullOrEmpty(output.speechtext))
                        {
                            output.filename = fileName;
                            output.filepath = publicPath;
                            output.status = 200;
                            output.message = "Audio file saved successfully.";
                        }
                        else
                        {
                            output.filename = "";
                            output.filepath = "";
                            output.status = 201;
                            output.message = "Error in Speech to Text Convertion";
                        }
                    }
                    else
                    {
                        output.filename = "";
                        output.filepath = "";
                        output.status = 500;
                        output.message = output.error;
                    }
                }
                else
                {

                    output.filename = "";
                    output.filepath = "";
                    output.speechtext = "";
                    output.status = 503;
                    output.message = "Audio File is not saved";
                }
            }
            else
            {
                output.filename = "";
                output.filepath = "";
                output.speechtext = "";
                output.status = 404;
                output.message = "No audio file received.";
            }

            return Json(new { isConverted = true, isSuccess = true, data = output }, JsonRequestBehavior.AllowGet);
        }

        public ResponseOutput SpeechToText(string _path)
        {
            ResponseOutput output = new ResponseOutput();
            try
            {
                string audioFilePath = _path;
                string jsonKeyFilePath = Server.MapPath("~/data/speech_config.json");


                GoogleCredential credential = GoogleCredential.FromFile(jsonKeyFilePath);

                // Create a SpeechClient using the credentials
                var channelCredentials = credential.ToChannelCredentials();
                var channel = new Channel(SpeechClient.DefaultEndpoint.Host, channelCredentials);
                var speech = SpeechClient.Create(channel);

                // Create a RecognitionConfig
                RecognitionConfig config = new RecognitionConfig
                {
                    //Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                    //SampleRateHertz = 8000,
                    LanguageCode = LanguageCodes.English.UnitedStates,
                    //EnableWordTimeOffsets = true
                };

                // Create a RecognitionAudio
                RecognitionAudio audio = RecognitionAudio.FromFile(audioFilePath);


                // Perform the speech recognition
                RecognizeResponse response = speech.Recognize(config, audio);

                string alternative_val = string.Empty;
                //// Get the transcriptions
                foreach (SpeechRecognitionResult result in response.Results)
                {
                    foreach (SpeechRecognitionAlternative alternative in result.Alternatives)
                    {
                        alternative_val += alternative.Transcript;
                    }
                }

                output.error = string.Empty;
                output.speechtext = alternative_val;
            }
            catch (Exception ex)
            {
                output.error = ex.Message;
            }

            return output;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }


    }

    public class ResponseOutput
    {
        public int status { get; set; }
        public string message { get; set; }
        public string error { get; set; }
        public string filename { get; set; }
        public string filepath { get; set; }
        public string speechtext { get; set; }
    }
}