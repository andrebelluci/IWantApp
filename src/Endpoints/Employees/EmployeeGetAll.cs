﻿using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Authorization;

namespace IWantApp.Endpoints.Employees;

public class EmployeeGetAll
{
    public static string Template => "/employees";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    [Authorize(Policy = "Employee0001Policy")]
    public static IResult Action(int? page, int? rows, QueryAllUsersWithClaimName query)
    {
        if (page == null)
            return Results.BadRequest("Page and rows is required");
        if (rows == null || rows > 5)
            return Results.BadRequest("Rows is required and need to be less than 6");

        return Results.Ok(query.Execute(page.Value, rows.Value));
    }
}
