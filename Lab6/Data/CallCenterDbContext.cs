using Lab6.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Data
{
    public class CallCenterDbContext : DbContext
    {
        public DbSet<CallCenter> CallCenters { get; set; }
        public DbSet<CommonProblem> CommonProblems { get; set; }
        public DbSet<CommonSolution> CommonSolutions { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerCall> CustomerCalls { get; set; }
        public DbSet<RefCallOutcome> RefCallOutcomes { get; set; }
        public DbSet<RefCallStatusCode> RefCallStatusCodes { get; set; }
        public DbSet<SolutionsForCommonProblem> SolutionsForCommonProblems { get; set; }
        public DbSet<Staff> Staff { get; set; }

        public CallCenterDbContext(DbContextOptions<CallCenterDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.Customer_Id);

            modelBuilder.Entity<CallCenter>()
                .HasKey(cc => cc.CallCenter_Id);

            modelBuilder.Entity<Staff>()
                .HasKey(s => s.Staff_Id);

            modelBuilder.Entity<Contract>()
                .HasKey(c => c.Contract_Id);

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Customer)
                .WithMany()
                .HasForeignKey(c => c.Customer_Id);

            modelBuilder.Entity<RefCallOutcome>()
                .HasKey(rco => rco.CallOutcomeCode);

            modelBuilder.Entity<RefCallStatusCode>()
                .HasKey(rcs => rcs.CallStatusCode);

            modelBuilder.Entity<CommonProblem>()
                .HasKey(cp => cp.Problem_Id);

            modelBuilder.Entity<CommonSolution>()
                .HasKey(cs => cs.Solution_Id);

            modelBuilder.Entity<SolutionsForCommonProblem>()
                .HasKey(scp => new { scp.Problem_Id, scp.Solution_Id });

            modelBuilder.Entity<SolutionsForCommonProblem>()
                .HasOne(scp => scp.CommonProblem)
                .WithMany()
                .HasForeignKey(scp => scp.Problem_Id);

            modelBuilder.Entity<SolutionsForCommonProblem>()
                .HasOne(scp => scp.CommonSolution)
                .WithMany()
                .HasForeignKey(scp => scp.Solution_Id);

            modelBuilder.Entity<CustomerCall>()
                .HasKey(cc => cc.Call_Id);

            modelBuilder.Entity<CustomerCall>()
                .HasOne(cc => cc.Customer)
                .WithMany()
                .HasForeignKey(cc => cc.Customer_Id);

            modelBuilder.Entity<CustomerCall>()
                .HasOne(cc => cc.CallCenter)
                .WithMany()
                .HasForeignKey(cc => cc.CallCenter_Id);

            modelBuilder.Entity<CustomerCall>()
                .HasOne(cc => cc.RefCallOutcome)
                .WithMany()
                .HasForeignKey(cc => cc.CallOutcomeCode);

            modelBuilder.Entity<CustomerCall>()
                .HasOne(cc => cc.RefCallStatusCode)
                .WithMany()
                .HasForeignKey(cc => cc.CallStatusCode);

            modelBuilder.Entity<CustomerCall>()
                .HasOne(cc => cc.CommonSolution)
                .WithMany()
                .HasForeignKey(cc => cc.RecommendedSolution_Id);

            modelBuilder.Entity<CustomerCall>()
                .HasOne(cc => cc.Staff)
                .WithMany()
                .HasForeignKey(cc => cc.Staff_Id);
        }

        public static void Seed(CallCenterDbContext context)
        {
            if (!context.CallCenters.Any())
            {
                context.CallCenters.AddRange(
                    new CallCenter { CallCenterAddress = "Kyiv Main Office", CallCenterOtherDetails = "24/7 Support" },
                    new CallCenter { CallCenterAddress = "Lviv Support Center", CallCenterOtherDetails = "Specialized in IT Support" }
                );
                context.SaveChanges();
            }

            if (!context.Customers.Any())
            {
                context.Customers.AddRange(
                    new Customer
                    {
                        CustomerAddressLine1 = "123 Main St",
                        CustomerAddressLine2 = "Apartment 1A", 
                        CustomerAddressLine3 = "Apartment 1A",          
                        TownCity = "Kyiv",
                        State = "Kyiv Oblast",
                        EmailAddress = "customer1@example.com",
                        PhoneNumber = "+380501234567",
                        CustomerOtherDetails = "VIP Customer"
                    },
                    new Customer
                    {
                        CustomerAddressLine1 = "456 Elm St",
                        CustomerAddressLine2 = "Suite 202",   
                        CustomerAddressLine3 = "Suite 202",          
                        TownCity = "Lviv",
                        State = "Lviv Oblast",
                        EmailAddress = "customer2@example.com",
                        PhoneNumber = "+380502345678",
                        CustomerOtherDetails = "Regular Customer"
                    }
                );
                context.SaveChanges();
            }

            var customers = context.Customers.ToList();
            if (!context.Contracts.Any() && customers.Count >= 2)
            {
                context.Contracts.AddRange(
                    new Contract
                    {
                        Customer_Id = customers[0].Customer_Id,
                        ContractStartDate = DateTime.UtcNow.AddMonths(-12),
                        ContractEndDate = DateTime.UtcNow.AddMonths(12),
                        OtherDetails = "Standard Service Contract"
                    },
                    new Contract
                    {
                        Customer_Id = customers[1].Customer_Id,
                        ContractStartDate = DateTime.UtcNow.AddMonths(-6),
                        ContractEndDate = DateTime.UtcNow.AddMonths(18),
                        OtherDetails = "Premium Service Contract"
                    }
                );
                context.SaveChanges();
            }

            if (!context.RefCallOutcomes.Any())
            {
                context.RefCallOutcomes.AddRange(
                    new RefCallOutcome { CallOutcomeDescription = "Resolved", OtherCallOutcomeDetails = "Issue resolved successfully" },
                    new RefCallOutcome { CallOutcomeDescription = "Pending", OtherCallOutcomeDetails = "Awaiting customer response" }
                );
                context.SaveChanges();
            }

            if (!context.RefCallStatusCodes.Any())
            {
                context.RefCallStatusCodes.AddRange(
                    new RefCallStatusCode { CallStatusDescription = "Open", CallStatusComments = "Call is active" },
                    new RefCallStatusCode { CallStatusDescription = "Closed", CallStatusComments = "Call is completed" }
                );
                context.SaveChanges();
            }

            if (!context.CommonProblems.Any())
            {
                context.CommonProblems.AddRange(
                    new CommonProblem { ProblemDescription = "Network Issue", OtherProblemDetails = "Slow internet connection" },
                    new CommonProblem { ProblemDescription = "Software Crash", OtherProblemDetails = "Application crashes during usage" }
                );
                context.SaveChanges();
            }

            if (!context.CommonSolutions.Any())
            {
                context.CommonSolutions.AddRange(
                    new CommonSolution { SolutionDescription = "Restart Modem", OtherSolutionDetails = "Restart your modem to resolve network issues" },
                    new CommonSolution { SolutionDescription = "Update Software", OtherSolutionDetails = "Ensure software is updated to the latest version" }
                );
                context.SaveChanges();
            }

            var problems = context.CommonProblems.FirstOrDefault();
            var solutions = context.CommonSolutions.FirstOrDefault();
            if (!context.SolutionsForCommonProblems.Any() && problems != null && solutions != null)
            {
                context.SolutionsForCommonProblems.Add(
                    new SolutionsForCommonProblem { Problem_Id = problems.Problem_Id, Solution_Id = solutions.Solution_Id }
                );
                context.SaveChanges();
            }

            if (!context.Staff.Any())
            {
                context.Staff.AddRange(
                    new Staff { EmailAddress = "staff1@example.com", PhoneNumber = "+380503456789", OtherDetails = "Senior Support Agent" },
                    new Staff { EmailAddress = "staff2@example.com", PhoneNumber = "+380504567890", OtherDetails = "Junior Support Agent" }
                );
                context.SaveChanges();
            }

            var callCenter = context.CallCenters.FirstOrDefault();
            var customer = context.Customers.FirstOrDefault();
            var outcome = context.RefCallOutcomes.FirstOrDefault();
            var status = context.RefCallStatusCodes.FirstOrDefault();
            var staff = context.Staff.FirstOrDefault();

            if (!context.CustomerCalls.Any() && callCenter != null && customer != null && outcome != null && status != null && staff != null)
            {
                context.CustomerCalls.AddRange(
                    new CustomerCall
                    {
                        Customer_Id = customer.Customer_Id,
                        CallCenter_Id = callCenter.CallCenter_Id,
                        CallOutcomeCode = outcome.CallOutcomeCode,
                        CallStatusCode = status.CallStatusCode,
                        Staff_Id = staff.Staff_Id,
                        CallDateTime = DateTime.UtcNow,
                        CallDescription = "Customer reported a network issue",
                        TailoredSolutionDescription = "Recommended to restart modem",
                        CallOtherDetails = "Call handled by senior staff"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
