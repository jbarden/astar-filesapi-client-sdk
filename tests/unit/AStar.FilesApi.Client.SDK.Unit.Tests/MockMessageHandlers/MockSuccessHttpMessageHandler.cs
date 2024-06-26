﻿using System.Net;
using System.Text.Json;
using AStar.Api.HealthChecks;
using AStar.FilesApi.Client.SDK.Models;

namespace AStar.FilesApi.Client.SDK.MockMessageHandlers;

public class MockSuccessHttpMessageHandler(string responseRequired) : HttpMessageHandler
{
    public int Counter { get; set; }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        HttpContent content;

#pragma warning disable IDE0045 // Convert to conditional expression
        if(responseRequired == "ListDuplicates")
        {
            content = new StringContent(JsonSerializer.Serialize(new List<DuplicateGroup>() { new(), new(), new() }));
        }
        else if(responseRequired == "ListFiles")
        {
            content = new StringContent(JsonSerializer.Serialize(new List<FileDetail>() { new() { Name = "does.not.matter.txt" }, new() }));
        }
        else if(responseRequired == "Count")
        {
            content = new StringContent(Counter.ToString());
        }
        else if(responseRequired == "CountDuplicates")
        {
            content = new StringContent(Counter.ToString());
        }
        else if(responseRequired == "FileAccessDetail")
        {
            content = new StringContent(JsonSerializer.Serialize(new FileAccessDetail() { Id = Guid.NewGuid() }));
        }
        else if(responseRequired == "FileDetail")
        {
            content = new StringContent(JsonSerializer.Serialize(new FileDetail() { Name = "Test File Name" }));
        }
        else if(responseRequired == "Health")
        {
            content = new StringContent(JsonSerializer.Serialize(new HealthStatusResponse() { Status = "OK" }));
        }
        else
        {
            content = new StringContent(JsonSerializer.Serialize(new HealthStatusResponse() { Status = "OK" }));
        }
#pragma warning restore IDE0045 // Convert to conditional expression

        return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = content
        });
    }
}
