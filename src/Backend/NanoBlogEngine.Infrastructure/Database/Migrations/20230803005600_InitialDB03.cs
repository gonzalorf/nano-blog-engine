﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NanoBlogEngine.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class InitialDB03 : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<string>(
            name: "Role",
            table: "Users",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "Role",
            table: "Users");
    }
}
