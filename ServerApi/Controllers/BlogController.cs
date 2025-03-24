using Microsoft.AspNetCore.Mvc;
using ServerApi.Services;
using ServerApi.Data;
using ServerApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace ServerApi.Controllers
{
    [Route("[controller]")]

    public class BlogController : Controller
    {
        private readonly MyDbContext _dbContext;
        private readonly IBlogService _iBlogService;

        public BlogController(MyDbContext dbContext, IBlogService blogService)
        {
            _dbContext = dbContext;
            _iBlogService = blogService;

        }
        [HttpGet("GetPost")]
        public IActionResult GetPost()
        {
            return Ok(_iBlogService.GetBlogs());
        }
        [HttpPost("Subscribe")]
        public IActionResult Subscribe([FromBody] Subscriber subscriberData)
        {
            return Ok(_iBlogService.InsertSubscribe(subscriberData));
        }


        //EMP Store Procedure

        private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=BLOG;TrustServerCertificate=True;Trusted_Connection=True;";
        [HttpGet("GetEmployeePayments")]
        public IActionResult GetEmployeePayments()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_ManageEmployeePayments", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "READ");

                    // ✅ Fix: Always add @TaxPay as an OUTPUT parameter
                    SqlParameter taxOutput = new SqlParameter("@TaxPay", SqlDbType.Decimal)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(taxOutput);

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    var employees = new List<EmployeePayment>();
                    foreach (DataRow row in dt.Rows)
                    {
                        employees.Add(new EmployeePayment
                        {
                            ID = Convert.ToInt32(row["ID"]),
                            Name = row["Name"].ToString(),
                            StaffID = row["StaffID"] != DBNull.Value ? row["StaffID"].ToString() : null,
                            Department = row["Department"].ToString(),
                            PaymentDate = Convert.ToDateTime(row["PaymentDate"]),
                            BasicPay = Convert.ToDecimal(row["BasicPay"]),
                            HRA = Convert.ToDecimal(row["HRA"]),
                            Others = Convert.ToDecimal(row["Others"]),
                            TotalEarnings = Convert.ToDecimal(row["TotalEarnings"]),
                            TaxPay = Convert.ToDecimal(row["TaxPay"]),
                            NetPay = Convert.ToDecimal(row["NetPay"])
                        });
                    }

                    return Ok(employees);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        //Insert Code SP

        [HttpPost("CreateEmployee")]
        public IActionResult CreateEmployee([FromBody] EmployeePayment employee)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ManageEmployeePayments", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "CREATE");
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@StaffID", (object)employee.StaffID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@PaymentDate", employee.PaymentDate);
                cmd.Parameters.AddWithValue("@BasicPay", Convert.ToDecimal(employee.BasicPay));
                cmd.Parameters.AddWithValue("@HRA", Convert.ToDecimal(employee.HRA));
                cmd.Parameters.AddWithValue("@Others", Convert.ToDecimal(employee.Others));

                SqlParameter taxOutput = new SqlParameter("@TaxPay", SqlDbType.Decimal)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(taxOutput);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();  // ✅ Capture the affected rows
                con.Close();

                employee.TaxPay = (decimal)(taxOutput.Value ?? 0);

                if (rowsAffected > 0)
                    return Ok(new { message = "Inserted Successfully", employee });

                return BadRequest("Insert failed: No rows were affected.");
            }
        }

        //Delete SP

        [HttpDelete("DeleteEmployee")]
        public IActionResult DeleteEmployee(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ManageEmployeePayments", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "DELETE");
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return Ok(new { message = "Deleted Successfully" });
        }
    }
}