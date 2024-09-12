using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addSeedingDataClassRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "Id", "ClassName", "GradeId" },
                values: new object[,]
                {
                    { new Guid("01c6d903-784d-45fb-8511-47e9d6ff7611"), "10A5", new Guid("11f87b17-a80c-4420-b368-4680920bfe3d") },
                    { new Guid("11521ae4-fd95-474c-8d3e-e8ca3cbc21f3"), "12A1", new Guid("b6e0255a-aeee-4df7-8754-55dd27d360b2") },
                    { new Guid("3df0676a-021e-4a1f-a082-fa88b6dbe200"), "11A3", new Guid("afa373a9-b9ab-4561-97b1-549b76f91190") },
                    { new Guid("79dfe9dc-2b47-4222-bce2-7c85e91424d6"), "10A3", new Guid("11f87b17-a80c-4420-b368-4680920bfe3d") },
                    { new Guid("7dbe0c01-40e0-4e8b-8112-0f4c01d6eb2f"), "12A4", new Guid("b6e0255a-aeee-4df7-8754-55dd27d360b2") },
                    { new Guid("88660625-222d-48e7-bef7-aa2fae36d968"), "11A4", new Guid("afa373a9-b9ab-4561-97b1-549b76f91190") },
                    { new Guid("8f3cdace-270e-41bc-8ee5-0d07321c7975"), "11A1", new Guid("afa373a9-b9ab-4561-97b1-549b76f91190") },
                    { new Guid("8fb55a60-4d64-4eb7-9ae1-4202cd25d9e2"), "12A3", new Guid("b6e0255a-aeee-4df7-8754-55dd27d360b2") },
                    { new Guid("9c62f26b-a825-4ee5-9c0a-09cd0aff7409"), "12A5", new Guid("b6e0255a-aeee-4df7-8754-55dd27d360b2") },
                    { new Guid("a71d8e2d-6e7d-44a5-a8be-cd9757f199be"), "11A2", new Guid("afa373a9-b9ab-4561-97b1-549b76f91190") },
                    { new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"), "10A4", new Guid("11f87b17-a80c-4420-b368-4680920bfe3d") },
                    { new Guid("c7235f3d-8414-4832-b0c5-a97781490a48"), "11A5", new Guid("afa373a9-b9ab-4561-97b1-549b76f91190") },
                    { new Guid("d2a5a5a1-87c6-4714-bbfd-176571ebf89a"), "10A2", new Guid("11f87b17-a80c-4420-b368-4680920bfe3d") },
                    { new Guid("ddd7dda5-a208-4ccc-947e-c96e603a4609"), "12A2", new Guid("b6e0255a-aeee-4df7-8754-55dd27d360b2") },
                    { new Guid("f3bc74d1-04c8-47c9-b569-d9aaf268f195"), "10A1", new Guid("11f87b17-a80c-4420-b368-4680920bfe3d") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("01c6d903-784d-45fb-8511-47e9d6ff7611"));

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("11521ae4-fd95-474c-8d3e-e8ca3cbc21f3"));

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("3df0676a-021e-4a1f-a082-fa88b6dbe200"));

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("79dfe9dc-2b47-4222-bce2-7c85e91424d6"));

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("7dbe0c01-40e0-4e8b-8112-0f4c01d6eb2f"));

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("88660625-222d-48e7-bef7-aa2fae36d968"));

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("8f3cdace-270e-41bc-8ee5-0d07321c7975"));

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("8fb55a60-4d64-4eb7-9ae1-4202cd25d9e2"));

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("9c62f26b-a825-4ee5-9c0a-09cd0aff7409"));

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("a71d8e2d-6e7d-44a5-a8be-cd9757f199be"));

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("afab05ef-e3e7-4902-a141-05c3057b92f3"));

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("c7235f3d-8414-4832-b0c5-a97781490a48"));

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("d2a5a5a1-87c6-4714-bbfd-176571ebf89a"));

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("ddd7dda5-a208-4ccc-947e-c96e603a4609"));

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("f3bc74d1-04c8-47c9-b569-d9aaf268f195"));
        }
    }
}
