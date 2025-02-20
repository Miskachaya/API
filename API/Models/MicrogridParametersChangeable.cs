using System;
using System.Collections.Generic;
using API.Configurations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class MicrogridParametersChangeable
{
    public int? BlockId { get; set; }

    public string? BlockType { get; set; }

    public int? StandId { get; set; }

    public virtual ICollection<ParametersChangeable>? ParametersChangeables { get; set; } = new List<ParametersChangeable>();

    public virtual StandPart? Stand { get; set; }
}


//public static class MicrogridParametersChangeableEndpoints
//{
//	public static void MapMicrogridParametersChangeableEndpoints (this IEndpointRouteBuilder routes)
//    {
//        var group = routes.MapGroup("/api/MicrogridParametersChangeable").WithTags(nameof(MicrogridParametersChangeable));

//        group.MapGet("/", async (StandContext db) =>
//        {
//            return await db.MicrogridParametersChangeables.ToListAsync();
//        })
//        .WithName("GetAllMicrogridParametersChangeables")
//        .WithOpenApi();

//        group.MapGet("/{id}", async Task<Results<Ok<MicrogridParametersChangeable>, NotFound>> (int blockid, StandContext db) =>
//        {
//            return await db.MicrogridParametersChangeables.AsNoTracking()
//                .FirstOrDefaultAsync(model => model.BlockId == blockid)
//                is MicrogridParametersChangeable model
//                    ? TypedResults.Ok(model)
//                    : TypedResults.NotFound();
//        })
//        .WithName("GetMicrogridParametersChangeableById")
//        .WithOpenApi();

//        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int blockid, MicrogridParametersChangeable microgridParametersChangeable, StandContext db) =>
//        {
//            var affected = await db.MicrogridParametersChangeables
//                .Where(model => model.BlockId == blockid)
//                .ExecuteUpdateAsync(setters => setters
//                  .SetProperty(m => m.BlockId, microgridParametersChangeable.BlockId)
//                  .SetProperty(m => m.BlockType, microgridParametersChangeable.BlockType)
//                  .SetProperty(m => m.StandId, microgridParametersChangeable.StandId)
//                  );
//            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
//        })
//        .WithName("UpdateMicrogridParametersChangeable")
//        .WithOpenApi();

//        group.MapPost("/", async (MicrogridParametersChangeable microgridParametersChangeable, StandContext db) =>
//        {
//            db.MicrogridParametersChangeables.Add(microgridParametersChangeable);
//            await db.SaveChangesAsync();
//            return TypedResults.Created($"/api/MicrogridParametersChangeable/{microgridParametersChangeable.BlockId}",microgridParametersChangeable);
//        })
//        .WithName("CreateMicrogridParametersChangeable")
//        .WithOpenApi();

//        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int blockid, StandContext db) =>
//        {
//            var affected = await db.MicrogridParametersChangeables
//                .Where(model => model.BlockId == blockid)
//                .ExecuteDeleteAsync();
//            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
//        })
//        .WithName("DeleteMicrogridParametersChangeable")
//        .WithOpenApi();
//    }
//}