using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace Lab5.Models
{
    public class Lab6Model
    {
        public class CallCenter
        {
            public int CallCenter_Id { get; set; }
            public string CallCenterAddress { get; set; }
            public string CallCenterOtherDetails { get; set; }
        }

        public class CommonProblem
        {
            public int Problem_Id { get; set; }
            public string ProblemDescription { get; set; }
            public string OtherProblemDetails { get; set; }
        }

        public class CommonSolution
        {
            public int Solution_Id { get; set; }
            public string SolutionDescription { get; set; }
            public string OtherSolutionDetails { get; set; }
        }

        public class Customer
        {
            public int Customer_Id { get; set; }
            public string CustomerAddressLine1 { get; set; }
            public string CustomerAddressLine2 { get; set; }
            public string CustomerAddressLine3 { get; set; }
            public string TownCity { get; set; }
            public string State { get; set; }
            public string EmailAddress { get; set; }
            public string PhoneNumber { get; set; }
            public string CustomerOtherDetails { get; set; }
        }

        public class Contract
        {
            public int Contract_Id { get; set; }
            public int Customer_Id { get; set; }
            public DateTime ContractStartDate { get; set; }
            public DateTime ContractEndDate { get; set; }
            public string OtherDetails { get; set; }
            public Customer Customer { get; set; }
        }

        public class RefCallOutcome
        {
            public int CallOutcomeCode { get; set; }
            public string CallOutcomeDescription { get; set; }
            public string OtherCallOutcomeDetails { get; set; }
        }

        public class RefCallStatusCode
        {
            public int CallStatusCode { get; set; }
            public string CallStatusDescription { get; set; }
            public string CallStatusComments { get; set; }
        }

        public class SolutionsForCommonProblem
        {
            public int Problem_Id { get; set; }
            public int Solution_Id { get; set; }
            public CommonProblem CommonProblem { get; set; }
            public CommonSolution CommonSolution { get; set; }
        }

        public class Staff
        {
            public int Staff_Id { get; set; }
            public string EmailAddress { get; set; }
            public string PhoneNumber { get; set; }
            public string OtherDetails { get; set; }
        }

        public class CustomerCall
        {
            public int Call_Id { get; set; }
            public int Customer_Id { get; set; }
            public int CallCenter_Id { get; set; }
            public int CallOutcomeCode { get; set; }
            public int CallStatusCode { get; set; }
            public int RecommendedSolution_Id { get; set; }
            public int Staff_Id { get; set; }
            public DateTime CallDateTime { get; set; }
            public string CallDescription { get; set; }
            public string TailoredSolutionDescription { get; set; }
            public string CallOtherDetails { get; set; }

            public Customer Customer { get; set; }
            public CallCenter CallCenter { get; set; }
            public RefCallOutcome RefCallOutcome { get; set; }
            public RefCallStatusCode RefCallStatusCode { get; set; }
            public Staff Staff { get; set; }
            public CommonSolution CommonSolution { get; set; }
        }
    }
}
