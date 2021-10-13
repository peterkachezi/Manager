using Manager.Data.DTOs.InstituitonModule;
using Manager.Data.Services.InstituitonModule;
using Microsoft.AspNet.Identity;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Manager.Areas.Administrator.Controllers
{
    public class InstituitonController : Controller
    {
        private readonly IInstituitonService instituitonService;

        public InstituitonController(IInstituitonService instituitonService)
        {
            this.instituitonService = instituitonService;

        }
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]

        public ActionResult UploadImage(InstituitonDTO file)

        {

            try

            {

                Byte[] bytes = null;

                if (file.Image.FileName != null)

                {
                    Stream fs = file.Image.InputStream;

                    BinaryReader br = new BinaryReader(fs);

                    bytes = br.ReadBytes((Int32)fs.Length);

                    string connectionstring = Convert.ToString(ConfigurationManager.ConnectionStrings["dbconnection"]);

                    SqlConnection con = new SqlConnection(connectionstring);

                    SqlCommand cmd = new SqlCommand("Insert into fileUpload(FileNames,Filepic,UploadDate) values(@FileNames,@Filepic,@UploadDate)", con)
                    {
                        CommandType = CommandType.Text
                    };

                    cmd.Parameters.AddWithValue("@FileNames", file.Name);

                    cmd.Parameters.AddWithValue("@Filepic", bytes);

                    cmd.Parameters.AddWithValue("@UploadDate", DateTime.Now);

                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();

                    ViewBag.Image = ViewImage(bytes);

                }

            }

            catch (Exception ex)

            {

                Console.WriteLine(ex.Message);

                return null;

            }

            return View();

        }

        private string ViewImage(byte[] arrayImage)

        {

            string base64String = Convert.ToBase64String(arrayImage, 0, arrayImage.Length);

            return "data:image/png;base64," + base64String;

        }


        public async Task<ActionResult> Create(InstituitonDTO instituitonDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                instituitonDTO.CreatedById = user;

                Byte[] bytes = null;

                if (instituitonDTO.Image.FileName != null)

                {
                    Stream fs = instituitonDTO.Image.InputStream;

                    BinaryReader br = new BinaryReader(fs);

                    bytes = br.ReadBytes((Int32)fs.Length);

                }

                instituitonDTO.Image1 = bytes;


                var results = await instituitonService.Create(instituitonDTO);

                if (results == true)
                {
                    return Json(new { success = true, responseText = "Record has been successfully saved" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "Unable to update record report details", JsonRequestBehavior.AllowGet });
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<ActionResult> Update(InstituitonDTO instituitonDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();


                var results = await instituitonService.Update(instituitonDTO);

                if (results == true)
                {
                    return Json(new { success = true, responseText = "Record has been updated successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "Unable to update record report details", JsonRequestBehavior.AllowGet });
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<ActionResult> GetById(Guid Id)
        {
            try
            {
                var data = await instituitonService.GetById(Id);

                if (data != null)
                {
                    InstituitonDTO file = new InstituitonDTO()
                    {
                        Id = data.Id,

                        Name = data.Name,

                        Email = data.Email,

                        PhoneNumber = data.PhoneNumber,

                        PostalAddrress = data.PostalAddrress,

                        PostalCode = data.PostalCode,

                        CreateDate = data.CreateDate,

                        CreatedById = data.CreatedById,

                        CreatedByName = data.CreatedByName,
                    };

                    return Json(new { data = file }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { data = false }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }

        }



    }
}