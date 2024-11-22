using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab6.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CallCenters",
                columns: table => new
                {
                    CallCenter_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CallCenterAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallCenterOtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallCenters", x => x.CallCenter_Id);
                });

            migrationBuilder.CreateTable(
                name: "CommonProblems",
                columns: table => new
                {
                    Problem_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProblemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherProblemDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonProblems", x => x.Problem_Id);
                });

            migrationBuilder.CreateTable(
                name: "CommonSolutions",
                columns: table => new
                {
                    Solution_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolutionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherSolutionDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonSolutions", x => x.Solution_Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerAddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAddressLine3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TownCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerOtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Customer_Id);
                });

            migrationBuilder.CreateTable(
                name: "RefCallOutcomes",
                columns: table => new
                {
                    CallOutcomeCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CallOutcomeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherCallOutcomeDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefCallOutcomes", x => x.CallOutcomeCode);
                });

            migrationBuilder.CreateTable(
                name: "RefCallStatusCodes",
                columns: table => new
                {
                    CallStatusCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CallStatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallStatusComments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefCallStatusCodes", x => x.CallStatusCode);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Staff_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Staff_Id);
                });

            migrationBuilder.CreateTable(
                name: "SolutionsForCommonProblems",
                columns: table => new
                {
                    Problem_Id = table.Column<int>(type: "int", nullable: false),
                    Solution_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolutionsForCommonProblems", x => new { x.Problem_Id, x.Solution_Id });
                    table.ForeignKey(
                        name: "FK_SolutionsForCommonProblems_CommonProblems_Problem_Id",
                        column: x => x.Problem_Id,
                        principalTable: "CommonProblems",
                        principalColumn: "Problem_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolutionsForCommonProblems_CommonSolutions_Solution_Id",
                        column: x => x.Solution_Id,
                        principalTable: "CommonSolutions",
                        principalColumn: "Solution_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Contract_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    ContractStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Contract_Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Customers_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customers",
                        principalColumn: "Customer_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCalls",
                columns: table => new
                {
                    Call_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    CallCenter_Id = table.Column<int>(type: "int", nullable: false),
                    CallOutcomeCode = table.Column<int>(type: "int", nullable: false),
                    CallStatusCode = table.Column<int>(type: "int", nullable: false),
                    RecommendedSolution_Id = table.Column<int>(type: "int", nullable: false),
                    Staff_Id = table.Column<int>(type: "int", nullable: false),
                    CallDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CallDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TailoredSolutionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallOtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCalls", x => x.Call_Id);
                    table.ForeignKey(
                        name: "FK_CustomerCalls_CallCenters_CallCenter_Id",
                        column: x => x.CallCenter_Id,
                        principalTable: "CallCenters",
                        principalColumn: "CallCenter_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerCalls_CommonSolutions_RecommendedSolution_Id",
                        column: x => x.RecommendedSolution_Id,
                        principalTable: "CommonSolutions",
                        principalColumn: "Solution_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerCalls_Customers_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customers",
                        principalColumn: "Customer_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerCalls_RefCallOutcomes_CallOutcomeCode",
                        column: x => x.CallOutcomeCode,
                        principalTable: "RefCallOutcomes",
                        principalColumn: "CallOutcomeCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerCalls_RefCallStatusCodes_CallStatusCode",
                        column: x => x.CallStatusCode,
                        principalTable: "RefCallStatusCodes",
                        principalColumn: "CallStatusCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerCalls_Staff_Staff_Id",
                        column: x => x.Staff_Id,
                        principalTable: "Staff",
                        principalColumn: "Staff_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_Customer_Id",
                table: "Contracts",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCalls_CallCenter_Id",
                table: "CustomerCalls",
                column: "CallCenter_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCalls_CallOutcomeCode",
                table: "CustomerCalls",
                column: "CallOutcomeCode");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCalls_CallStatusCode",
                table: "CustomerCalls",
                column: "CallStatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCalls_Customer_Id",
                table: "CustomerCalls",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCalls_RecommendedSolution_Id",
                table: "CustomerCalls",
                column: "RecommendedSolution_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCalls_Staff_Id",
                table: "CustomerCalls",
                column: "Staff_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionsForCommonProblems_Solution_Id",
                table: "SolutionsForCommonProblems",
                column: "Solution_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "CustomerCalls");

            migrationBuilder.DropTable(
                name: "SolutionsForCommonProblems");

            migrationBuilder.DropTable(
                name: "CallCenters");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "RefCallOutcomes");

            migrationBuilder.DropTable(
                name: "RefCallStatusCodes");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "CommonProblems");

            migrationBuilder.DropTable(
                name: "CommonSolutions");
        }
    }
}
