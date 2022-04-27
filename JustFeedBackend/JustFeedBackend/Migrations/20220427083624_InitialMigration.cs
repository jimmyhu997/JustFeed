using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustFeedBackend.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dish_categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dish_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dish_Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dish_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resturants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Min_order = table.Column<float>(type: "real", nullable: false),
                    Range_delivery = table.Column<byte>(type: "tinyint", nullable: false),
                    delivery_charge = table.Column<float>(type: "real", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resturants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resturants_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resturant_id = table.Column<int>(type: "int", nullable: false),
                    Dish_CategoriesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dishes_Dish_categories_Dish_CategoriesID",
                        column: x => x.Dish_CategoriesID,
                        principalTable: "Dish_categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dishes_Resturants_Resturant_id",
                        column: x => x.Resturant_id,
                        principalTable: "Resturants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Delivery_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creation_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResturantID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Resturants_ResturantID",
                        column: x => x.ResturantID,
                        principalTable: "Resturants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RestDishTypes",
                columns: table => new
                {
                    Dish_typesId = table.Column<int>(type: "int", nullable: false),
                    ResturantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestDishTypes", x => new { x.Dish_typesId, x.ResturantsId });
                    table.ForeignKey(
                        name: "FK_RestDishTypes_Dish_Types_Dish_typesId",
                        column: x => x.Dish_typesId,
                        principalTable: "Dish_Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestDishTypes_Resturants_ResturantsId",
                        column: x => x.ResturantsId,
                        principalTable: "Resturants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDishes",
                columns: table => new
                {
                    DishesId = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDishes", x => new { x.DishesId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_OrderDishes_Dishes_DishesId",
                        column: x => x.DishesId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDishes_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_Dish_CategoriesID",
                table: "Dishes",
                column: "Dish_CategoriesID");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_Resturant_id",
                table: "Dishes",
                column: "Resturant_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDishes_OrdersId",
                table: "OrderDishes",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ResturantID",
                table: "Orders",
                column: "ResturantID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_RestDishTypes_ResturantsId",
                table: "RestDishTypes",
                column: "ResturantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Resturants_UserID",
                table: "Resturants",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDishes");

            migrationBuilder.DropTable(
                name: "RestDishTypes");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Dish_Types");

            migrationBuilder.DropTable(
                name: "Dish_categories");

            migrationBuilder.DropTable(
                name: "Resturants");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
