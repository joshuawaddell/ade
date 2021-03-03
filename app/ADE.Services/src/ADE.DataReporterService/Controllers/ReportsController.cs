﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ADE.DataContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ADE.DataReporterService.Controllers
{
    [ApiController, Route("[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly ILogger<ReportsController> _logger;

        public ReportsController(ILogger<ReportsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Task<IEnumerable<UserDataPoint>> GetAsync()
        {
            var mockDataPoints = new List<UserDataPoint>();

            for(var i = 0; i < 100; i++)
            {
                var mockDataPoint = new UserDataPoint
                {
                    Id = Guid.NewGuid(),
                    Content = "Sample " + (i + 1),
                    CreatedAt = DateTime.UtcNow,
                    DataSource = "MockData",
                    UserId = Guid.NewGuid()
                };
                mockDataPoints.Add(mockDataPoint);
            }

            return Task.FromResult((IEnumerable<UserDataPoint>) mockDataPoints);
        }
    }
}