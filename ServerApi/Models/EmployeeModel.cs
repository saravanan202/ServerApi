public class EmployeePayment
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string? StaffID { get; set; }
    public string Department { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal BasicPay { get; set; }
    public decimal HRA { get; set; }
    public decimal Others { get; set; }
    public decimal TotalEarnings { get; set; }
    public decimal TaxPay { get; set; }
    public decimal NetPay { get; set; }
}