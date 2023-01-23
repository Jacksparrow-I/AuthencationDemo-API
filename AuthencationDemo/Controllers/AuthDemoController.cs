using AuthencationDemo.Interface;
using AuthencationDemo.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using static AuthencationDemo.Model.common;

namespace AuthencationDemo.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthDemoController : ControllerBase
    {
        readonly IConfiguration _configuration;
        private readonly IJWTManagerRepository _jWTManager;
        private readonly ILogger<AuthDemoController> _logger;

        #region Constructur
        //public AuthDemoController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        public AuthDemoController(IJWTManagerRepository jWTManager, IConfiguration configuration, ILogger<AuthDemoController> logger)
        {
            this._jWTManager = jWTManager;
            _configuration = configuration;
            _logger = logger;
        }

        #endregion

        string error = "somthing went wrong";
        [HttpGet]
        public List<string> Get()
        {
            var users = new List<string>
        {
            "Satinder Singh",
            "Amit Sarna",
            "Davin Jon"
        };

            return users;
        }


        [HttpGet("GetAllServiceRequest")]
        public List<Auth> GetAllServiceRequest()
        {
            try
            {
                _logger.LogInformation("Called GetAllServiceRequest");

                List<Auth> lstServiceRequest = new List<Auth>();
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("BlogDBConnection")))
                {
                    SqlCommand cmd = new SqlCommand("GetAllServiceRequest", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Auth ServiceRequest = new Auth();
                        ServiceRequest.ServiceRequestId = Convert.ToInt32(rdr["ServiceRequestId"]);
                        ServiceRequest.FirstName = rdr["FirstName"].ToString();
                        ServiceRequest.LastName = rdr["LastName"].ToString();
                        ServiceRequest.MobileNo = Convert.ToInt64(rdr["MobileNo"]);
                        ServiceRequest.Email = rdr["Email"].ToString();
                        ServiceRequest.EnquiryPurpose = rdr["EnquiryPurpose"].ToString();
                        ServiceRequest.Comments = rdr["Comments"].ToString();
                        lstServiceRequest.Add(ServiceRequest);
                    }
                    con.Close();

                }

                BaseResponse objBaseResponse = new BaseResponse();

                objBaseResponse.status = "Pass";
                objBaseResponse.statusCode = 200;
                objBaseResponse.responseContent = lstServiceRequest;

                AppLogger.ResponseAudit(objBaseResponse);

                return lstServiceRequest;
              

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("");
            }
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(Users usersdata)
        {
            var token = _jWTManager.Authenticate(usersdata);
            //var token = GetAllServiceRequest();

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }


    }
}
