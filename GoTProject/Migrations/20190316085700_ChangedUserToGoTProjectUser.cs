using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoTProject.Migrations
{
    public partial class ChangedUserToGoTProjectUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_User_InvAdminAcceptorUserID",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_User_ConsumerUserID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_User_ReserveeUserID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_User_UserID",
                table: "Seats");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Seats_UserID",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReserveeUserID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ConsumerUserID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_InvAdminAcceptorUserID",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "ReserveeUserID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ConsumerUserID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "InvAdminAcceptorUserID",
                table: "Inventory");

            migrationBuilder.AddColumn<string>(
                name: "OccupantId",
                table: "Seats",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReserveeId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConsumerId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvAdminAcceptorId",
                table: "Inventory",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_OccupantId",
                table: "Seats",
                column: "OccupantId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReserveeId",
                table: "Reservations",
                column: "ReserveeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ConsumerId",
                table: "Orders",
                column: "ConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_InvAdminAcceptorId",
                table: "Inventory",
                column: "InvAdminAcceptorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_AspNetUsers_InvAdminAcceptorId",
                table: "Inventory",
                column: "InvAdminAcceptorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ConsumerId",
                table: "Orders",
                column: "ConsumerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_ReserveeId",
                table: "Reservations",
                column: "ReserveeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_AspNetUsers_OccupantId",
                table: "Seats",
                column: "OccupantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_AspNetUsers_InvAdminAcceptorId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ConsumerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_ReserveeId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_AspNetUsers_OccupantId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_OccupantId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReserveeId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ConsumerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_InvAdminAcceptorId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "OccupantId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "ReserveeId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ConsumerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "InvAdminAcceptorId",
                table: "Inventory");

            migrationBuilder.AddColumn<int>(
                name: "ReserveeUserID",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConsumerUserID",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvAdminAcceptorUserID",
                table: "Inventory",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    IsEmployee = table.Column<bool>(nullable: false),
                    IsInventoryManager = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seats_UserID",
                table: "Seats",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReserveeUserID",
                table: "Reservations",
                column: "ReserveeUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ConsumerUserID",
                table: "Orders",
                column: "ConsumerUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_InvAdminAcceptorUserID",
                table: "Inventory",
                column: "InvAdminAcceptorUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_User_InvAdminAcceptorUserID",
                table: "Inventory",
                column: "InvAdminAcceptorUserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_User_ConsumerUserID",
                table: "Orders",
                column: "ConsumerUserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_User_ReserveeUserID",
                table: "Reservations",
                column: "ReserveeUserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_User_UserID",
                table: "Seats",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
